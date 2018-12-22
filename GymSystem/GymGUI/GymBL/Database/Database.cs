using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace GymBL.Database
{
    public class Database
    {
        private static Database Instance;

        public static string GetConnectionString() {
            if (System.Environment.MachineName == "SHALTIPC")
                return @"
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\dev\workshop\GymSystem\GymGUI\GymBL\Gym.mdf;
Integrated Security=True";
            else
                return @"
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\dev\workshop\GymSystem\GymGUI\GymBL\Gym.mdf;
Integrated Security=True"; // TODO: Michael. Change connection string here
        }
        public static Database GetInstance() {
            if (Instance == null)
                Instance = new Database(GetConnectionString());
            return Instance;
        }

        /// <summary>
        /// the constructor for this class
        /// </summary>
        /// <param name="ConnectionString">the connection string used when the connection is opened</param>
        public Database(string ConnectionString)
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        /// <summary>
        /// the connection object
        /// </summary>
        public SqlConnection Connection
        {
            get;
        }
        private Dictionary<Tuple<string, Type>, object> m_liveObjects = new Dictionary<Tuple<string, Type>, object>();


        public void Update<T>(T value) where T : IDatabaseSerializable
        {
            var name = value.GetType().Name;
        
            DatabaseStream st = new DatabaseStream();
            value.Serialize(st);
            string columnsValue = string.Join(", ", st.Columns.Zip(st.Values, (first, second) => first + "=" + second).ToArray());
            var id = st.Values[st.Columns.IndexOf("id")];
            ExecuteNonQuery($"UPDATE {name} SET {columnsValue} WHERE id={id};");
            foreach (IDatabaseSerializable obj in st.MoreObjects)
                Update(obj);
        }

        public T Get<T>(string id) where T : IDatabaseSerializable, new()
        {
            var key = new Tuple<string, Type>(id, typeof(T));
            if (m_liveObjects.ContainsKey(key))
                return (T)m_liveObjects[key];
            T value = new T();

            m_liveObjects[key] = value;

            var name = typeof(T).Name;
            var result = ExecuteQuery($"Select * from {name} where id='{id}'");
            if (result.Rows.Count != 1)
                throw new Exception($"Failed to get {name} with id {id}");
            value.Load(result.Rows[0], this);
            m_liveObjects.Remove(key);
            return value;
        }


        public void DeleteAll<T>() where T : IDatabaseSerializable, new()
        {
            var name = typeof(T).Name;
            ExecuteNonQuery($"DELETE FROM {name}");
        }
        public List<T> GetAll<T>(string condition) where T : IDatabaseSerializable, new()
        {
            var name = typeof(T).Name;
            var result = ExecuteQuery($"Select * from {name} where {condition}");
            List<T> retValue = new List<T>();
            foreach (DataRow row in result.Rows)
            {
                T temp = new T();
                temp.Load(row, this);
                retValue.Add(temp);
            }
            return retValue;
        }

        public List<T> GetAll<T>() where T : IDatabaseSerializable, new()
        {
            var name = typeof(T).Name;
            var result = ExecuteQuery($"Select * from {name}");
            List<T> retValue = new List<T>();
            foreach (DataRow row in result.Rows)
            {
                T temp = new T();
                temp.Load(row, this);
                retValue.Add(temp);
            }
            return retValue;
        }

        public void Insert<T>(T value) where T : IDatabaseSerializableWithId
        {
            var name = value.GetType().Name;
            DatabaseStream st = new DatabaseStream();
            value.Serialize(st);
            var columns = string.Join(", ", st.Columns.ToArray());
            var values = string.Join(", ", st.Values.ToArray());
            var result = ExecuteQuery($"INSERT INTO {name}({columns}) OUTPUT Inserted.Id VALUES({values});");
            value.SetId(result.Rows[0]["Id"].ToString());
            foreach (var obj in st.MoreObjects)
                Insert(obj);
        }

        /// <summary>
        /// this method executes a query that doesn`t alter the db data
        /// and retunrs one or many data rows
        /// </summary>
        /// <param name="sqlString">the select query</param>
        /// <returns>this datatable is the result of the query</returns>
        public DataTable ExecuteQuery(string sqlString)
        {
            var command = new SqlCommand(sqlString, Connection);
            var adapter = new SqlDataAdapter(command);
            DataTable result = new DataTable();
            adapter.Fill(result);
            return result;
        }



        /// <summary>
        /// this method executes a query that alters the db data such
        /// as update or delete
        /// </summary>
        /// <param name="sqlString">the execution command</param>
        /// <param name="connection">the db connection for the operation</param>
        /// <returns>the number of rows affected</returns>
        public int ExecuteNonQuery(string sqlString)
        {
            SqlCommand command = new SqlCommand(sqlString, Connection);
            return command.ExecuteNonQuery();
        }
    }
}
