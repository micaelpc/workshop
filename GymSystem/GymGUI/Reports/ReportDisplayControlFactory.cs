using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymBL.Reports;

namespace VolunteerManagementGUI.Reports
{
    /// <summary>
    /// this class is a factory that create the right report
    /// display control according to the requested
    /// report type
    /// </summary>
    public class ReportDisplayControlFactory
    {
        /// <summary>
        /// this method creates the report display control of the requested type
        /// </summary>
        /// <param name="reportType">the requested report type</param>
        /// <returns>an object that implements the IGeneralReportDisplayControl interface and conatains the requested report logic</returns>
        public static IGeneralReportDisplayControl CreateDisplayControl(Report.ReportTypeEnum reportType)
        {
            //check the report type and return the proper display control object
            switch (reportType)
            {
                case Report.ReportTypeEnum.היסטוריית_התנדבות_עבור_מתנדב:
                    return new ReportVolunteerActivityLogDisplayControl();
                case Report.ReportTypeEnum.היסטוריית_פעילויות_לפי_תאריך:
                    return new ReportActivityLogDisplayControl();
                case Report.ReportTypeEnum.חלוקת_עבודה_בין_מתנדבים:
                    return new ReportWorkDistributionDisplayControl();
                case Report.ReportTypeEnum.כמות_מתנדבים_חדשים_בשנה_האחרונה:
                    return new ReportNewVolunteerSummaryDataDisplayControl();
                case Report.ReportTypeEnum.כמות_פעילויות_בשנה_האחרונה:
                    return new ReportActivitySummaryDataDisplayControl();
                case Report.ReportTypeEnum.נתוני_מתנדבים_עבור_פעילות:
                    return new ReportActivityVolunteerDataDisplayControl();
                case Report.ReportTypeEnum.פילוח_מתנדבים_לפי_מאפייני_מתנדב:
                    return new ReportVolunteerSummaryDataDisplayControl();
                case Report.ReportTypeEnum.פירוט_מתנדבים_חדשים_לפי_תאריך:
                    return new ReportNewVolunteersDisplayControl();
            }
            throw new Exception("The display control type " + reportType.ToString() + " is not recognized.");
        }
    }
}
