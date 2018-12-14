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
    /// this report gets the number of activities in each month of the last year
    /// each month data is displayed divided to the diffrent activity types 
    /// </summary>
    public class ReportActivitySummaryData : Report
    {
        /// <summary>
        /// constructor for this class, only uses the base constructor
        /// </summary>
        /// <param name="user">the current connected user</param>
        public ReportActivitySummaryData(User user)
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
            if (!CheckPermissions(User.ActionTypeEnum.RunManagementReport))
                throw new Exception("למשתמש אין הרשאות מתאימות להרצת הדוח");

            DataTable summary = new DataTable();
            summary.Columns.Add("חודש",typeof(int));

            ActivityTypeFacade typeFacade = new ActivityTypeFacade(m_ActiveUser);
            ActivityType[] typeArray = typeFacade.GetActivityTypesList();

            Init();
            foreach (ActivityType currentType in typeArray)
            {
                DataColumn col = summary.Columns.Add(currentType.ActivityTypeName,typeof(int));
                col.DefaultValue = 0;
                DataTable result = DBActions.ExecuteQuery(
                "select month(StartDate) as חודש,count(*) as כמות from activities"
                + " where StartDate > DateAdd('yyyy',-1,Date())"
                + " and EndDate < Date()"
                + " and activityType = " + currentType.ID
                + " group by month(StartDate)",
                m_Connection);
                if (result == null)
                {
                    Close();
                    throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
                }
                foreach (DataRow row in result.Rows)
                {
                    int month = Convert.ToInt32(row[0]);
                    int ammount = Convert.ToInt32(row[1]);
                    int index = GetMonthRowPosition(summary, month);
                    if (index < 0)
                    {
                        object[] parameters = new object[summary.Columns.Count];
                        parameters[0] = month;
                        for (int i = 1; i < parameters.Length; i++)
                        {
                            parameters[i] = 0;
                        }
                        DataRow newRow = summary.Rows.Add(parameters);
                        newRow[currentType.ActivityTypeName] = ammount;
                    }
                    else
                    {
                        DataRow oldRow = summary.Rows[index];
                        oldRow[currentType.ActivityTypeName] = ammount;
                    }
                }
            }

            
            Close();
            m_SummaryData = summary;
        }

        private int GetMonthRowPosition(DataTable summary, int month)
        {
            for (int i =0 ; i< summary.Rows.Count; i++)
            {
                DataRow row = summary.Rows[i];
                if (Convert.ToInt32(row[0]) == month)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// the result of the report
        /// </summary>
        private DataTable m_SummaryData;
        public DataTable SummaryData
        {
            get { return m_SummaryData; }
            set { }
        }
    }
}
