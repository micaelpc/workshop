using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace GymBL.Database
{
    /// <summary>
    /// This class Represents the database.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Instancte (Singleton class)
        /// </summary>
        private static Database Instance;

        /// <summary>
        /// Connection string
        /// </summary>
        /// <returns>The connection string to the db</returns>
        public static string GetConnectionString() {
            if (System.Environment.MachineName == "SHALTIPC")
                return @"
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\dev\workshop\GymSystem\GymGUI\GymBL\Gym.mdf;
Integrated Security=True";
            else
                return @"
Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\dev\workshop\GymSystem\GymGUI\GymBL\Gym.mdf;Integrated Security=True"; // TODO: Michael. Change connection string here
        }

        /// <summary>
        /// Returns the instance of this singleton
        /// </summary>
        /// <returns>The instance of the class</returns>
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

        /// <summary>
        /// To break cycles, the is the loaded objects.
        /// </summary>
        private Dictionary<Tuple<object, Type>, object> m_liveObjects = new Dictionary<Tuple<object, Type>, object>();

        /// <summary>
        /// Updates the database about the serializable object.
        /// </summary>
        /// <typeparam name="T">The type of the object to be serialized</typeparam>
        /// <param name="value">The value to be serialized</param>
        public void Update<T>(T value) where T : IDatabaseSerializable
        {
            var name = value.GetType().Name;
        
            DatabaseStream st = new DatabaseStream();
            value.Serialize(st);
            var idIndex = st.Columns.IndexOf("id");
            var id = st.Values[st.Columns.IndexOf("id")];
            st.Columns.RemoveAt(idIndex);
            st.Values.RemoveAt(idIndex);
            string columnsValue = string.Join(", ", st.Columns.Zip(st.Values, (first, second) => first + "=" + second).ToArray());
            
            ExecuteNonQuery($"UPDATE {name} SET {columnsValue} WHERE id={id};");
            foreach (IDatabaseSerializableWithId obj in st.MoreObjects)
            {
                if (obj.GetId() == "")
                    Insert(obj);
                else
                    Update(obj);
            }
        }

        /// <summary>
        /// Returns an instance of a type by it's id.
        /// </summary>
        /// <typeparam name="T">The type of the object to be retrieved from the db</typeparam>
        /// <param name="id">The id ob the object</param>
        /// <returns>An instance of T with the id</returns>
        public T Get<T>(string id) where T : IDatabaseSerializable, new()
        {
            var name = typeof(T).Name;
            var result = ExecuteQuery($"Select * from {name} where id='{id}'");
            if (result.Rows.Count != 1)
                throw new Exception($"Failed to get {name} with id {id}");
            return Load<T>(result.Rows[0]);
        }

        /// <summary>
        /// Same as Get, just id as a numbers.
        /// </summary>
        public T Get<T>(int id) where T : IDatabaseSerializable, new()
        {
            var name = typeof(T).Name;
            var result = ExecuteQuery($"Select * from {name} where id={id}");
            if (result.Rows.Count != 1)
                throw new Exception($"Failed to get {name} with id {id}");
            return Load<T>(result.Rows[0]);
        }
        
        /// <summary>
        /// Deletes all the objects of a specific type.
        /// </summary>
        /// <typeparam name="T">The type of object to be deleted</typeparam>
        public void DeleteAll<T>() where T : IDatabaseSerializable, new()
        {
            var name = typeof(T).Name;
            ExecuteNonQuery($"DELETE FROM {name}");
        }

        /// <summary>
        /// Returns all inserted instances of a specific type that satisfy a condition.
        /// </summary>
        /// <typeparam name="T">The type of instance</typeparam>
        /// <param name="condition">The condition to be met.</param>
        /// <returns>All instances that satisfy the condition</returns>
        public List<T> GetAll<T>(string condition) where T : IDatabaseSerializable, new()
        {
            var name = typeof(T).Name;
            var result = ExecuteQuery($"Select * from {name} where {condition}");
            List<T> retValue = new List<T>();
            foreach (DataRow row in result.Rows)
            {
                T temp = Load<T>(row);
                retValue.Add(temp);
            }
            return retValue;
        }

        /// <summary>
        /// Loads an instance from database row
        /// </summary>
        /// <typeparam name="T">The type to be loaded</typeparam>
        /// <param name="row">The row representing the object</param>
        /// <returns>A loaded instance from the row</returns>
        private T Load<T>(DataRow row) where T : IDatabaseSerializable, new()
        {
            var key = new Tuple<object, Type>(row["id"], typeof(T));
            if (m_liveObjects.ContainsKey(key))
                return (T)m_liveObjects[key];
            T temp = new T();
            m_liveObjects[key] = temp;
            temp.Load(row, this);
            m_liveObjects.Remove(key);
            return temp;
        }

        /// <summary>
        /// Returns all instances of a specific type ever to be inserted to the database.
        /// </summary>
        /// <typeparam name="T">The type of the instances.</typeparam>
        /// <returns>List of all instances of type T ever inserted to the database</returns>
        public List<T> GetAll<T>() where T : IDatabaseSerializable, new()
        {
            var name = typeof(T).Name;
            var result = ExecuteQuery($"Select * from {name}");
            List<T> retValue = new List<T>();
            foreach (DataRow row in result.Rows)
            {
                T temp = Load<T>(row);
                retValue.Add(temp);
            }
            return retValue;
        }

        /// <summary>
        /// Inserts a new object to the database.
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="value">The object to be inserted to the database</param>
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
