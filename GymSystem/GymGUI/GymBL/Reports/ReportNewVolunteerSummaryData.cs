using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using VolunteerManagementDAL;
using GymBL.Entities;

namespace GymBL.Reports
{
    /// <summary>
    /// this report gets the number of new volunteers in each month of the last year
    /// </summary>
    public class ReportNewVolunteerSummaryData : Report
    {
        /// <summary>
        /// constructor for this class, only uses the base constructor
        /// </summary>
        /// <param name="user">the current connected user</param>
        public ReportNewVolunteerSummaryData(User user) : base (user)
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
            if (!CheckPermissions(User.ActionTypeEnum.RunManagementReport))
                throw new Exception("למשתמש אין הרשאות מתאימות להרצת הדוח");

            Init();
            DataTable result = DBActions.ExecuteQuery(
                "select month(RegistrationDate) as חודש ,count(*) as כמות from volunteers"
                + " where RegistrationDate > DateAdd('yyyy',-1,Date())"
                + " group by month(RegistrationDate)",
                m_Connection);
            Close();
            if (result == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            m_SummaryData = result;
        }

        /// <summary>
        /// the result of the report
        /// </summary>
        private DataTable m_SummaryData;
        public DataTable SummaryData
        {
            get { return m_SummaryData; }
            set {  }
        }
    }
}
