using GymBL.Database;
using System;
using System.Data;

namespace GymBL.Entities
{
    /// <summary>
    /// describes an entity of type Volunteer. a volunteer describes one 
    /// person that is registered as volunteer in the system and can
    /// be assigned to the diffrent activities in the system
    /// </summary>
    public abstract class Person : ObservableObject, IDatabaseSerializableWithId 
    {
        public Person() { }

        /// <summary>
        /// this is a constructor for an existing person with
        /// short data - no activity and availability data
        /// </summary>
        /// <param name="IDNumber">the person unique id</param>
        /// <param name="Firstname">first name for the volunteer</param>
        /// <param name="Surname">surname for the volunteer</param>
        /// <param name="Address">the volunteer`s address</param>
        /// <param name="HomePhone">the volunteer`s homephone</param>
        /// <param name="CellPhone">the volunteer`s cellphone</param>
        /// <param name="EMail">the volunteer`s email</param>
        /// <param name="Birthdate">the volunteer`s birthdate</param>
        /// <param name="Comment">a general textual comment for the volunteer</param>
        public Person(string IDNumber, string Firstname, string Surname,
                  string Address, string HomePhone,
                  string CellPhone, string EMail, DateTime Birthdate,
                  string Comment)
        {
            m_IDNumber = IDNumber;
            m_Firstname = Firstname;
            m_Surname = Surname;
            m_Address = Address;
            m_HomePhone = HomePhone;
            m_CellPhone = CellPhone;
            m_EMail = EMail;
            m_Birthdate = Birthdate;
            m_Comment = Comment;
        }



        public string IDNumber
        {
            get
            {
                if (m_IDNumber == null)
                    return String.Empty;
                return m_IDNumber;
            }
            set
            {
                m_IDNumber = value;
                OnPropertyChanged("IDNumber");
            }
        }

        /// <summary>
        /// the unique volunteer`s id number
        /// </summary>
        //public string IDNumber
        //{
        //    get { return m_IDNumber; }
        //    set { m_IDNumber = value; }
        //}
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
            string compareID = ((Person)obj).IDNumber;
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

        public virtual void Serialize(IDatabaseStream stream)
        {
            stream.Add("id", IDNumber);
            stream.Add("Firstname", Firstname);
            stream.Add("Surname", Surname);
            stream.Add("Address", Address);
            stream.Add("HomePhone", HomePhone);
            stream.Add("CellPhone", CellPhone);
            stream.Add("EMail", EMail);
            stream.Add("Birthdate", Birthdate);
            stream.Add("Comment", Comment);
        }

        public virtual void Load(DataRow row, Database.Database database)
        {
            IDNumber = row.Field<string>("id");
            Firstname = row.Field<string>("Firstname");
            Surname = row.Field<string>("Surname");
            Address = row.Field<string>("Address");
            HomePhone = row.Field<string>("HomePhone");
            CellPhone = row.Field<string>("CellPhone");
            EMail = row.Field<string>("EMail");
            Birthdate = row.Field<DateTime>("Birthdate");
            Comment = row.Field<string>("Comment");
        }

        public string GetId()
        {
            return IDNumber;
        }

        public void SetId(string id)
        {
            IDNumber = id;
        }
    }
}
