using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerManagementBL.Entities;
using System.Data;
using System.Collections;
using VolunteerManagementDAL;

namespace VolunteerManagementBL
{
    /// <summary>
    /// this class provides the logic and methods needed for an reminder in the system.
    /// the diffrent methods get the request from the gui layer and
    /// execute all the needed operations to preform the requested logic.
    /// </summary>
    public class ReminderFacade : Facade
    {
        /// <summary>
        /// constructor for this class
        /// </summary>
        /// <param name="user">the active user logged into the system</param>
        public ReminderFacade(User user)
            : base(user)
        {
        }

        /// <summary>
        /// this method gets a single reminder data
        /// </summary>
        /// <param name="ReminderID">the requested reminder id</param>
        /// <returns>the requested reminder object</returns>
        public Reminder GetSingleReminderData(string ReminderID)
        {
            // run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery("select * from reminders where id = '" + ReminderID + "'", m_Connection);
            Close();
            if (result == null) 
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");

            if (result.Rows.Count != 1)
            {
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים, התקבל מספר רשומות שונה מאחד");
            }
            // parse the result and return the object
            DataRow row = result.Rows[0];

            Reminder answer = new Reminder(ReminderID, row["Content"].ToString(),
                Convert.ToDateTime(row["ReminderDate"].ToString()),
                Convert.ToBoolean(row["IsAttended"].ToString()),
                (Activity.TimingEnum)Enum.Parse(typeof(Activity.TimingEnum), row["CycleType"].ToString()),
                row["UserName"].ToString());

            return answer;
        }

        /// <summary>
        /// this method deletes a single reminder from the system
        /// </summary>
        /// <param name="ReminderID">the requested reminder id</param>
        /// <returns>number of rows affected</returns>
        public int DeleteReminder(string ReminderID)
        {
            // delete the reminder
            Init();
            int result = DBActions.ExecuteNonQuery("delete from reminders"
                + " where id = '" + ReminderID + "'"
                , m_Connection);
            Close();
            if (result == -1)
                throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");
            return result;
        }

        /// <summary>
        /// this method updates a single reminder data
        /// </summary>
        /// <param name="entity">the updated reminder data</param>
        /// <returns>number of rows affected</returns>
        public int UpdateReminderData(Reminder entity)
        {
            // update the reminder data
            Init();
            int result = DBActions.ExecuteNonQuery("update reminders set UserName = '" + entity.UserName + "',"
                + "Content = '" + entity.Content + "',"
                + "ReminderDate = '" + entity.ReminderTime.ToString() + "',"
                + "IsAttended = '" + entity.IsAttended.ToString() + "',"
                + "CycleType = '" + entity.Timing.ToString() + "'"
                + "where ID = '" + entity.ID + "'"
                , m_Connection);
            Close();
            if (result == -1)
                throw new Exception("כשלון בעדכון נתונים במאגר הנתונים");
            return result;
        }

