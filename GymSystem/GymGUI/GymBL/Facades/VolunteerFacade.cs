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
    /// this class provides the logic and methods needed for an volunteer in the system.
    /// the diffrent methods get the request from the gui layer and
    /// execute all the needed operations to preform the requested logic.
    /// </summary>
    public class VolunteerFacade : Facade
    {
        /// <summary>
        /// constructor for this class
        /// </summary>
        /// <param name="user">the active user logged into the system</param>
        public VolunteerFacade(User user)
            : base(user)
        {
        }

        /// <summary>
        /// this method counts the number of volunteers in the db
        /// </summary>
        /// <returns>the number of volunteers in the db</returns>
        public int CountAllVolunteers()
        {
            // count the volunteers
            Init();
            object resultObject = DBActions.ExecuteScalar("select count(*) from volunteers",m_Connection);
            Close();
            if (resultObject == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            int result = (int)resultObject;
            
            return result;
        }

        /// <summary>
        /// this method gets the volunteers list using some filters
        /// </summary>
        /// <param name="ID">return only volunteers with id like that</param>
        /// <param name="Name">return only volunteers with name like that</param>
        /// <param name="activityType">return only volunteers with this activity type</param>
        /// <param name="availabilityTime">return only volunteers that are available at this time</param>
        /// <param name="RegistrationStartDate">return only volunteers that were registared after this date</param>
        /// <param name="RegistrationFinishDate">return only volunteers that were registared before this date</param>
        /// <param name="match">true returns the volunteers that match the filters and false return the other volunteers</param>
        /// <returns>the volunteers list</returns>
        public Volunteer[] GetVolunteerList(string ID, string Name, ActivityType activityType, VolunteerAvailabilityTime availabilityTime, DateTime RegistrationStartDate, DateTime RegistrationFinishDate, bool match)
        {
            // build the select query with filters
            Volunteer[] array = new Volunteer[0];
            string sql = "";
            if (ID == "" && Name == "" && activityType == null && availabilityTime == null
                && RegistrationFinishDate.Year == 1 && RegistrationStartDate.Year == 1)
                sql = "select distinct(idnumber) from volunteers";
            else
            {
                sql = "select distinct(idnumber) from volunteers,volunteerActivityTypes "
                + "where volunteers.idnumber = volunteerActivityTypes.volunteerid";
                if (ID != "")
                    sql += " and idnumber like '%" + ID + "%'";
                if (Name != "")
                    sql += " and (firstname like '%" + Name + "%' or surname like '%" + Name + "%')";
                if (activityType != null)
                    sql += " and activityTypeID = " + activityType.ID;
                if (RegistrationStartDate.Year != 1)
                    sql += " and RegistrationDate > DateValue('" + RegistrationStartDate.ToShortDateString() + "')";
                if (RegistrationFinishDate.Year != 1)
                    sql += " and RegistrationDate < DateValue('" + RegistrationFinishDate.ToShortDateString() + "')";
                if (availabilityTime != null)
                    sql += " and (idnumber in "
                            + "(select distinct(volunteerid) from volunteeravailabilitytime "
                            + "where DayofWeek = '" + availabilityTime.Day.ToString() + "'"
                            + " and StartTime <= " + availabilityTime.StartTime
                            + " and EndTime >= " + availabilityTime.EndTime
                            + ") or idnumber not in (select distinct(volunteerid) from volunteeravailabilitytime))";
            }
            //execute the select query
            Init();
            DataTable result = DBActions.ExecuteQuery(sql, m_Connection);
            Close();
            if (result == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");

            //parse the results to an array
            array = new Volunteer[result.Rows.Count];

            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow row = result.Rows[i];
                Volunteer current = GetSingleVolunteerData(row[0].ToString());
                array[i] = current;
            }

            // if the user requested the volunteers who don`t match 
            // find which volunteers don`t appear in the result array
            if (match)
                // filter the array before returning the results
                return m_ActiveUser.FilterResults(array);
            else
            {
                Volunteer[] allVolunteers = GetVolunteerList("", "", null, null, new DateTime(1, 1, 1), new DateTime(1, 1, 1), true);
                ArrayList finalList = new ArrayList();
                foreach (Volunteer v in allVolunteers)
                {
                    bool found = false;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].IDNumber == v.IDNumber)
                        {
                            found = true;
                        }
                    }
                    if (!found)
                        finalList.Add(v);
                }
                Volunteer[] finalArray = (Volunteer[])finalList.ToArray(typeof(Volunteer));
                // filter the array before returning the results
                return m_ActiveUser.FilterResults(finalArray);
            }
        }

        /// <summary>
        /// this method gets a single volunteer data
        /// </summary>
        /// <param name="ID">the requested volunteer id</param>
        /// <returns>the requested volunteer object</returns>
        public Volunteer GetSingleVolunteerData(string ID)
        {
            //run the select query
            Init();
            DataTable result = DBActions.ExecuteQuery("select * from volunteers,VolunteerType where IDNumber = '" + ID + "' and volunteers.VolunteerType = VolunteerType.id", m_Connection);
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
            // parse the result 
            DataRow generalDataRow = result.Rows[0];

            result = DBActions.ExecuteQuery("select b.*,c.* from volunteeractivitylog a ,activities b, activityTiming c where a.volunteerID = '" + ID + "' and a.activityid = b.id and b.timingTypeid = c.id", m_Connection);
            if (result == null)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }

            // get the activity log for the current volunteer
            Activity[] activityLog = new Activity[result.Rows.Count];
            for (int i=0; i<result.Rows.Count;i++)
            {
                DataRow activityLogDataRow  = result.Rows[i];
                DataTable activityTypeTable = DBActions.ExecuteQuery("select * from activitytypes where id = " + activityLogDataRow["ActivityType"].ToString(), m_Connection);
                if (activityTypeTable == null)
                {
                    Close();
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                }

                DataRow typeRow = activityTypeTable.Rows[0];

                Activity currentActivity = new Activity(Convert.ToInt32(activityLogDataRow["b.ID"]), 
                    activityLogDataRow["Description"].ToString(),
                    Convert.ToDateTime(activityLogDataRow["StartDate"].ToString()),
                    Convert.ToDateTime(activityLogDataRow["EndDate"].ToString()),
                    activityLogDataRow["Location"].ToString(),
                    new ActivityType(Convert.ToInt32(typeRow["ID"]), typeRow["Description"].ToString(), typeRow["ActivityTypeName"].ToString(), typeRow["Location"].ToString()),
                    Activity.TimingEnum.חד_פעמי,
                    Convert.ToDateTime(activityLogDataRow["FinishDate"].ToString()));

                activityLog[i] = currentActivity;
            }

            // get the activity types for this volunteer
            result = DBActions.ExecuteQuery("select * from volunteeractivitytypes where volunteerID = '" + ID + "'", m_Connection);
            if (result == null)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }

            ActivityType[] activityTypes = new ActivityType[result.Rows.Count];
            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow activityTypeDataRow = result.Rows[i];
                DataTable activityTypeTable = DBActions.ExecuteQuery("select * from activitytypes where id = " + activityTypeDataRow["ActivityTypeID"].ToString(), m_Connection);
                if (activityTypeTable == null)
                {
                    Close();
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                }

                DataRow typeRow = activityTypeTable.Rows[0];

                ActivityType currentActivityType =
                    new ActivityType(Convert.ToInt32(typeRow["ID"]), typeRow["Description"].ToString(), typeRow["ActivityTypeName"].ToString(), typeRow["Location"].ToString());

                activityTypes[i] = currentActivityType;
            }

            // get the volunteer`s availability times
            result = DBActions.ExecuteQuery("select * from volunteeravailabilitytime where volunteerID = '" + ID + "'", m_Connection);
            if (result == null)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }

            VolunteerAvailabilityTime[] availabilityTimeArray = new VolunteerAvailabilityTime[result.Rows.Count];
            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow availabilityTimeDataRow = result.Rows[i];

                VolunteerAvailabilityTime currentAvailabilityTime = new VolunteerAvailabilityTime(
                    (DayOfWeek)Enum.Parse(typeof(DayOfWeek), availabilityTimeDataRow["DayOfWeek"].ToString()),
                    Convert.ToInt32(availabilityTimeDataRow["StartTime"].ToString()),
                    Convert.ToInt32(availabilityTimeDataRow["EndTime"].ToString()));

                availabilityTimeArray[i] = currentAvailabilityTime;
            }
            
            Volunteer current = new Volunteer(generalDataRow["IDNumber"].ToString(),
                generalDataRow["Firstname"].ToString(), generalDataRow["Surname"].ToString(), generalDataRow["Address"].ToString(),
                generalDataRow["HomePhone"].ToString(), generalDataRow["CellPhone"].ToString(), generalDataRow["EMail"].ToString(),
                Convert.ToDateTime(generalDataRow["Birthdate"].ToString()), generalDataRow["Comment"].ToString(),
                (Volunteer.VolunteerTypeEnum)Enum.Parse(typeof(Volunteer.VolunteerTypeEnum), generalDataRow["VolunteerTypeName"].ToString()),
                availabilityTimeArray,activityTypes,activityLog);
            Close();
            return current;
        }

        /// <summary>
        /// this method updates a single volunteer data
        /// </summary>
        /// <param name="entity">the updated entity</param>
        /// <returns>number of rows affected</returns>
        public int UpdateVolunteerData(Volunteer entity)
        {
            // check if the user has permissions to update entities
            if (!CheckPermissions(User.ActionTypeEnum.UpdateEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות לעדכון הישות");

            // update the data
            Init();
            int result = DBActions.ExecuteNonQuery("update volunteers set Firstname = '" + entity.Firstname + "',"
                + "Surname = '" + entity.Surname + "',"
                + "Address = '" + entity.Address + "',"
                + "HomePhone = '" + entity.HomePhone + "',"
                + "CellPhone = '" + entity.CellPhone + "',"
                + "EMail = '" + entity.EMail + "',"
                + "Comment = '" + entity.Comment + "',"
                + "Birthdate = '" + entity.Birthdate.ToString() + "',"
                + "VolunteerType = '" + entity.VolunteerType.GetHashCode() + "'"
                + "where IDNumber = '" + entity.IDNumber + "'"
                , m_Connection);

            if (result == -1)
            {
                Close();
                throw new Exception("כשלון בעדכון נתונים במאגר הנתונים");
            }

            // update the volunteer`s availability data
            result = DBActions.ExecuteNonQuery("delete from volunteeravailabilitytime where volunteerid = '" + entity.IDNumber + "'", m_Connection);

            if (result == -1)
            {
                Close();
                throw new Exception("כשלון בעדכון נתונים במאגר הנתונים");
            }

            if (entity.VolunteerAvailability != null)
            {
                foreach (VolunteerAvailabilityTime current in entity.VolunteerAvailability)
                {
                    result = DBActions.ExecuteNonQuery("insert into volunteeravailabilitytime(VolunteerID,DayOfWeek,StartTime,EndTime) "
                    + "values('" + entity.IDNumber + "',"
                    + "'" + current.Day.ToString() + "',"
                    + "'" + current.StartTime + "',"
                    + "'" + current.EndTime + "')"
                    , m_Connection);

                    if (result == -1)
                    {
                        Close();
                        throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
                    }
                }
            }

            // update the volunteer`s activty types
            result = DBActions.ExecuteNonQuery("delete from volunteeractivitytypes where volunteerid = '" + entity.IDNumber + "'", m_Connection);

            if (result == -1)
            {
                Close();
                throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");
            }

            foreach (ActivityType current in entity.ActivityTypes)
            {
                result = DBActions.ExecuteNonQuery("insert into volunteeractivitytypes(VolunteerID,ActivityTypeID) "
                + "values('" + entity.IDNumber + "',"
                + "" + current.ID + ")"
                , m_Connection);

                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
                }
            }

            Close();
            return result;
        }

        /// <summary>
        /// this method adds a single volunteer to the system
        /// </summary>
        /// <param name="entity">the new entity to add</param>
        /// <returns>number of rows affected</returns>
        public int AddNewVolunteer(Volunteer entity)
        {
            // check if the user has permissions to create entities
            if (!CheckPermissions(User.ActionTypeEnum.CreateEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות ליצירת ישות");

            // add the new volunteer data
            Init();
            int result = DBActions.ExecuteNonQuery("insert into volunteers(Firstname,Surname,Address,HomePhone,CellPhone,EMail,Comment,Birthdate,IDNumber,VolunteerType) "
                + "values('" + entity.Firstname + "',"
                + "'" + entity.Surname + "',"
                + "'" + entity.Address + "',"
                + "'" + entity.HomePhone + "',"
                + "'" + entity.CellPhone + "',"
                + "'" + entity.EMail + "',"
                + "'" + entity.Comment + "',"
                + "'" + entity.Birthdate.ToString() + "',"
                + "'" + entity.IDNumber + "',"
                + "'" + entity.VolunteerType.GetHashCode() + "')"
                , m_Connection);
            if (result == -1)
            {
                Close();
                throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
            }

            // add the volunteer availability records
            if (entity.VolunteerAvailability != null)
            {
                foreach (VolunteerAvailabilityTime current in entity.VolunteerAvailability)
                {
                    result = DBActions.ExecuteNonQuery("insert into volunteeravailabilitytime(VolunteerID,DayOfWeek,StartTime,EndTime) "
                    + "values('" + entity.IDNumber + "',"
                    + "'" + current.Day.ToString() + "',"
                    + "'" + current.StartTime + "',"
                    + "'" + current.EndTime + "')"
                    , m_Connection);
                    if (result == -1)
                    {
                        Close();
                        throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
                    }
                }
            }

            // add the volunteer`s activity types list
            foreach (ActivityType current in entity.ActivityTypes)
            {
                result = DBActions.ExecuteNonQuery("insert into volunteeractivitytypes(VolunteerID,ActivityTypeID) "
                + "values('" + entity.IDNumber + "',"
                + "" + current.ID + ")"
                , m_Connection);
                if (result == -1)
                {
                    Close();
                    throw new Exception("כשלון בהכנסת נתונים למאגר הנתונים");
                }
            }

            Close();
            return result;
        }

        /// <summary>
        /// this method deletes a single volunteer from the system
        /// </summary>
        /// <param name="ID">the requested volunteer id to delete</param>
        /// <returns>number of rows affected</returns>
        public int DeleteVolunteer(string ID)
        {
            // check if the user has permissions to delete entities
            if (!CheckPermissions(User.ActionTypeEnum.DeleteEntity))
                throw new Exception("למשתמש אין הרשאות מתאימות למחיקת הישות");

            // delete the volunteer from all the activities he was assigned to
            Init();
            int result = DBActions.ExecuteNonQuery("delete from volunteerActivityLog"
                + " where volunteerid = '" + ID + "'"
                , m_Connection);
            if (result == -1)
            {
                Close();
                throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");
            }
            // delete the volunteer from the volunteeractivityTypes table
            result = DBActions.ExecuteNonQuery("delete from volunteeractivityTypes"
                + " where volunteerid = '" + ID + "'"
                , m_Connection);
            if (result == -1)
            {
                Close();
                throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");
            }
            // delete the volunteer from the volunteeravailabilitytime table
            result = DBActions.ExecuteNonQuery("delete from volunteeravailabilitytime"
                + " where volunteerid = '" + ID + "'"
                , m_Connection);
            if (result == -1)
            {
                Close();
                throw new Exception("כשלון במחיקת נתונים ממאגר הנתונים");
            }
            // delete the volunteer data
            result = DBActions.ExecuteNonQuery("delete from volunteers"
                + " where IDNumber = '" + ID + "'"
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
