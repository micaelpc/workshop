using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementBL.Entities
{
    /// <summary>
    /// this class describes a time and day in the week. 
    /// this time is a time in which the volunteer is available
    /// to be assigned to activities. if the activity`s start time if after
    /// the availability start time and the activity`s end time if before
    /// the availability end time and it`s the same day of the week,
    /// then the volunteer is considere available
    /// </summary>
    public class VolunteerAvailabilityTime
    {
        /// <summary>
        /// the constructor for the VolunteerAvailabilityTime object
        /// </summary>
        /// <param name="Day">the day of the week in which the volunteer is available</param>
        /// <param name="StartTime">the start time in which the volunteer is available</param>
        /// <param name="EndTime">the end time in which the volunteer is available</param>
        public VolunteerAvailabilityTime(DayOfWeek Day, int StartTime, int EndTime)
        {
            m_Day = Day;
            m_StartTime = StartTime;
            m_EndTime = EndTime;
        }

        /// <summary>
        /// the day of the week in which the volunteer is available
        /// </summary>
        public DayOfWeek Day
        {
            get { return m_Day; }
            set { m_Day = value; }
        }
        private DayOfWeek m_Day;

        /// <summary>
        /// the start time in which the volunteer is available
        /// </summary>
        public int StartTime
        {
            get { return m_StartTime; }
            set { m_StartTime = value; }
        }
        private int m_StartTime;

        /// <summary>
        /// the end time in which the volunteer is available
        /// </summary>
        public int EndTime
        {
            get { return m_EndTime; }
            set { m_EndTime = value; }
        }
        private int m_EndTime;
        /// <summary>
        /// return a textual description of the object data
        /// </summary>
        /// <returns>the time and day of the availability</returns>
        public override string ToString()
        {
            return m_Day.ToString() + ", משעה " + m_StartTime + " עד שעה " + m_EndTime;
        }
    }
}
