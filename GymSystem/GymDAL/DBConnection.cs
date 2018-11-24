using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace VolunteerManagementDAL
{
    /// <summary>
    /// this class wraps the oledbconnection class
    /// it ensures that a change of the db type will be simpler 
    /// and that the connection object will be changed only here
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// the connection object
        /// </summary>
        public OleDbConnection Connection
        {
            get { return m_connection; }
        }
        private OleDbConnection m_connection;

        /// <summary>
        /// the constructor for this class
        /// </summary>
        /// <param name="ConnectionString">the connection string used when the connection is opened</param>
        public DBConnection(string ConnectionString)
        {
            m_connection = new OleDbConnection(ConnectionString);
        }

        /// <summary>
        /// opens the connection, the methos tries 3 times and then throw
        /// an exception
        /// </summary>
        public void OpenConnection()
        {
            int numOfTries = 0;
            while (numOfTries < 3)
            {
                try
                {
                    if (m_connection.State == System.Data.ConnectionState.Closed)
                        m_connection.Open();
                    if (m_connection.State == System.Data.ConnectionState.Open)
                        return;
                }
                catch (Exception e)
                {
                    numOfTries++;
                    if (numOfTries == 3)
                        throw e;
                }
            }
        }

        /// <summary>
        /// close the db connection, the methos tries 3 times and then throw
        /// an exception
        /// </summary>
        public void CloseConnection()
        {
            int numOfTries = 0;
            while (numOfTries < 3)
            {
                try
                {
                    if (m_connection.State != System.Data.ConnectionState.Closed)
                        m_connection.Close();
                    if (m_connection.State == System.Data.ConnectionState.Closed)
                        return;
                }
                catch (Exception e)
                {
                    numOfTries++;
                    if (numOfTries == 3)
                        throw e;
                }
            }
        }

        /// <summary>
        /// sets the connection string if the db changed
        /// </summary>
        /// <param name="newConnectionString">the new connection string used</param>
        public void SetConnectionString(string newConnectionString)
        {
            m_connection.ConnectionString = newConnectionString;
        }

    }
}
