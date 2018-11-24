using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementBL.Entities
{
    /// <summary>
    /// describes an entity of type Volunteer. a volunteer describes one 
    /// person that is registered as volunteer in the system and can
    /// be assigned to the diffrent activities in the system
    /// </summary>
    public class Volunteer
    {
        /// <summary>
        /// this is a constructor for an existing volunteer with
        /// short data - no activity and availability data
        /// </summary>
        /// <param name="IDNumber">the volunteer unique id</param>
        /// <param name="Firstname">first name for the volunteer</param>
        /// <param name="Surname">surname for the volunteer</param>
        /// <param name="Address">the volunteer`s address</param>
        /// <param name="HomePhone">the volunteer`s homephone</param>
        /// <param name="CellPhone">the volunteer`s cellphone</param>
        /// <param name="EMail">the volunteer`s email</param>
        /// <param name="Birthdate">the volunteer`s birthdate</param>
        /// <param name="Comment">a general textual comment for the volunteer</param>
        /// <param name="VolunteerType">the volunteer type</param>
        public Volunteer(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment, VolunteerTypeEnum VolunteerType)
        {
            m_VolunteerType = VolunteerType;
            m_IDNumber = IDNumber;
            m_Firstname = Firstname;
            m_Surname = Surname;
            m_Address = Address;
            m_HomePhone = HomePhone;
            m_CellPhone = CellPhone;
            m_EMail = EMail;
            m_Birthdate = Birthdate;
            m_Comment = Comment;
            m_VolunteerAvailability = null;
            m_ActivityTypes = null;
            m_ActivityLog = null;
        }

        /// <summary>
        /// this is a constructor for an existing volunteer with
        /// almost full data - include activity and availability data
        /// </summary>
        /// <param name="IDNumber">the volunteer unique id</param>
        /// <param name="Firstname">first name for the volunteer</param>
        /// <param name="Surname">surname for the volunteer</param>
        /// <param name="Address">the volunteer`s address</param>
        /// <param name="HomePhone">the volunteer`s homephone</param>
        /// <param name="CellPhone">the volunteer`s cellphone</param>
        /// <param name="EMail">the volunteer`s email</param>
        /// <param name="Birthdate">the volunteer`s birthdate</param>
        /// <param name="Comment">a general textual comment for the volunteer</param>
        /// <param name="VolunteerType">the volunteer type</param>
        /// <param name="VolunteerAvailability">an array of the times of the week in which the volunteer is available</param>
        /// <param name="ActivityTypes">the activity types that the volunteer wants to do</param>
        public Volunteer(string IDNumber, string Firstname, string Surname,
                          string Address, string HomePhone,
                          string CellPhone, string EMail, DateTime Birthdate,
                          string Comment, VolunteerTypeEnum VolunteerType,
                          VolunteerAvailabilityTime[] VolunteerAvailability,
                          ActivityType[] ActivityTypes)
        {
            m_VolunteerType = VolunteerType;
            m_IDNumber = IDNumber;
            m_Firstname = Firstname;
            m_Surname = Surname;
            m_Address = Address;
            m_HomePhone = HomePhone;
            m_CellPhone = CellPhone;
            m_EMail = EMail;
            m_Birthdate = Birthdate;
            m_Comment = Comment;
            m_VolunteerAvailability = VolunteerAvailability;
            m_ActivityTypes = ActivityTypes;
            m_ActivityLog = null;
        }

        /// <summary>
        /// this is a constructor for an existing volunteer with
        /// complete and full data
        /// </summary>
        /// <param name="IDNumber">the volunteer unique id</param>
        /// <param name="Firstname">first name for the volunteer</param>
        /// <param name="Surname">surname for the volunteer</param>
        /// <param name="Address">the volunteer`s address</param>
        /// <param name="HomePhone">the volunteer`s homephone</param>
        /// <param name="CellPhone">the volunteer`s cellphone</param>
        /// <param name="EMail">the volunteer`s email</param>
        /// <param name="Birthdate">the volunteer`s birthdate</param>
        /// <param name="Comment">a general textual comment for the volunteer</param>
        /// <param name="VolunteerType">the volunteer type</param>
        /// <param name="VolunteerAvailability">an array of the times of the week in which the volunteer is available</param>
        /// <param name="ActivityTypes">the activity types that the volunteer wants to do</param>
        /// <param name="ActivityLog">the volunteers`s activity history - all the activities the volunteer is assinged to</param>
        public Volunteer(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment, VolunteerTypeEnum VolunteerType,
                  VolunteerAvailabilityTime[] VolunteerAvailability,
                  ActivityType[] ActivityTypes,
                  Activity[] ActivityLog)
        {
            m_VolunteerType = VolunteerType;
            m_IDNumber = IDNumber;
            m_Firstname = Firstname;
            m_Surname = Surname;
            m_Address = Address;
            m_HomePhone = HomePhone;
            m_CellPhone = CellPhone;
            m_EMail = EMail;
            m_Birthdate = Birthdate;
            m_Comment = Comment;
            m_VolunteerAvailability = VolunteerAvailability;
            m_ActivityTypes = ActivityTypes;
            m_ActivityLog = ActivityLog;
        }

        /// <summary>
        /// this enum describes the type of the volunteer in the system.
        /// it is only used as a attribute of the volunteer for display
        /// </summary>
        public enum VolunteerTypeEnum
        {
            מחויבות_אישית = 2,
            מלגת_סטודנט = 3,
            עצמאי = 4
        }

        /// <summary>
        /// an array of VolunteerAvailabilityTime that indicates
        /// in what time of the week this volunteer is available for 
        /// activities. if it`s empty then the volunteer is considered 
        /// as available at all times
        /// </summary>
        public VolunteerAvailabilityTime[] VolunteerAvailability
        {
            get { return m_VolunteerAvailability; }
            set { m_VolunteerAvailability = value; }
        } 
        private VolunteerAvailabilityTime[] m_VolunteerAvailability;

        /// <summary>
        /// this is the volunteer type, used only for display 
        /// </summary>
        public VolunteerTypeEnum VolunteerType
        {
            get { return m_VolunteerType; }
            set { m_VolunteerType = value;}
        }
        private VolunteerTypeEnum m_VolunteerType;

        /// <summary>
        /// the unique volunteer`s id number
        /// </summary>
        public string IDNumber
        {
            get {return  m_IDNumber;}
            set {m_IDNumber = value; }
        }
        private string m_IDNumber;

        /// <summary>
        /// the volunteer`s first name
        /// </summary>
        public string Firstname
        {
            get { return m_Firstname; }
            set { m_Firstname = value; }
        }
        private string m_Firstname;

        /// <summary>
        /// the volunteer`s surname
        /// </summary>
        public string Surname
        {
            get { return m_Surname; }
            set { m_Surname = value; }
        }
        private string m_Surname;

        /// <summary>
        /// the volunteer`s home address
        /// </summary>
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        private string m_Address;

        /// <summary>
        /// the volunteer`s home phone number
        /// </summary>
        public string HomePhone
        {
            get { return m_HomePhone; }
            set { m_HomePhone = value; }
        }
        private string m_HomePhone;

        /// <summary>
        /// the volunteer`s cellphone number
        /// </summary>
        public string CellPhone
        {
            get { return m_CellPhone; }
            set { m_CellPhone = value; }
        }
        private string m_CellPhone;

        /// <summary>
        /// the volunteer`s email address
        /// </summary>
        public string EMail
        {
            get { return m_EMail; }
            set { m_EMail = value; }
        }
        private string m_EMail;

        /// <summary>
        /// the volunteer`s birthdate
        /// </summary>
        public DateTime Birthdate
        {
            get { return m_Birthdate; }
            set { m_Birthdate = value; }
        }
        private DateTime m_Birthdate;

        /// <summary>
        /// the volunteer`s general comment. used to describe unstructured data for 
        /// the volunteer entity
        /// </summary>
        public string Comment
        {
            get { return m_Comment; }
            set { m_Comment = value; }
        }
        private string m_Comment;

        /// <summary>
        /// the volunteers`s activity history - all the activities the volunteer is assinged to
        /// </summary>
        public Activity[] ActivityLog
        {
            get { return m_ActivityLog; }
            set { m_ActivityLog = value; }
        }
        private Activity[] m_ActivityLog;

        /// <summary>
        /// an array of activityTypes objects that describes the activity types that the volunteer wants to do
        /// </summary>
        public ActivityType[] ActivityTypes
        {
            get { return m_ActivityTypes; }
            set { m_ActivityTypes = value; }
        }
        private ActivityType[] m_ActivityTypes;

        /// <summary>
        /// returns the main id properties for the volunteer
        /// </summary>
        /// <returns>the volunteer`s short description</returns>
        override public string ToString()
        {
            return m_IDNumber + ", " + Firstname + " " + Surname;
        }

        /// <summary>
        /// used to compare between two voluunteers.
        /// two volunteers are the same if their idnumber is the same
        /// </summary>
        /// <param name="obj">the second volunteer to compare to</param>
        /// <returns>true if two volunteers are equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            string compareID = ((Volunteer)obj).IDNumber;
            return (compareID == IDNumber);
        }

        /// <summary>
        /// used for coparing two volunteer objects
        /// </summary>
        /// <returns>the object hashcode</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
