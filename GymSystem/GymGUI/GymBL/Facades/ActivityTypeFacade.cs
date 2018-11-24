using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerManagementBL.Entities;
using VolunteerManagementDAL;
using System.Data;

namespace VolunteerManagementBL
{
    /// <summary>
    /// this class provides the logic and methods needed for an activityType in the system.
    /// the diffrent methods get the request from the gui layer and
    /// execute all the needed operations to preform the requested logic.
    /// </summary>
    public class ActivityTypeFacade : Facade
    {
        /// <summary>
        /// constructor for this class
        /// </summary>
        /// <param name="user">the active user logged into the system</param>
        public ActivityTypeFacade(User user)
            : base(user)
        {
        }

        /// <summary>
        /// this method gets the list of activity types in the system
        /// </summary>
        /// <returns>the list of activity types</returns>
        public ActivityType[] GetActivityTypesList()
        {
            // run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery("select * from activitytypes", m_Connection);

            if (result == null)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }

            // parse the results and return it
            ActivityType[] array = new ActivityType[result.Rows.Count];

            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow row = result.Rows[i];

                ActivityType current = new ActivityType(Convert.ToInt32(row["ID"]), row["Description"].ToString(), row["ActivityTypeName"].ToString(), row["Location"].ToString());
                array[i] = current;
            }

            Close();
            return array;
        }

        /// <summary>
        /// this method gets a single activity type data
        /// </summary>
        /// <param name="ID">the id of the activity type</param>
        /// <returns>the requested activity type object</returns>
        public ActivityType GetSingleActivityType(int ID)
        {
            // run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery("select * from activitytypes where id = " + ID, m_Connection);
            if (result == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            Close();

            if (result.Rows.Count != 1)
            {
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים, התקבל מספר רשומות שונה מאחד");
            }
            // parse the result and return it
            DataRow row = result.Rows[0];
            ActivityType current = new ActivityType(Convert.ToInt32(row["ID"]), row["Description"].ToString(), row["ActivityTypeName"].ToString(), row["Location"].ToString());
            
            return current;
        }

        /// <summary>
        /// this method updates the activity type data
        /// </summary>
        /// <param name="entity">the entity updated data</param>
        /// <returns>the number of rows affected</returns>
        public int UpdateActivityTypeData(ActivityType entity)
        {
            //check if the user has permissions to update entities
            if (!CheckPermissions(User.ActionTypeEnum.UpdateEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות לעדכון הישות");

            // update the entity data
            Init();
            int result = DBActions.ExecuteNonQuery("update Activitytypes set Description = '" + entity.Description + "',"
                + "Location = '" + entity.Location + "',"
                + "ActivityTypeName = '" + entity.ActivityTypeName + "'"
                + "where id = " + entity.ID
                , m_Connection);
            Close();
            if (result == -1)
                throw new Exception("כשלון בעדכון נתונים במאגר הנתונים");
            return result;
        }

        /// <summary>
        /// this method adds a new activity type to the system
        /// </summary>
        /// <param name="entity">the new activity type object</param>
        /// <returns>the number of rows affected</returns>
        public int AddNewActivityType(ActivityType entity)
        {
            // check if the user has permissions to create entities
            if (!CheckPermissions(User.ActionTypeEnum.CreateEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות ליצירת ישות");

            // add the new entity data
            Init();
            int result = DBActions.ExecuteNonQuery("insert into Activitytypes(Description,Location,ActivityTypeName) "
                + "values('" + entity.Description + "',"
                + "'" + entity.Location + "',"
                + "'" + entity.ActivityTypeName + "')"
                , m_Connection);
            Close();
            if (result == -1)
                throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
            return result;
        }

        /// <summary>
        /// this method deletes an activity type from the system
        /// </summary>
        /// <param name="ID">the id of the activity type to delete</param>
        /// <returns>number of rows affected</returns>
        public int DeleteActivityType(int ID)
        {
            // check if the user has permissions to delete entities
            if (!CheckPermissions(User.ActionTypeEnum.DeleteEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות למחיקת הישות");

            // check if this activity type is assigned to a volunteer or activity
            // if so, don`t delete the activity type
            Init();
            int numOfActivities = (int)DBActions.ExecuteScalar("select count(*) from activities"
                + " where activityType = " + ID
                , m_Connection);
            if (numOfActivities == -1)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }
            int numOfVolunteers = (int)DBActions.ExecuteScalar("select count(*) from volunteerActivityTypes"
                + " where activityTypeID = " + ID
                , m_Connection);
            if (numOfVolunteers == -1)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }

            if (numOfActivities > 0 || numOfVolunteers > 0)
            {
                Close();
                throw new Exception("לא ניתן למחוק סוג פעילות. סוג זה מקושר לפחות לפעילות אחת או מתנדב אחד");
            }
            // deletet the entity
            int result = DBActions.ExecuteNonQuery("delete from activitytypes"
                + " where id = " + ID
                , m_Connection);
            if (result == -1)
            {
                Close();
                throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");
            }
            Close();
            return result;
        }
    }
}
