using GymBL.Database;
using System;
using System.Data;

namespace GymBL.Entities
{
    /// <summary>
    /// describes an entity of type person. a person describes one 
    /// </summary>
    public abstract class Person : ObservableObject, IDatabaseSerializableWithId 
    {
        public Person() { }

        /// <summary>
        /// this is a constructor for an existing person with
        /// short data - no activity and availability data
        /// </summary>
        /// <param name="IDNumber">the person unique id</param>
        /// <param name="Firstname">first name for the pe</param>
        /// <param name="Surname">surname for the person</param>
        /// <param name="Address">the person`s address</param>
        /// <param name="HomePhone">the person`s homephone</param>
        /// <param name="CellPhone">the person`s cellphone</param>
        /// <param name="EMail">the person`s email</param>
        /// <param name="Birthdate">the person`s birthdate</param>
        /// <param name="Comment">a general textual comment for the person</param>
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
        /// the unique person`s id number
        /// </summary>
        //public string IDNumber
        //{
        //    get { return m_IDNumber; }
        //    set { m_IDNumber = value; }
        //}
        private string m_IDNumber;

        /// <summary>
        /// the person`s first name
        /// </summary>
        public string Firstname
        {
            get { return m_Firstname; }
            set {

                OnPropertyChanged("Firstname");
                m_Firstname = value; }
        }
        private string m_Firstname;

        /// <summary>
        /// the person`s surname
        /// </summary>
        public string Surname
        {
            get { return m_Surname; }
            set {
                OnPropertyChanged("Surname");
                m_Surname = value; }
        }
        private string m_Surname;

        /// <summary>
        /// the person`s home address
        /// </summary>
        public string Address
        {
            get { return m_Address; }
            set {
                OnPropertyChanged("Address");
                m_Address = value; }
        }
        private string m_Address;

        /// <summary>
        /// the person`s home phone number
        /// </summary>
        public string HomePhone
        {
            get { return m_HomePhone; }
            set {
                OnPropertyChanged("HomePhone");
                m_HomePhone = value; }
        }
        private string m_HomePhone;

        /// <summary>
        /// the person`s cellphone number
        /// </summary>
        public string CellPhone
        {
            get { return m_CellPhone; }
            set {
                OnPropertyChanged("CellPhone");
                m_CellPhone = value; }
        }
        private string m_CellPhone;

        /// <summary>
        /// the person`s email address
        /// </summary>
        public string EMail
        {
            get { return m_EMail; }
            set {
                OnPropertyChanged("EMail");
                m_EMail = value; }
        }
        private string m_EMail;

        /// <summary>
        /// the person`s birthdate
        /// </summary>
        public DateTime Birthdate
        {
            get { return m_Birthdate; }
            set {
                OnPropertyChanged("Birthdate");
                m_Birthdate = value; }
        }
        private DateTime m_Birthdate;

        /// <summary>
        /// the person`s general comment. used to describe unstructured data for 
        /// the person entity
        /// </summary>
        public string Comment
        {
            get { return m_Comment; }
            set {
                OnPropertyChanged("Comment");
                m_Comment = value; }
        }
        private string m_Comment;

        /// <summary>
        /// the person`s general comment. used to describe unstructured data for 
        /// the person entity
        /// </summary>
        public byte[] Picture
        {
            get { return m_Picture; }
            set
            {
                OnPropertyChanged("Picture");
                m_Picture = value;
            }
        }
        private byte[] m_Picture;


        /// <summary>
        /// returns the main id properties for the volunteer
        /// </summary>
        /// <returns>the person`s short description</returns>
        override public string ToString()
        {
            return m_IDNumber + ", " + Firstname + " " + Surname;
        }

        /// <summary>
        /// used to compare between two voluunteers.
        /// two persons are the same if their idnumber is the same
        /// </summary>
        /// <param name="obj">the second person to compare to</param>
        /// <returns>true if two persons are equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            string compareID = ((Person)obj).IDNumber;
            return (compareID == IDNumber);
        }

        /// <summary>
        /// used for coparing two person objects
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
