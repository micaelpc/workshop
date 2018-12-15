﻿using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace GymBL.Database
{
    public class Database
    {

        /// <summary>
        /// the constructor for this class
        /// </summary>
        /// <param name="ConnectionString">the connection string used when the connection is opened</param>
        public Database(string ConnectionString)
        {
            m_connection = new OleDbConnection(ConnectionString);
            m_connection.Open();
        }

        /// <summary>
        /// the connection object
        /// </summary>
        public OleDbConnection Connection
        {
            get { return m_connection; }
        }
        private OleDbConnection m_connection;


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
            T value = new T();
            var name = typeof(T).Name;
            var result = ExecuteQuery($"Select * from {name} where id='{id}'");
            if (result.Rows.Count != 1)
                throw new Exception($"Failed to get {name} with id {id}");
            value.Load(result.Rows[0], this);
            return value;
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

        public void Insert<T>(T value) where T : IDatabaseSerializable
        {
            var name = value.GetType().Name;
            DatabaseStream st = new DatabaseStream();
            value.Serialize(st);
            var columns = string.Join(", ", st.Columns.ToArray());
            var values = string.Join(", ", st.Values.ToArray());
            ExecuteNonQuery($"INSERT INTO {name}({columns}) VALUES({values});");
            foreach (IDatabaseSerializable obj in st.MoreObjects)
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
            OleDbCommand command = new OleDbCommand(sqlString, Connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
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
            OleDbCommand command = new OleDbCommand(sqlString, Connection);
            return command.ExecuteNonQuery();
        }
    }
}