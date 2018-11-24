using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using VolunteerManagementBL;
using VolunteerManagementBL.Entities;

namespace VolunteerManagementBL.Reports
{
    /// <summary>
    /// this report counts how many activities has each of the volunteers
    /// was assigned to in a given date range
    /// </summary>
    public class ReportWorkDistribution : Report
    {
        /// <summary>
        /// constructor for this class, only uses the base constructor
        /// </summary>
        /// <param name="user">the current connected user</param>
        public ReportWorkDistribution(User user)
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

            // get the total volunteers number in the db
            VolunteerFacade vFacade = new VolunteerFacade(m_ActiveUser);
            m_TotalVolunteerNumber = vFacade.CountAllVolunteers();

            // get all the activities in the date range
            ActivityFacade afacade = new ActivityFacade(m_ActiveUser);
            Activity[] activityList = afacade.GetActivityListByDateRange(StartDate, FinishDate);
            m_TotalActivityNumber = activityList.Length;

            Hashtable volunteerTable = new Hashtable();
            m_VolunteerActivityNum = new Hashtable();
            // for each activity increase the total count for each of the activity`s volunteers
            foreach (Activity current in activityList)
            {
                Activity fullDataActivity = afacade.GetSingleActivityData(current.ID);
                foreach (Volunteer v in fullDataActivity.Volunteers)
                {
                    if (!volunteerTable.Contains(v.IDNumber))
                        volunteerTable.Add(v.IDNumber,v);
                    if (m_VolunteerActivityNum.Contains(v.IDNumber))
                    {
                        m_VolunteerActivityNum[v.IDNumber] = ((int)m_VolunteerActivityNum[v.IDNumber]) + 1;
                    }
                    else
                    {
                        m_VolunteerActivityNum.Add(v.IDNumber,1);
                    }
                }
            }

            m_VolunteerList = new Volunteer[volunteerTable.Values.Count];
            IEnumerator e = volunteerTable.Values.GetEnumerator();
            int i =0;
            while (e.MoveNext())
            {
                m_VolunteerList[i] = (Volunteer)e.Current;
                i++;
            }
        }

        /// <summary>
        /// the list of volunteers who have executed at least one activity in the given time period
        /// </summary>
        private Volunteer[] m_VolunteerList;
        public Volunteer[] VolunteerList
        {
            get { return m_VolunteerList; }
            set {  }
        }

        /// <summary>
        /// the number of executed activities by each volunteer
        /// </summary>
        private Hashtable m_VolunteerActivityNum;
        public Hashtable VolunteerActivityNum
        {
            get { return m_VolunteerActivityNum; }
            set {  }
        }

        /// <summary>
        /// the total number of activities in the date range
        /// </summary>
        public int TotalActivityNumber
        {
            get { return m_TotalActivityNumber; }
            set { }
        }
        private int m_TotalActivityNumber;

        /// <summary>
        /// the total number of volunteers that have executes at least one activity in the date range
        /// </summary>
        public int TotalVolunteerNumber
        {
            get { return m_TotalVolunteerNumber; }
            set { }
        }
        private int m_TotalVolunteerNumber;

        /// <summary>
        /// the start time for the report
        /// </summary>
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }
        private DateTime m_StartDate;

        /// <summary>
        /// the finish time for the report
        /// </summary>
        public DateTime FinishDate
        {
            get { return m_FinishDate; }
            set { m_FinishDate = value; }
        }
        private DateTime m_FinishDate;
    }
}
