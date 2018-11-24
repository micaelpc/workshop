using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerManagementBL;
using VolunteerManagementBL.Entities;

namespace VolunteerManagementBL.Reports
{
    /// <summary>
    /// this report gets the details of the volunteers assigned to a specific activity
    /// </summary>
    public class ReportActivityVolunteerData : Report
    {
        /// <summary>
        /// constructor for this class, only uses the base constructor
        /// </summary>
        /// <param name="user">the current connected user</param>
        public ReportActivityVolunteerData(User user) : base (user)
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
            m_VolunteerList = facade.GetSingleActivityData(m_ActivityID).Volunteers;
        }

        /// <summary>
        /// the result for the report
        /// </summary>
        private Volunteer[] m_VolunteerList;
        public Volunteer[] VolunteerList
        {
            get { return m_VolunteerList; }
            set { m_VolunteerList = value; }
        }

        /// <summary>
        /// the activity id that will be used in the report execution
        /// </summary>
        public int ActivityID
        {
            get { return m_ActivityID; }
            set { m_ActivityID = value; }
        }
        private int m_ActivityID;
    }
}
