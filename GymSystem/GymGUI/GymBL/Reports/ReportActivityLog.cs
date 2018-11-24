using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerManagementBL;
using VolunteerManagementBL.Entities;
using VolunteerManagementBL.Log;

namespace VolunteerManagementBL.Reports
{
    /// <summary>
    /// this report gets all the activities in a given date range 
    /// </summary>
    public class ReportActivityLog : Report
    {

        /// <summary>
        /// constructor for this class, only uses the base constructor
        /// </summary>
        /// <param name="user">the current connected user</param>
        public ReportActivityLog(User user)
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
            ActivityFacade facade = new ActivityFacade(m_ActiveUser);
            try
            {
                m_ActivityList = facade.GetActivityListByDateRange(StartDate, FinishDate);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל רשימת פעילויות: " + e.Message, Logger.LogLevelEnum.Errors, m_ActiveUser.UserName, "GetActivityListByDateRange");
                m_ActivityList = null;
                throw e;
            }
        }

        /// <summary>
        /// the result of the report query 
        /// </summary>
        private Activity[] m_ActivityList;
        public Activity[] ActivityList
        {
            get { return m_ActivityList; }
            set { m_ActivityList = value; }
        }

        /// <summary>
        /// the start date for the activity range
        /// </summary>
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }
        private DateTime m_StartDate;

        /// <summary>
        /// the finish date for the activity range
        /// </summary>
        public DateTime FinishDate
        {
            get { return m_FinishDate; }
            set { m_FinishDate = value; }
        }
        private DateTime m_FinishDate;
    }
}
