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
    /// this report summarizes the data for all of the volunteers in the system.
    /// the report groups and counts all of the volunteers according to
    /// one of the volunteers common attributes
    /// </summary>
    public class ReportVolunteerSummaryData : Report
    {
        /// <summary>
        /// constructor for this class, only uses the base constructor
        /// </summary>
        /// <param name="user">the current connected user</param>
        public ReportVolunteerSummaryData(User user)
            : base(user)
        {
        }

        /// <summary>
        /// this enum defines which of the volunteers attributes
        /// wiil be used for the group by
        /// </summary>
        public enum VolunteerAttributeEnum
        {
            שנת_הרשמה,
            גיל,
            סוג_מתנדב,
            סוג_פעילות
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

            string sql = "";

            // group by the proper attribute
            switch (m_VolunteerAttribute)
            {
                case VolunteerAttributeEnum.סוג_פעילות:
                    sql = "select activityTypeName as [סוג פעילות], count(*) as כמות"
                          + " from volunteeractivityTypes, activityTypes"
                          + " where volunteeractivityTypes.activitytypeid = activityTypes.id"
                          + " group by activityTypeName"
                          + " order by count(*) desc";
                    break;
                case VolunteerAttributeEnum.גיל:
                    sql = "select (Year(Date()) - Year(birthDate)) as גיל, count(*) as כמות"
                            + " from volunteers"
                            + " group by  (Year(Date()) - Year(birthDate))"
                            + " order by count(*) desc";
                    break;
                case VolunteerAttributeEnum.שנת_הרשמה:
                    sql = "select Year(RegistrationDate) as [שנת הרשמה], count(*) as כמות"
                            + " from volunteers"
                            + " group by  Year(RegistrationDate)"
                            + " order by count(*) desc";
                    break;
                case VolunteerAttributeEnum.סוג_מתנדב:
                    sql = "select volunteerTypeName as [סוג מתנדב], count(*) as כמות"
                            + " from volunteers, VolunteerType"
                            + " where volunteers.VolunteerType = VolunteerType.id"
                            + " group by volunteerTypeName"
                            + " order by count(*) desc";
                    break;
            }

            Init();
            DataTable result = DBActions.ExecuteQuery(sql,m_Connection);
            Close();
            if (result == null)
                throw new Exception("כשלון בשליפת נתונים ממאגר הנתונים");
            m_SummaryData = result;
        }

        /// <summary>
        /// this is the chosen attribute for the report execution
        /// </summary>
        private VolunteerAttributeEnum m_VolunteerAttribute;
        public VolunteerAttributeEnum VolunteerAttribute
        {
            get { return m_VolunteerAttribute; }
            set { m_VolunteerAttribute = value; }
        }

        /// <summary>
        /// this is the report result
        /// </summary>
        private DataTable m_SummaryData;
        public DataTable SummaryData
        {
            get { return m_SummaryData; }
            set { }
        }
    }
}
