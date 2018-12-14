using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymBL.Entities;

namespace GymBL.Reports
{
    /// <summary>
    /// this class is derived from facade and defines a specific
    /// type of facade - a report. this class is the father
    /// for all the report classes in the system
    /// </summary>
    public class Report : Facade
    {
        /// <summary>
        /// the constructor for this class, only uses the base class constructor
        /// </summary>
        /// <param name="activeUser">the system`s current active user</param>
        public Report(User activeUser) : base (activeUser)
        {
        }

        /// <summary>
        /// executes the report logic and fills in the 
        /// class data object with the requested data
        /// </summary>
        public virtual void LoadReportData()
        { }


        /// <summary>
        /// this enum defines all of the diffrent reports in the system
        /// </summary>
        public enum ReportTypeEnum
        {
            היסטוריית_התנדבות_עבור_מתנדב = 1,
            נתוני_מתנדבים_עבור_פעילות = 2,
            פירוט_מתנדבים_חדשים_לפי_תאריך = 3,
            היסטוריית_פעילויות_לפי_תאריך = 4,
            כמות_מתנדבים_חדשים_בשנה_האחרונה = 5,
            פילוח_מתנדבים_לפי_מאפייני_מתנדב = 6,
            כמות_פעילויות_בשנה_האחרונה = 7,
            חלוקת_עבודה_בין_מתנדבים = 8
        }
    }
}
