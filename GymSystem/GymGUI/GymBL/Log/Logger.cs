using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementBL.Log
{
    /// <summary>
    /// this class is an abstract class for all of the system loggers
    /// </summary>
    abstract public class Logger
    {
        /// <summary>
        /// this enum defines the diffrent levels of log entries
        /// the system is configured to write only some of the log
        /// entries dependng on their log level.
        /// debug if the less important level and error is the most important
        /// </summary>
        public enum LogLevelEnum
        {
            Debug = 1,
            Info = 2,
            Warning = 3,
            Errors = 4
        }

        /// <summary>
        /// open the log object connection
        /// </summary>
        abstract public void OpenLog() ;

        /// <summary>
        /// close the log
        /// </summary>
        abstract public void CloseLog() ;

        /// <summary>
        /// write a log entry using the specified logger
        /// </summary>
        /// <param name="message">the log actual message</param>
        /// <param name="logLevel">the log level for this entry</param>
        /// <param name="userName">the connected user name</param>
        /// <param name="actionName">the action that sent the log entry</param>
        abstract public void WriteLogEntry(string message, Logger.LogLevelEnum logLevel,
            string userName, string actionName) ;
    }
}
