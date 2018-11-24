using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementBL.Entities
{
    /// <summary>
    /// describes an entity of type Reminder. a reminder can be linked to only one user.
    /// the reminder includes a textual content and requires the attention of the user
    /// to change it`s status
    /// </summary>
    public class Reminder
    {
        /// <summary>
        /// constructor for a reminder
        /// </summary>
        /// <param name="ReminderID">the unique reminder id, the id is a guid</param>
        /// <param name="Content">the actual content of the reminder</param>
        /// <param name="ReminderTime">the date and time for the reminder</param>
        /// <param name="IsAttended">the status of the reminder - has it been attended by the user?</param>
        /// <param name="Timing">the cyclic timing definition for the reminder</param>
        /// <param name="UserName">the name of the user that created the reminder</param>
        public Reminder(string ReminderID, string Content, DateTime ReminderTime,
            bool IsAttended, Activity.TimingEnum Timing, string UserName)
        {
            m_ID = ReminderID;
            m_Content = Content;
            m_ReminderTime = ReminderTime;
            m_IsAttended = IsAttended;
            m_Timing = Timing;
            m_UserName = UserName;
        }

        /// <summary>
        /// the unique guid id for the reminder
        /// </summary>
        public string ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        private string m_ID;

        /// <summary>
        /// the actual content of the reminder
        /// </summary>
        public string Content
        {
            get { return m_Content; }
            set { m_Content = value; }
        }
        private string m_Content;

        /// <summary>
        /// the date and time for the reminder
        /// </summary>
        public DateTime ReminderTime
        {
            get { return m_ReminderTime; }
            set { m_ReminderTime = value; }
        }
        private DateTime m_ReminderTime;

        /// <summary>
        /// the attention status of the reminder - has it been attended by the user?
        /// </summary>
        public bool IsAttended
        {
            get { return m_IsAttended; }
            set { m_IsAttended = value; }
        }
        private bool m_IsAttended;

        /// <summary>
        /// the name of the user that created the reminder
        /// </summary>
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        private string m_UserName;

        /// <summary>
        /// the cyclic timing behavior of the reminder
        /// </summary>
        public Activity.TimingEnum Timing
        {
            get { return m_Timing; }
            set { m_Timing = value; }
        }
        private Activity.TimingEnum m_Timing;

        /// <summary>
        /// gets the reminder attention status and a preview of teh reminder`s content
        /// </summary>
        /// <returns>a string with the description of the reminder data</returns>
        public override string ToString()
        {
            int length = m_Content.Length;
            if (length > 40)
                length = 40;

            string content = m_Content.Substring(0, length);
            if (m_Content.Length > 40)
                content += "...";

            if (IsAttended)
                content += ", מטופלת";
            else
                content += ", לא טופלה";

            return content;
        }
    }
}
