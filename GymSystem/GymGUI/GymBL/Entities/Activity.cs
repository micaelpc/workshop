using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementBL.Entities
{
    /// <summary>
    /// describes an entity of type Activity. an activity describes a task 
    /// of a certain type at a specific date and time, that requires 
    /// volunteers for it`s execution
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// constructor for a new activity without volunteers
        /// </summary>
        /// <param name="Description">the activity description</param>
        /// <param name="StartDate">start date and time for the activivty</param>
        /// <param name="EndDate">end date and time for the activivty</param>
        /// <param name="Location">the location for the activity</param>
        /// <param name="Type">the activity type - chosen from the defined activity types in the system</param>
        /// <param name="timingType">if the activity is part of a series of activities then this will define the cycle time between two activities in the series</param>
        /// <param name="ActivityTimingFinishDate">if the activity is part of a series of activities then this will define the finish date for the series</param>
        public Activity(string Description, DateTime StartDate, DateTime EndDate,
                           string Location, ActivityType Type, TimingEnum timingType,
                           DateTime ActivityTimingFinishDate)
        {
            m_ID = 0;
            m_Description = Description;
            m_StartDate = StartDate;
            m_EndDate = EndDate;
            m_Location = Location;
            m_Type = Type;
            m_TimingType = timingType;
            m_ActivityTimingFinishDate = ActivityTimingFinishDate;
            m_Volunteers = null;
        }

        /// <summary>
        /// constructor for a new activity with volunteers
        /// </summary>
        /// <param name="Description">the activity description</param>
        /// <param name="StartDate">start date and time for the activivty</param>
        /// <param name="EndDate">end date and time for the activivty</param>
        /// <param name="Location">the location for the activity</param>
        /// <param name="Type">the activity type - chosen from the defined activity types in the system</param>
        /// <param name="timingType">if the activity is part of a series of activities then this will define the cycle time between two activities in the series</param>
        /// <param name="ActivityTimingFinishDate">if the activity is part of a series of activities then this will define the finish date for the series</param>
        /// <param name="Volunteers">the volunteers that are assinged to this activity</param>
        public Activity(string Description, DateTime StartDate, DateTime EndDate,
                           string Location, ActivityType Type,
                            TimingEnum timingType, DateTime ActivityTimingFinishDate,
                            Volunteer[] Volunteers)
        {
            m_ID = 0;
            m_Description = Description;
            m_StartDate = StartDate;
            m_EndDate = EndDate;
            m_Location = Location;
            m_Type = Type;
            m_Volunteers = Volunteers;
            m_TimingType = timingType;
            m_ActivityTimingFinishDate = ActivityTimingFinishDate;
        }

        /// <summary>
        /// constructor for an existing activity with no volunteers data
        /// </summary>
        /// <param name="id">the activity unique id</param>
        /// <param name="Description">the activity description</param>
        /// <param name="StartDate">start date and time for the activivty</param>
        /// <param name="EndDate">end date and time for the activivty</param>
        /// <param name="Location">the location for the activity</param>
        /// <param name="Type">the activity type - chosen from the defined activity types in the system</param>
        /// <param name="timingType">if the activity is part of a series of activities then this will define the cycle time between two activities in the series</param>
        /// <param name="ActivityTimingFinishDate">if the activity is part of a series of activities then this will define the finish date for the series</param>
        public Activity(int id, string Description, DateTime StartDate, DateTime EndDate,
                           string Location, ActivityType Type, TimingEnum timingType,
                            DateTime ActivityTimingFinishDate)
        {
            m_ID = id;
            m_Description = Description;
            m_StartDate = StartDate;
            m_EndDate = EndDate;
            m_Location = Location;
            m_Type = Type;
            m_Volunteers = null;
            m_TimingType = timingType;
            m_ActivityTimingFinishDate = ActivityTimingFinishDate;
        }

        /// <summary>
        /// constructor for an existing activity with volunteers data
        /// </summary>
        /// <param name="id">the activity unique id</param>
        /// <param name="Description">the activity description</param>
        /// <param name="StartDate">start date and time for the activivty</param>
        /// <param name="EndDate">end date and time for the activivty</param>
        /// <param name="Location">the location for the activity</param>
        /// <param name="Type">the activity type - chosen from the defined activity types in the system</param>
        /// <param name="timingType">if the activity is part of a series of activities then this will define the cycle time between two activities in the series</param>
        /// <param name="ActivityTimingFinishDate">if the activity is part of a series of activities then this will define the finish date for the series</param>
        /// <param name="Volunteers">the volunteers that are assinged to this activity</param>
        public Activity(int id, string Description, DateTime StartDate, DateTime EndDate,
                           string Location, ActivityType Type, TimingEnum timingType,
                           DateTime ActivityTimingFinishDate,
                           Volunteer[] Volunteers)
        {
            m_ID = id;
            m_Description = Description;
            m_StartDate = StartDate;
            m_EndDate = EndDate;
            m_Location = Location;
            m_Type = Type;
            m_Volunteers = Volunteers;
            m_TimingType = timingType;
            m_ActivityTimingFinishDate = ActivityTimingFinishDate;
        }

        /// <summary>
        /// this enum defines the diffrent types of cycle times 
        /// available in the system
        /// </summary>
        public enum TimingEnum
        {
            חד_פעמי = 1,
            יומי = 2,
            שבועי = 3,
            חודשי = 4,
            רבעוני = 5,
            שנתי = 6
        }

        /// <summary>
        /// this is the activity cyclic behavior
        /// </summary>
        public TimingEnum TimingType
        {
            get { return m_TimingType; }
            set { m_TimingType = value; }
        }
        private TimingEnum m_TimingType;

        /// <summary>
        /// the activity`s series finish date
        /// </summary>
        public DateTime ActivityTimingFinishDate
        {
            get { return m_ActivityTimingFinishDate; }
            set { m_ActivityTimingFinishDate = value; }
        }
        private DateTime m_ActivityTimingFinishDate;

        /// <summary>
        /// text description for the activity
        /// </summary>
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        private string m_Description;

        /// <summary>
        /// start date and time
        /// </summary>
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }
        private DateTime m_StartDate;

        /// <summary>
        /// end date and time
        /// </summary>
        public DateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }
        private DateTime m_EndDate;

        /// <summary>
        /// the location where the activity takes place
        /// </summary>
        public string Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }
        private string m_Location;

        /// <summary>
        /// the type associated with the current activity
        /// </summary>
        public ActivityType Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }
        private ActivityType m_Type;

        /// <summary>
        /// the volunteers assinged to this activity
        /// </summary>
        public Volunteer[] Volunteers
        {
            get { return m_Volunteers; }
            set { m_Volunteers = value; }
        }
        private Volunteer[] m_Volunteers;

        /// <summary>
        /// unique id for the activity
        /// </summary>
        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        private int m_ID;

        /// <summary>
        /// a textual representation of the main activity data
        /// </summary>
        /// <returns>a string description of the activity data</returns>
        public override string ToString()
        {
            return m_StartDate.ToShortTimeString() + "-" + m_EndDate.ToShortTimeString() + " , " + m_Type + " , " + m_Location;
        }
    }
}