        /// <summary>
        /// this method sets the reminder as not attended 
        /// and advances it to the next reminder time
        /// according to the cyclic timing of the reminder.
        /// if the reminder is not attended then move it to the next day
        /// </summary>
        /// <param name="entity">the entity to advance</param>
        /// <returns>the new advanced reminder</returns>
        public Reminder AdvanceReminder(Reminder entity)
        {
            // if the entity is already attended move it to the next
            // reminder date according to the cyclic timing of the reminder.
            if (entity.IsAttended)
            {
                do
                {
                    switch (entity.Timing)
                    {
                        case Activity.TimingEnum.חד_פעמי:
                            return entity;
                        case Activity.TimingEnum.חודשי:
                            entity.ReminderTime = entity.ReminderTime.AddMonths(1);
                            break;
                        case Activity.TimingEnum.יומי:
                            entity.ReminderTime = entity.ReminderTime.AddDays(1);
                            break;
                        case Activity.TimingEnum.רבעוני:
                            entity.ReminderTime = entity.ReminderTime.AddMonths(3);
                            break;
                        case Activity.TimingEnum.שבועי:
                            entity.ReminderTime = entity.ReminderTime.AddDays(7);
                            break;
                        case Activity.TimingEnum.שנתי:
                            entity.ReminderTime = entity.ReminderTime.AddYears(1);
                            break;
                    }
                } while (entity.ReminderTime.Date < DateTime.Now.Date);
                entity.IsAttended = false;
            }
            //if the reminder is not attended then move it to the next day
            else if (entity.ReminderTime.Date < DateTime.Now.Date)
            {
                entity.ReminderTime = DateTime.Now;
            }

            //update the reminder data
            Init();
            int result = DBActions.ExecuteNonQuery("update reminders set UserName = '" + entity.UserName + "',"
                + "Content = '" + entity.Content + "',"
                + "ReminderDate = '" + entity.ReminderTime.ToString() + "',"
                + "IsAttended = '" + entity.IsAttended.ToString() + "',"
                + "CycleType = '" + entity.Timing.ToString() + "'"
                + "where ID = '" + entity.ID + "'"
                , m_Connection);
            Close();
            if (result == -1)
                throw new Exception("כשלון בעדכון נתונים במאגר הנתונים");
            return entity;
        }

        /// <summary>
        /// this method adds a new reminder to the system
        /// </summary>
        /// <param name="entity">the new reminder object</param>
        /// <returns>the new reminder id</returns>
        public string AddNewReminder(Reminder entity)
        {
            // get a unique id and add it to the system
            Init();
            string ID = System.Guid.NewGuid().ToString();
            int result = DBActions.ExecuteNonQuery("insert into Reminders(ID,UserName,Content,ReminderDate,IsAttended,CycleType) "
                + "values('" + ID + "',"
                + "'" + entity.UserName + "',"
                + "'" + entity.Content + "',"
                + "'" + entity.ReminderTime.ToString() + "',"
                + "'" + entity.IsAttended.ToString() + "',"
                + "'" + entity.Timing.ToString() + "')"
                , m_Connection);
            Close();
            if (result == -1)
                throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
            return ID;
        }

        /// <summary>
        /// this method gets the reminder list using some filters
        /// </summary>
        /// <param name="UserName">return only reminders of this user</param>
        /// <param name="RequestedDate">return only reminders from this date</param>
        /// <param name="IsAttended">return only reminders of this status</param>
        /// <returns>the reminders list</returns>
        public Reminder[] GetReminderList(string UserName, DateTime RequestedDate, int IsAttended)
        {
            // build the select query with the filters
            string sql = "";
            if (UserName == "" && RequestedDate.Year == 1 && IsAttended < 0)
                sql = "select * from reminders";
            else
            {
                sql = "select * from reminders "
                + "where id = id";
                if (UserName != "")
                    sql += " and UserName = '" + UserName + "'";
                if (RequestedDate.Year != 1)
                    sql += " and ReminderDate like '%" + RequestedDate.ToShortDateString() + "%'";
                if (IsAttended == 0)
                    sql += " and IsAttended = 'False'";
                else if (IsAttended == 1)
                    sql += " and IsAttended = 'True'";
            }
            // run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery(sql, m_Connection);
            Close();
            if (result == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");

            //parse the results and return the result array
            Reminder[] array = new Reminder[result.Rows.Count];

            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow row = result.Rows[i];
                Reminder current = new Reminder(row["ID"].ToString(), row["Content"].ToString(),
                                Convert.ToDateTime(row["ReminderDate"].ToString()),
                                Convert.ToBoolean(row["IsAttended"].ToString()),
                                (Activity.TimingEnum)Enum.Parse(typeof(Activity.TimingEnum), row["CycleType"].ToString()),
                                row["UserName"].ToString());
                array[i] = current;
            }

            return array;
        }
    }
}
