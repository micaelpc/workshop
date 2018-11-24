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
    /// this class provides the logic and methods needed for an activity in the system.
    /// the diffrent methods get the request from the gui layer and
    /// execute all the needed operations to preform the requested logic.
    /// </summary>
    public class ActivityFacade : Facade
    {
        /// <summary>
        /// constructor for this class
        /// </summary>
        /// <param name="user">the active user logged into the system</param>
        public ActivityFacade(User user)
            : base(user)
        {
        }

        /// <summary>
        /// this method gets all the dates that has at least one activity in the system
        /// </summary>
        /// <returns></returns>
        public DateTime[] GetActivitiesDates()
        {
            // run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery("select distinct(format(startdate,'dd/mm/yyyy')) from activities", m_Connection);
            Close();

            if (result == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");

            //parse the result and return the date array
            DateTime[] array = new DateTime[result.Rows.Count];

            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow row = result.Rows[i];
                DateTime current = Convert.ToDateTime(row[0].ToString());
                array[i] = current;
            }
            
            return array;
        }

        /// <summary>
        /// this method gets the activities in a specific date
        /// </summary>
        /// <param name="date">the requested date</param>
        /// <returns>the list of activities</returns>
        public Activity[] GetActivityListByDate(DateTime date)
        {
            // run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery("select * from activities,ActivityTiming where activities.timingTypeID = ActivityTiming.id and format(startdate,'dd/mm/yyyy') = '" + date.Date.ToShortDateString() + "'",m_Connection);

            if (result == null)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }

            // parse the results and create the activities array
            Activity[] array = new Activity[result.Rows.Count];

            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow row = result.Rows[i];
                DataTable activityTypeTable = DBActions.ExecuteQuery("select * from activitytypes where id = " + row["ActivityType"].ToString(), m_Connection);
                if (result == null)
                {
                    Close();
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                }

                DataRow typeRow = activityTypeTable.Rows[0];

                Activity current = new Activity(Convert.ToInt32(row["activities.ID"]), row["Description"].ToString(),
                    Convert.ToDateTime(row["StartDate"].ToString()),
                    Convert.ToDateTime(row["EndDate"].ToString()),
                    row["Location"].ToString(),
                    new ActivityType(Convert.ToInt32(typeRow["ID"]), typeRow["Description"].ToString(), typeRow["ActivityTypeName"].ToString(), typeRow["Location"].ToString()),
                    (Activity.TimingEnum)Enum.Parse(typeof(Activity.TimingEnum), row["TimingType"].ToString()),
                    Convert.ToDateTime(row["FinishDate"].ToString()));
                array[i] = current;
            }

            Close();
            // filter the array before returning the results
            return m_ActiveUser.FilterResults(array);
        }

        /// <summary>
        /// this method gets the activities in a specific date range
        /// </summary>
        /// <param name="startDate">start date for the activity range</param>
        /// <param name="endDate">end date for the activity range</param>
        /// <returns>the activity list</returns>
        public Activity[] GetActivityListByDateRange(DateTime startDate, DateTime endDate)
        {
            // run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery("select * from activities,ActivityTiming where activities.timingTypeID = ActivityTiming.id"
            + " and StartDate > DateValue('" + startDate.ToShortDateString() + "')"
            + " and EndDate < DateValue('" + endDate.ToShortDateString() + "')"
            + " order by StartDate"
            ,m_Connection);

            if (result == null)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }

            // parse the results and create the activities array
            Activity[] array = new Activity[result.Rows.Count];

            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow row = result.Rows[i];
                DataTable activityTypeTable = DBActions.ExecuteQuery("select * from activitytypes where id = " + row["ActivityType"].ToString(), m_Connection);
                if (activityTypeTable == null)
                {
                    Close();
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                }

                DataRow typeRow = activityTypeTable.Rows[0];

                Activity current = new Activity(Convert.ToInt32(row["activities.ID"]), row["Description"].ToString(),
                    Convert.ToDateTime(row["StartDate"].ToString()),
                    Convert.ToDateTime(row["EndDate"].ToString()),
                    row["Location"].ToString(),
                    new ActivityType(Convert.ToInt32(typeRow["ID"]), typeRow["Description"].ToString(), typeRow["ActivityTypeName"].ToString(), typeRow["Location"].ToString()),
                    (Activity.TimingEnum)Enum.Parse(typeof(Activity.TimingEnum), row["TimingType"].ToString()),
                    Convert.ToDateTime(row["FinishDate"].ToString()));
                array[i] = current;
            }

            Close();
            // filter the array before returning the results
            return m_ActiveUser.FilterResults(array);
        }

        /// <summary>
        /// this method gets a single activity data
        /// </summary>
        /// <param name="ActivityID">the requested activity id</param>
        /// <returns>the requested activity object</returns>
        public Activity GetSingleActivityData(int ActivityID)
        {
            // run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery("select * from activities,ActivityTiming where activities.timingTypeID = ActivityTiming.id and activities.id = " + ActivityID, m_Connection);

            if (result == null)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }

            if (result.Rows.Count != 1)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים, התקבל מספר רשומות שונה מאחד");
            }
            DataRow generalDataRow = result.Rows[0];

            result = DBActions.ExecuteQuery("select b.* from volunteeractivitylog a ,volunteers b where a.activityID = " + ActivityID + " and a.volunteerid = b.idnumber", m_Connection);

            if (result == null)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }
            // get the volunteers assigned to the activity
            Volunteer[] array = new Volunteer[result.Rows.Count];

            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow row = result.Rows[i];
                Volunteer current = new Volunteer(row["IDNumber"].ToString(),
                    row["Firstname"].ToString(), row["Surname"].ToString(), row["Address"].ToString(),
                    row["HomePhone"].ToString(), row["CellPhone"].ToString(), row["EMail"].ToString(),
                    Convert.ToDateTime(row["Birthdate"].ToString()), row["Comment"].ToString(),
                    (Volunteer.VolunteerTypeEnum)row["VolunteerType"]);
                array[i] = current;
            }

            // get the activity type object
            DataTable activityTypeTable = DBActions.ExecuteQuery("select * from activitytypes where id = " + generalDataRow["ActivityType"].ToString(), m_Connection);
            if (activityTypeTable == null
                || activityTypeTable.Rows.Count == 0)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }

            DataRow typeRow = activityTypeTable.Rows[0];

            // create the activity object and return in
            Activity activity = new Activity(Convert.ToInt32(generalDataRow["activities.ID"]), generalDataRow["Description"].ToString(),
            Convert.ToDateTime(generalDataRow["StartDate"].ToString()),
                Convert.ToDateTime(generalDataRow["EndDate"].ToString()),
            generalDataRow["Location"].ToString(),
            new ActivityType(Convert.ToInt32(typeRow["ID"]), typeRow["Description"].ToString(), typeRow["ActivityTypeName"].ToString(), typeRow["Location"].ToString()),
            (Activity.TimingEnum)Enum.Parse(typeof(Activity.TimingEnum), generalDataRow["TimingType"].ToString()),
            Convert.ToDateTime(generalDataRow["FinishDate"].ToString()),
            array);
            
            Close();
            return activity;
        }

        /// <summary>
        /// this method updates the data for a single activity
        /// </summary>
        /// <param name="entity">the entity data for updating</param>
        /// <param name="changeTiming">if true then a new series of activities is created, if false only a single activity will be affected</param>
        /// <returns>the number of rows affected</returns>
        public int UpdateActivityData(Activity entity, bool changeTiming)
        {
            // check if the user has permissions for update operation
            if (!CheckPermissions(User.ActionTypeEnum.UpdateEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות לעדכון הישות");

            //update the activity data
            Init();
            int result = DBActions.ExecuteNonQuery("update Activities set Description = '" + entity.Description + "',"
                + "StartDate = '" + entity.StartDate.ToString() + "',"
                + "EndDate = '" + entity.EndDate.ToString() + "',"
                + "Location = '" + entity.Location + "',"
                + "ActivityType = '" + entity.Type.ID + "'"
                + " where id = " + entity.ID
                , m_Connection);

            if (result == -1)
            {
                Close();
                throw new Exception("כשלון בעדכון נתונים במאגר הנתונים");
            }

            // update the activity`s volunteer list
            result = DBActions.ExecuteNonQuery("delete from volunteeractivitylog where activityid = " + entity.ID, m_Connection);

            if (result == -1)
                throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");

            foreach (Volunteer current in entity.Volunteers)
            {
                result = DBActions.ExecuteNonQuery("insert into volunteeractivitylog(VolunteerID,ActivityID) "
                + "values('" + current.IDNumber + "',"
                + entity.ID + ")"
                , m_Connection);

                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
                }
            }

            // update the activity series if the user requested to
            if (changeTiming)
            {
                object timingIDResult = DBActions.ExecuteScalar("select timingtypeid from activities where id = " + entity.ID, m_Connection);
                if (timingIDResult == null)
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                int timingID = (int)timingIDResult;

                // update the activity cyclic timing
                result = DBActions.ExecuteNonQuery("update Activitytiming set timingType = '" + entity.TimingType.ToString() + "',"
                + "FinishDate = '" + entity.ActivityTimingFinishDate.ToString() + "',"
                + "BaseActivityID = " + entity.ID
                + " where id = " + timingID
                , m_Connection);

                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון בעדכון נתונים במאגר הנתונים");
                }

                // delete the old activity series
                DataTable activitiesToDelete = DBActions.ExecuteQuery("select * from activities where timingTypeID = " + timingID + " and startDate > DateValue('" + entity.StartDate.AddDays(1).ToString() + "')", m_Connection);

                if (activitiesToDelete == null)
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");

                for (int i = 0; i < activitiesToDelete.Rows.Count; i++)
                {
                    DeleteActivity(Convert.ToInt32(activitiesToDelete.Rows[i]["ID"]),false);
                }

                // create the new activity series
                while (entity.StartDate.CompareTo(entity.ActivityTimingFinishDate) < 0)
                {
                    switch (entity.TimingType)
                    {
                        case Activity.TimingEnum.חד_פעמי:
                            entity.StartDate = entity.ActivityTimingFinishDate;
                            continue;
                        case Activity.TimingEnum.חודשי:
                            entity.StartDate = entity.StartDate.AddMonths(1);
                            entity.EndDate = entity.EndDate.AddMonths(1);
                            break;
                        case Activity.TimingEnum.יומי:
                            entity.StartDate = entity.StartDate.AddDays(1);
                            entity.EndDate = entity.EndDate.AddDays(1);
                            break;
                        case Activity.TimingEnum.רבעוני:
                            entity.StartDate = entity.StartDate.AddMonths(3);
                            entity.EndDate = entity.EndDate.AddMonths(1);
                            break;
                        case Activity.TimingEnum.שבועי:
                            entity.StartDate = entity.StartDate.AddDays(7);
                            entity.EndDate = entity.EndDate.AddDays(7);
                            break;
                        case Activity.TimingEnum.שנתי:
                            entity.StartDate = entity.StartDate.AddYears(1);
                            entity.EndDate = entity.EndDate.AddYears(1);
                            break;
                    }

                    AddNewActivity(entity,timingID);
                }
            }

            Close();
            return result;
        }

        /// <summary>
        /// this method adds new activity to the system.
        /// the activity can be part of an activity series identified
        /// by the timing id
        /// </summary>
        /// <param name="entity">the new activity data</param>
        /// <param name="timingID">the activity series timing id</param>
        /// <returns>the number of rows affected</returns>
        public int AddNewActivity(Activity entity, int timingID)
        {
            // check if the user has permissions to add entities
            if (!CheckPermissions(User.ActionTypeEnum.CreateEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות ליצירת ישות");

            Init();
            int result=0;

            // if the activity is part of a series add it to the db
            if (timingID >= 0)
            {
                result = DBActions.ExecuteNonQuery("insert into Activities(Description,StartDate,EndDate,Location,ActivityType,TimingTypeID) "
                    + "values('" + entity.Description + "',"
                    + "'" + entity.StartDate.ToString() + "',"
                    + "'" + entity.EndDate.ToString() + "',"
                    + "'" + entity.Location + "',"
                    + "" + entity.Type.ID + ","
                    + "" + timingID + ")"
                    , m_Connection);

                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
                }
            }
                // if the activity isn`t part of a series create the activity and check
                // if it is the first of a series
            else
            {
                Random rand = new Random();
                int guid = rand.Next(-1000,-1);
                //int guid = -1;// Convert.ToInt32(System.Guid.NewGuid().ToString("N"));

                result = DBActions.ExecuteNonQuery("insert into activityTiming(TimingType,FinishDate,BaseActivityID) "
                        + "values('" + entity.TimingType.ToString() + "',"
                        + "'" + entity.ActivityTimingFinishDate.ToString() + "',"
                        + guid + ")"
                        , m_Connection);

                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
                }

                object timingIDResult = DBActions.ExecuteScalar("select id from activitytiming where baseactivityid = " + guid, m_Connection);
                if (timingIDResult == null)
                {
                    Close();
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                }
                timingID = (int)timingIDResult;
                // create the new activity data
                result = DBActions.ExecuteNonQuery("insert into Activities(Description,StartDate,EndDate,Location,ActivityType,TimingTypeID) "
                        + "values('" + entity.Description + "',"
                        + "'" + entity.StartDate.ToString() + "',"
                        + "'" + entity.EndDate.ToString() + "',"
                        + "'" + entity.Location + "',"
                        + "" + entity.Type.ID + ","
                        + "" + timingID + ")"
                        , m_Connection);

                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
                }

                // add the assigned volunteers data
                foreach (Volunteer current in entity.Volunteers)
                {
                    result = DBActions.ExecuteNonQuery("insert into volunteeractivitylog(VolunteerID,ActivityID) "
                    + "values('" + current.IDNumber + "',"
                    + entity.ID + ")"
                    , m_Connection);

                    if (result == -1)
                    {
                        Close();
                        throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
                    }
                }

                object activityIDResult = DBActions.ExecuteScalar("select id from activities where timingtypeid = " + timingID, m_Connection);
                if (activityIDResult == null)
                {
                    Close();
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                }
                int activityID = (int)activityIDResult;
                entity.ID = activityID;

                result = DBActions.ExecuteNonQuery("update Activitytiming set timingType = '" + entity.TimingType.ToString() + "',"
                + "FinishDate = '" + entity.ActivityTimingFinishDate.ToString() + "',"
                + "BaseActivityID = " + entity.ID
                + " where id = " + timingID
                , m_Connection);

                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון בעדכון נתונים במאגר הנתונים");
                }

                // check if the activity is the first in a series then add
                // the required activities
                while (entity.StartDate.CompareTo(entity.ActivityTimingFinishDate) < 0)
                {
                    switch (entity.TimingType)
                    {
                        case Activity.TimingEnum.חד_פעמי:
                            entity.StartDate = entity.ActivityTimingFinishDate;
                            continue;
                        case Activity.TimingEnum.חודשי:
                            entity.StartDate = entity.StartDate.AddMonths(1);
                            entity.EndDate = entity.EndDate.AddMonths(1);
                            break;
                        case Activity.TimingEnum.יומי:
                            entity.StartDate = entity.StartDate.AddDays(1);
                            entity.EndDate = entity.EndDate.AddDays(1);
                            break;
                        case Activity.TimingEnum.רבעוני:
                            entity.StartDate = entity.StartDate.AddMonths(3);
                            entity.EndDate = entity.EndDate.AddMonths(1);
                            break;
                        case Activity.TimingEnum.שבועי:
                            entity.StartDate = entity.StartDate.AddDays(7);
                            entity.EndDate = entity.EndDate.AddDays(7);
                            break;
                        case Activity.TimingEnum.שנתי:
                            entity.StartDate = entity.StartDate.AddYears(1);
                            entity.EndDate = entity.EndDate.AddYears(1);
                            break;
                    }

                    AddNewActivity(entity, timingID);
                }
            }
            Close();
            return result;
        }

        /// <summary>
        /// this method deletes the activity data from the system
        /// </summary>
        /// <param name="ID">the activity`s id to erase</param>
        /// <param name="deleteActivitySeries">if the activity is part of a series then if this is true delete the series</param>
        /// <returns>number of rows affected</returns>
        public int DeleteActivity(int ID, bool deleteActivitySeries)
        {
            // check if the user has permissions to delete entities
            if (!CheckPermissions(User.ActionTypeEnum.DeleteEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות למחיקת הישות");

            Init();
            int result = 0;
            // check if the user requested to delete the series of this activity
            if (deleteActivitySeries)
            {
                Activity activity = GetSingleActivityData(ID);

                object timingIDResult = DBActions.ExecuteScalar("select timingtypeid from activities where id = " + ID, m_Connection);
                if (timingIDResult == null)
                {
                    Close();
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                }
                int timingID = (int)timingIDResult;

                DataTable activitiesToDelete = DBActions.ExecuteQuery("select * from activities where timingTypeID = " + timingID + " and startDate > DateValue('" + activity.StartDate.AddDays(1).ToString() + "')", m_Connection);

                if (activitiesToDelete == null)
                {
                    Close();
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                }

                for (int i = 0; i < activitiesToDelete.Rows.Count; i++)
                {
                    DeleteActivity(Convert.ToInt32(activitiesToDelete.Rows[i]["ID"]), false);
                }

                result = activitiesToDelete.Rows.Count;
            }
                // delete only this single activity
            else
            {
                result = DBActions.ExecuteNonQuery("delete from volunteerActivityLog"
                    + " where activityid = " + ID
                    , m_Connection);
                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");
                }
                result = DBActions.ExecuteNonQuery("delete from activities"
                    + " where id = " + ID
                    , m_Connection);
                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");
                }
            }
            Close();
            return result;
        }
    }
}
