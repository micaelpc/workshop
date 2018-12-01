using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymBL.Entities;
using System.Data;
using System.Collections;
using VolunteerManagementDAL;
using GymBL.Log;

namespace GymBL
{
    /// <summary>
    /// this class provides the logic and methods needed for an user in the system.
    /// the diffrent methods get the request from the gui layer and
    /// execute all the needed operations to preform the requested logic.
    /// </summary>
    public class UserFacade : Facade
    {
        /// <summary>
        /// constructor for this class
        /// </summary>
        /// <param name="user">the active user logged into the system</param>
        public UserFacade(User user)
            : base(user)
        {
        }

        /// <summary>
        /// this method gets a single user entity data
        /// </summary>
        /// <param name="userName">the requested user name</param>
        /// <returns>the requested user object</returns>
        public User GetSingleUserData(string userName)
        {
            // run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery("select * from users where UserName = '" + userName + "'", m_Connection);
            Close();
            if (result == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");

            if (result.Rows.Count != 1)
            {
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים, התקבל מספר רשומות שונה מאחד");
            }
            // parse the result and return it
            DataRow row = result.Rows[0];

            User answer = User.CreateUser((User.UserTypeEnum)Enum.Parse(typeof(User.UserTypeEnum), row["PermissionType"].ToString()),
                row["UserName"].ToString(),
                row["UserPassword"].ToString(),
                row["VolunteerID"].ToString());
            
            return answer;
        }

        /// <summary>
        /// this method gets the users list in the system 
        /// with some filters
        /// </summary>
        /// <param name="UserName">return only users with a user name like this</param>
        /// <param name="UserTypeName">return only users of this user type</param>
        /// <returns>the users list</returns>
        public User[] GetUserList(string UserName, string UserTypeName)
        {
            //User[] array = new User[0];
            // build the select query with filters
            string sql = "";
            if (UserName == "" && UserTypeName == "")
                sql = "select * from users";
            else
            {
                sql = "select * from users "
                + "where ID = ID";
                if (UserName != "")
                    sql += " and UserName like '%" + UserName + "%'";
                if (UserTypeName != "")
                    sql += " and PermissionType = '" + UserTypeName + "'";
            }

            // run the query
            Init();
            DataTable result = DBActions.ExecuteQuery(sql, m_Connection);
            Close();
            if (result == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");

            //parse the results and return the result array
            User[] array = new User[result.Rows.Count];

            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow row = result.Rows[i];
                User current = User.CreateUser((User.UserTypeEnum)Enum.Parse(typeof(User.UserTypeEnum), row["PermissionType"].ToString()),
                    row["UserName"].ToString(),
                    row["UserPassword"].ToString(),
                    row["VolunteerID"].ToString());
                array[i] = current;
            }

            return m_ActiveUser.FilterResults(array);
        }

        /// <summary>
        /// this method adds a new user entity to the system
        /// </summary>
        /// <param name="entity">the new user entity</param>
        /// <returns>number of rows affected</returns>
        public int AddNewUser(User entity)
        {
            // check if the user has permissions to create entities
            if (!CheckPermissions(User.ActionTypeEnum.ManageUsers))
                throw new Exception("למשתמש אין הרשאות מתאימות לניהול משתמשים");

            // add the new user
            Init();
            int result = DBActions.ExecuteNonQuery("insert into Users(VolunteerID,PermissionType,UserName,UserPassword) "
                + "values('" + entity.VolunteerID + "',"
                + "'" + entity.UserType.ToString() + "',"
                + "'" + entity.UserName + "',"
                + "'" + entity.Password + "')"
                , m_Connection);
            Close();
            if (result == -1)
                throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
            return result;
        }

        /// <summary>
        /// this method deletes a single user from the system
        /// </summary>
        /// <param name="entity">the entity to delete</param>
        /// <param name="deleteLinkedVolunteer">if true delete also the linked volunteer</param>
        /// <returns>number of rows affected</returns>
        public int DeleteUser(User entity, bool deleteLinkedVolunteer)
        {
            // check if the user has permissions to delete entities
            if (!CheckPermissions(User.ActionTypeEnum.ManageUsers))
                throw new Exception("למשתמש אין הרשאות מתאימות לניהול משתמשים");

            // delete the user data
            Init();
            int result = DBActions.ExecuteNonQuery("delete from reminders"
                + " where UserName = '" + entity.UserName + "'"
                , m_Connection);

            result = DBActions.ExecuteNonQuery("delete from users"
                + " where UserName = '" + entity.UserName + "'"
                , m_Connection);
            Close();
            if (result == -1)
                throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");

            // if the user requested delete also the linked volunteers
            if (deleteLinkedVolunteer)
            {
                VolunteerFacade facade = new VolunteerFacade(m_ActiveUser);
                facade.DeleteVolunteer(entity.VolunteerID);
            }
            
            return result;
        }

        /// <summary>
        /// this method updates one user data
        /// </summary>
        /// <param name="entity">the updated user data</param>
        /// <returns>number of rows affected</returns>
        public int UpdateUserData(User entity)
        {
            // check if the user has permissions to update entities
            if (!CheckPermissions(User.ActionTypeEnum.UpdateEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות לעדכון הישות");

            // check if the user can change the user type - only an admin can do that
            if (m_ActiveUser.UserType != User.UserTypeEnum.מנהל
                && entity.UserType != m_ActiveUser.UserType)
                throw new Exception("למשתמש אין הרשאות מתאימות לניהול משתמשים");
            // update the data
            Init();
            int result = DBActions.ExecuteNonQuery("update Users set VolunteerID = '" + entity.VolunteerID + "',"
                + "PermissionType = '" + entity.UserType.ToString() + "',"
                + "UserPassword = '" + entity.Password + "'"
                + "where UserName = '" + entity.UserName + "'"
                , m_Connection);
            Close();
            if (result == -1)
                throw new Exception("כשלון בעדכון נתונים במאגר הנתונים");
            return result;
        }

        /// <summary>
        /// this method logs into the system.
        /// it first inits the system shared resources 
        /// and then verifies the user identity
        /// </summary>
        /// <param name="UserName">the user name</param>
        /// <param name="Password">the user password</param>
        /// <returns>true if successful login else false</returns>
        public bool LoginUser(string UserName, string Password)
        {
            // load the config file
            try
            {
                ConfigurationManager.LoadConfigurationFile();
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("כשלון בקריאת קובץ ההגדרות של המערכת: " + e.Message, Logger.LogLevelEnum.Errors, m_ActiveUser.UserName, "LoadConfigurationFile");
                throw new Exception("כשלון בקריאת קובץ ההגדרות של המערכת");
            }

            // open the connection to the db
            string dbPath = ConfigurationManager.GetConfigValue("DBPath");
            string numOfConnections = ConfigurationManager.GetConfigValue("NumberOfDBConnections");
            if (dbPath != ""
                && numOfConnections != "")
            {
                ConnectionQueue.Instance.SetDBPath(dbPath);
                ConnectionQueue.Instance.InitConnections(Convert.ToInt32(numOfConnections));
            }
            else throw new Exception("כשלון בקריאת קובץ ההגדרות של המערכת");

            // open the system loggers
            try
            {
                LogManager.Instance.InitLoggers();
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("כשלון ביצירת לוגים: " + e.Message, Logger.LogLevelEnum.Errors, m_ActiveUser.UserName, "InitLoggers");
                throw new Exception("כשלון ביצירת לוגים: " + e.Message, e);
            }

            // check the user password
            Init();
            object result = DBActions.ExecuteScalar("select UserPassword from Users "
                + "where UserName = '" + UserName + "'"
                , m_Connection);
            Close();

            if (result == null)
                return false;
            else
            {
                // check if the password if correct
                if (result.ToString() == Password)
                {
                    ReminderFacade facade = new ReminderFacade(m_ActiveUser);
                    Reminder[] array = facade.GetReminderList(UserName,new DateTime(1,1,1),-1);
                    foreach (Reminder current in array)
                    {
                        facade.AdvanceReminder(current);
                    }
                    LogManager.Instance.WriteEntry("כניסה מוצלחת למערכת",
                        Logger.LogLevelEnum.Info, UserName, "Login");
                    return true;
                }
                else return false;
            }
        }

        /// <summary>
        /// this method loggs off from the system and closes the shared resources of the system
        /// </summary>
        public void LogoffUser()
        {
            ConnectionQueue.Instance.CloseConnections();
            LogManager.Instance.CloseLoggers();
        }
    }
}
