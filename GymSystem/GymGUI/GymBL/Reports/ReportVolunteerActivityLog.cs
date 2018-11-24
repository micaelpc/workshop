using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using VolunteerManagementDAL;
using VolunteerManagementBL.Entities;

namespace VolunteerManagementBL.Reports
{
    /// <summary>
    /// this report gets the number of activities in each month of the last year
    /// for a specific volunteer. it also gets the number of activities for
    /// each activity type in the last year
    /// </summary>
    public class ReportVolunteerActivityLog : Report
    {
        /// <summary>
        /// constructor for this class, only uses the base constructor
        /// </summary>
        /// <param name="user">the current connected user</param>
        public ReportVolunteerActivityLog(User user)
            : base(user)
        {
        }

        /// <summary>
        /// executes the report logic and fills in the 
        /// class data object with the requested data.
        /// it first checks if the user can execute this type
        /// of report and if he can it executes the report
        /// and stores the result data
        /// </summary>
        public override void LoadReportData()
        {
            if (!CheckPermissions(User.ActionTypeEnum.RunOperationReport))
                throw new Exception("למשתמש אין הרשאות מתאימות להרצת הדוח");

            Init();
            DataTable result = DBActions.ExecuteQuery(
                "select month(StartDate) as חודש,count(*) as כמות from activities"
                + " where StartDate > DateAdd('yyyy',-1,Date())"
                + " and EndDate < Date()"
                + " and id in (select activityID from VolunteerActivityLog where VolunteerID = '" + m_VolunteerID + "')"
                + " group by month(StartDate)",
                m_Connection);
            if (result == null)
            {
                Close();
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            }
            m_ActivityByTimeData = result;

            result = DBActions.ExecuteQuery(
                "select activityTypes.ActivityTypeName as פעילות,count(*) as כמות from activities, activityTypes"
                + " where StartDate > DateAdd('yyyy',-1,Date())"
                + " and EndDate < Date()"
                + " and activities.activityType = activityTypes.id"
                + " and activities.id in (select activityID from VolunteerActivityLog where VolunteerID = '" + m_VolunteerID + "')"
                + " group by activityTypes.ActivityTypeName",
                m_Connection);
            Close();
            if (result == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            m_ActivityByTypeData = result;
            
            
        }

        /// <summary>
        /// the result for the report - the number of activities in each month
        /// </summary>
        private DataTable m_ActivityByTimeData;
        public DataTable ActivityByTimeData
        {
            get { return m_ActivityByTimeData; }
            set {  }
        }

        /// <summary>
        /// the result for the report - the number of activities of each activity type
        /// </summary>
        private DataTable m_ActivityByTypeData;
        public DataTable ActivityByTypeData
        {
            get { return m_ActivityByTypeData; }
            set {  }
        }

        /// <summary>
        /// the volunteer id used in the report execution
        /// </summary>
        private string m_VolunteerID;
        public string VolunteerID
        {
            get { return m_VolunteerID; }
            set { m_VolunteerID = value; }
        }
    }
}
