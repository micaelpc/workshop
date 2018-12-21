using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerManagementDAL;

namespace GymBL.Log
{ 
    /// <summary>
    /// thia logger writes the log data to the log table in the system`s db
    /// </summary>
    public class DBLogger : Logger
    {
        /// <summary>
        /// the db connection used by this logger 
        /// </summary>
        DBConnection m_Connection;

        // open the db connection
        public override void OpenLog()
        {
            m_Connection = ConnectionQueue.Instance.GetConnection();
        }

        /// <summary>
        /// close the db connection
        /// </summary>
        public override void CloseLog()
        {
            ConnectionQueue.Instance.ReturnConnection(m_Connection);
        }

        /// <summary>
        /// write a log entry to the system log table in the db
        /// </summary>
        /// <param name="message">the log actual message</param>
        /// <param name="logLevel">the log level for this entry</param>
        /// <param name="userName">the connected user name</param>
        /// <param name="actionName">the action that sent the log entry</param>
        public override void WriteLogEntry(string message, Logger.LogLevelEnum logLevel, string userName, string actionName)
        {
            int result = DBActions.ExecuteNonQuery("insert into SystemLog(UserName,ActionName,Message,LogLevel) "
                + "values('" + userName + "',"
                + "'" + actionName + "',"
                + "'" + message + "',"
                + "'" + logLevel.ToString() + "')"
                , m_Connection);
        }
    }
}
