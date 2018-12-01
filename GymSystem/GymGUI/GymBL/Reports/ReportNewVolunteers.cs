using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymBL;
using GymBL.Entities;

namespace GymBL.Reports
{
    /// <summary>
    /// this report gets all the new volunteers in a given date range 
    /// </summary>
    public class ReportNewVolunteers : Report
    {
        /// <summary>
        /// constructor for this class, only uses the base constructor
        /// </summary>
        /// <param name="user">the current connected user</param>
        public ReportNewVolunteers(User user) : base (user)
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

            VolunteerFacade facade = new VolunteerFacade(m_ActiveUser);
            m_VolunteerList = facade.GetVolunteerList("",
                "", null, null, StartDate, FinishDate, true);
        }

        /// <summary>
        /// the result of the report query 
        /// </summary>
        private Person[] m_VolunteerList;
        public Person[] VolunteerList
        {
            get { return m_VolunteerList; }
            set { m_VolunteerList = value; }
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
