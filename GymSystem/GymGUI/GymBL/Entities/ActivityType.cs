using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementBL.Entities
{
    /// <summary>
    /// describes an entity of type ActivityType. this entity is a template for 
    /// an activity and it defines the general data for an activity.
    /// each activity must have a defined type
    /// </summary>
    public class ActivityType
    {
        /// <summary>
        /// constructor for an existing activitytype
        /// </summary>
        /// <param name="ID">the activityType unique id</param>
        /// <param name="Description">the activity type texutal description</param>
        /// <param name="ActivityTypeName">short name of the activityType</param>
        /// <param name="Location">the default location for an activity of this type</param>
        public ActivityType(int ID,string Description, string ActivityTypeName, string Location)
        {
            m_ID = ID;
            m_Location = Location;
            m_ActivityTypeName = ActivityTypeName;
            m_Description = Description;
        }

        /// <summary>
        /// constructor for a new activitytype
        /// </summary>
        /// <param name="Description">the activity type texutal description</param>
        /// <param name="ActivityTypeName">short name of the activityType</param>
        /// <param name="Location">the default location for an activity of this type</param>
        public ActivityType(string Description, string ActivityTypeName, string Location)
        {
            m_ID = 0;
            m_Location = Location;
            m_ActivityTypeName = ActivityTypeName;
            m_Description = Description;
        }

        /// <summary>
        /// the activity type texutal description
        /// </summary>
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        private string m_Description;

        /// <summary>
        /// short name of the activityType
        /// </summary>
        public string ActivityTypeName
        {
            get { return m_ActivityTypeName; }
            set { m_ActivityTypeName = value; }
        }
        private string m_ActivityTypeName;

        /// <summary>
        /// the default location for an activity of this type
        /// </summary>
        public string Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }
        private string m_Location;

        /// <summary>
        /// the activityType unique id
        /// </summary>
        public int ID
        {
            get { return m_ID; }
        }
        private int m_ID;

        /// <summary>
        /// gets the name of the activityType
        /// </summary>
        /// <returns>a string description of the activityType name</returns>
        public override string ToString()
        {
            return m_ActivityTypeName;
        }
    }
}
