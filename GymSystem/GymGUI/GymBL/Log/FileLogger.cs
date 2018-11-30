using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VolunteerManagementBL.Log
{
    /// <summary>
    /// this logger writes the log data to a log file
    /// </summary>
    public class FileLogger : Logger
    {
        /// <summary>
        /// the stream to the log file
        /// </summary>
        FileStream m_logFile;

        /// <summary>
        /// the writer stream to the log file
        /// </summary>
        StreamWriter m_Writer;

        /// <summary>
        /// open a stream to the log file
        /// </summary>
        public override void OpenLog()
        {
            m_logFile = File.Open(Directory.GetCurrentDirectory() + @"\LogFile_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt", FileMode.Append);
            m_Writer = new StreamWriter(m_logFile);
            m_Writer.AutoFlush = true;
        }


        /// <summary>
        /// close the log file stream
        /// </summary>
        public override void CloseLog()
        {
            m_logFile.Close();
        }

        /// <summary>
        /// write a log entry to the log file. the data is appended at the end of the file
        /// </summary>
        /// <param name="message">the log actual message</param>
        /// <param name="logLevel">the log level for this entry</param>
        /// <param name="userName">the connected user name</param>
        /// <param name="actionName">the action that sent the log entry</param>
        public override void WriteLogEntry(string message, Logger.LogLevelEnum logLevel, string userName, string actionName)
        {
            m_Writer.WriteLine(DateTime.Now.ToString() + ";" + userName + ";" + actionName + ";" + message + ";" + logLevel.ToString());
        }
    }
}
