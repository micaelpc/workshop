using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymBL.Entities
{
    /// <summary>
    /// this class describes a time and day in the week.
    /// </summary>
    public class TimeSpanOfWeek
    {
        public TimeSpanOfWeek() {

            Day = DayOfWeek.Sunday;
            StartTime = 0;
            EndTime = 0;
        }
        /// <summary>
        /// the constructor for the TimeSpanOfWeek object
        /// </summary>
        /// <param name="Day">the day of the week</param>
        /// <param name="StartTime">the start time</param>
        /// <param name="EndTime">the end time</param>
        public TimeSpanOfWeek(DayOfWeek Day, int StartTime, int EndTime)
        {
            m_Day = Day;
            m_StartTime = StartTime;
            m_EndTime = EndTime;
        }

        /// <summary>
        /// the day of the week
        /// </summary>
        public DayOfWeek Day
        {
            get { return m_Day; }
            set { m_Day = value; }
        }
        private DayOfWeek m_Day;

        /// <summary>
        /// the start time
        /// </summary>
        public int StartTime
        {
            get { return m_StartTime; }
            set { m_StartTime = value; }
        }
        private int m_StartTime;

        /// <summary>
        /// the end time
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
        /// <returns>the time and day</returns>
        public override string ToString()
        {
            return m_Day.ToString() + ", משעה " + m_StartTime + " עד שעה " + m_EndTime;
        }
    }
}
