using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GymBL.Log
{
    /// <summary>
    /// this logger writes the log data to the computer`s event viewer
    /// </summary>
    public class EventViewerLogger : Logger
    {
        /// <summary>
        /// the event viewer category
        /// </summary>
        const string EventLogLogName = "Application";

        /// <summary>
        /// the system name in the event viewer
        /// </summary>
        const string EventLogLogSource = "VMS";

        /// <summary>
        /// the event viewer output object
        /// </summary>
        private EventLog m_EventLog;

        /// <summary>
        /// init the event viewer object
        /// </summary>
        public override void OpenLog()
        {
            m_EventLog = new EventLog(EventLogLogName);
            m_EventLog.Source = EventLogLogSource;
        }

        /// <summary>
        /// close the event viewer connection
        /// </summary>
        public override void CloseLog()
        {
            m_EventLog.Close();
        }

        /// <summary>
        /// write a log entry to the event viewer
        /// </summary>
        /// <param name="message">the log actual message</param>
        /// <param name="logLevel">the log level for this entry</param>
        /// <param name="userName">the connected user name</param>
        /// <param name="actionName">the action that sent the log entry</param>
        public override void WriteLogEntry(string message, Logger.LogLevelEnum logLevel, string userName, string actionName)
        {
            EventLogEntryType type = EventLogEntryType.Information;
            switch (logLevel)
            {
                case LogLevelEnum.Debug:
                    type = EventLogEntryType.Information;
                    break;
                case LogLevelEnum.Info:
                    type = EventLogEntryType.Information;
                    break;
                case LogLevelEnum.Warning:
                    type = EventLogEntryType.Warning;
                    break;
                case LogLevelEnum.Errors:
                    type = EventLogEntryType.Error;
                    break;
            }
            m_EventLog.WriteEntry(userName + ";" + actionName + ";" + message,type);
        }
    }
}
