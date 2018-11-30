using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerManagementBL;

namespace VolunteerManagementBL.Log
{
    /// <summary>
    /// this class is a singleton that enables all of the other classes
    /// to write log entries
    /// </summary>
    public sealed class LogManager
    {
        /// <summary>
        /// the system configured log level. all write requestes of a lower level
        /// will not be executed. debug is the lowest level and error is the 
        /// highest level
        /// </summary>
        private Logger.LogLevelEnum m_LogLevel = Logger.LogLevelEnum.Info;

        /// <summary>
        /// the actual instance of the log manager. it is only initialized 
        /// one time and then accessed through the class static property
        /// </summary>
        private static readonly LogManager instance = new LogManager();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static LogManager()
        {
        }

        /// <summary>
        /// the private inner constructor
        /// </summary>
        private LogManager()
        {
        }

        /// <summary>
        /// The public Instance property to use
        /// </summary>
        public static LogManager Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// this sets the log level that filters the log entries
        /// </summary>
        /// <param name="LogLevelName"></param>
        public void SetLogLevel(string LogLevelName)
        {
            m_LogLevel = (Logger.LogLevelEnum)Enum.Parse(typeof(Logger.LogLevelEnum), LogLevelName);
        }

        /// <summary>
        /// this is a list of all the available loggers in the system
        /// each entry will be routed to each of the loggers
        /// </summary>
        private List<Logger> m_LoggerList;

        /// <summary>
        /// init the diffrent loggers in the system and prepare them for use
        /// </summary>
        public void InitLoggers()
        {
            // get the configured log level
            m_LogLevel = (Logger.LogLevelEnum)Enum.Parse(typeof(Logger.LogLevelEnum), ConfigurationManager.GetConfigValue("LogLevel"));
            // check which loggers to create according to the system configuration
            bool enableFileLogger = Convert.ToBoolean(ConfigurationManager.GetConfigValue("EnableFileLog"));
            bool enableDBLogger = Convert.ToBoolean(ConfigurationManager.GetConfigValue("EnableDBLog"));
            bool enableEventViewerLogger = Convert.ToBoolean(ConfigurationManager.GetConfigValue("EnableEventViewerLog"));
            m_LoggerList = new List<Logger>(3);
            // create the loggers
            if (enableFileLogger)
            {
                try
                {
                    Logger logger = new FileLogger();
                    logger.OpenLog();
                    m_LoggerList.Add(logger);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("לא ניתן לפתוח לוג קובץ: " + e.Message, Logger.LogLevelEnum.Errors, "General", "OpenLog");
                    throw new Exception("לא ניתן לפתוח לוג קובץ: " + e.Message,e);
                }
            }
            if (enableDBLogger)
            {
                try
                {
                    Logger logger = new DBLogger();
                    logger.OpenLog();
                    m_LoggerList.Add(logger);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("לא ניתן לפתוח לוג בסיס נתונים: " + e.Message, Logger.LogLevelEnum.Errors, "General", "OpenLog");
                    throw new Exception("לא ניתן לפתוח לוג בסיס נתונים: " + e.Message, e);
                }
            }
            if (enableEventViewerLogger)
            {
                try
                {
                    Logger logger = new EventViewerLogger();
                    logger.OpenLog();
                    m_LoggerList.Add(logger);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("לא ניתן לפתוח לוג יומן אירועים: " + e.Message, Logger.LogLevelEnum.Errors, "General", "OpenLog");
                    throw new Exception("לא ניתן לפתוח לוג יומן אירועים: " + e.Message, e);
                }
            }
        }

        /// <summary>
        /// close all of the open loggers
        /// </summary>
        public void CloseLoggers()
        {
            if (m_LoggerList != null)
            {
                for (int i = 0; i < m_LoggerList.Count; i++)
                {
                    Logger current = m_LoggerList.ElementAt(i);
                    current.CloseLog();
                }
            }
        }

        /// <summary>
        /// sends a log entry to all of the defined loggers.
        /// if the entry`s log level is lower than the class log
        /// level than the entry is not writen
        /// </summary>
        /// <param name="message">the log actual message</param>
        /// <param name="logLevel">the log level for this entry</param>
        /// <param name="userName">the connected user name</param>
        /// <param name="actionName">the action that sent the log entry</param>
        public void WriteEntry(string message, Logger.LogLevelEnum logLevel,
            string userName, string actionName)
        {
            bool Continue = true;
            switch (m_LogLevel)
            {
                case Logger.LogLevelEnum.Debug:
                    break;
                case Logger.LogLevelEnum.Info:
                    if (logLevel == Logger.LogLevelEnum.Debug)
                        Continue = false;
                    break;
                case Logger.LogLevelEnum.Warning:
                    if (logLevel == Logger.LogLevelEnum.Debug
                        || logLevel == Logger.LogLevelEnum.Info)
                        Continue = false;
                    break;
                case Logger.LogLevelEnum.Errors:
                    if (logLevel != Logger.LogLevelEnum.Errors)
                        Continue = false;
                    break;
            }

            if (!Continue)
                return;

            if (m_LoggerList != null)
            {
                for (int i = 0; i < m_LoggerList.Count; i++)
                {
                    try
                    {
                        Logger current = m_LoggerList.ElementAt(i);
                        current.WriteLogEntry(message, logLevel, userName, actionName);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

    }
}
