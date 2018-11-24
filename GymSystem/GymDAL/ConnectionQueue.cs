using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VolunteerManagementDAL
{
    /// <summary>
    /// this class is a singleton that enables all of the other classes
    /// to get db connections. it ensures that there is a set number of
    /// db connection in the system and that it is shared by all of the system
    /// parts
    /// </summary>
    public sealed class ConnectionQueue
    {
        /// <summary>
        /// the general connection string
        /// </summary>
        private static string m_ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        /// <summary>
        /// the system`s db path
        /// </summary>
        private static string m_DBPath = @"C:\VMS\VolunteerDB.mdb";

        /// <summary>
        /// the actual instance of the Connection Queue. it is only initialized 
        /// one time and then accessed through the class static property
        /// </summary>
        private static readonly ConnectionQueue instance = new ConnectionQueue();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ConnectionQueue()
        {
        }

        /// <summary>
        /// the private inner constructor
        /// </summary>
        private ConnectionQueue()
        {
        }

        /// <summary>
        /// The public Instance property to use
        /// </summary>
        public static ConnectionQueue Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// changes the db path . if there are already open connections 
        /// then they are closed and reopened with the new path
        /// </summary>
        /// <param name="dbPath"></param>
        public void SetDBPath(string dbPath)
        {
            m_DBPath = dbPath;
            if (m_Queue != null)
            {
                IEnumerator enumerator = m_Queue.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DBConnection connection = (DBConnection)enumerator.Current;
                    connection.CloseConnection();
                    connection.SetConnectionString(m_ConnectionString + m_DBPath);
                    connection.OpenConnection();
                }
            }
        }

        /// <summary>
        /// this is a queue of the available db connections for system use
        /// </summary>
        private Queue<DBConnection> m_Queue;

        /// <summary>
        /// this method inits a fixed number of db connections 
        /// and inserts them into the connection queue
        /// </summary>
        /// <param name="connectionNum">the number of connections</param>
        public void InitConnections(int connectionNum)
        {
            if (m_Queue != null)
                CloseConnections();
            m_Queue = new Queue<DBConnection>(connectionNum);
            for (int i = 0; i < connectionNum; i++)
            {
                DBConnection currentConnection = new DBConnection(m_ConnectionString+m_DBPath);
                currentConnection.OpenConnection();
                m_Queue.Enqueue(currentConnection);
            }
        }

        /// <summary>
        /// closes all of the system connections
        /// </summary>
        public void CloseConnections()
        {
            if (m_Queue != null)
            {
                while (m_Queue.Count > 0)
                {
                    DBConnection currentConnection = m_Queue.Dequeue();
                    currentConnection.CloseConnection();
                }
            }
        }

        /// <summary>
        /// get the next available connection from the queue
        /// </summary>
        /// <returns>the db connection, if none available then null</returns>
        public DBConnection GetConnection()
        {
            if (m_Queue != null)
            {
                if (m_Queue.Count > 0)
                    return m_Queue.Dequeue();
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// returns a db connection to the queue after use
        /// </summary>
        /// <param name="connection">the connection that is returned to the pool</param>
        public void ReturnConnection(DBConnection connection)
        {
            m_Queue.Enqueue(connection);
        }
    }
}
