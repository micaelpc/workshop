using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementBL.Entities
{
    /// <summary>
    /// this abstract class defines a user entity in the system.
    /// a user is used for the definition of security and permissions 
    /// in the system. each user is of a defined user type that determines 
    /// it`s security settings
    /// </summary>
    abstract public class User
    {
        /// <summary>
        ///  the constructor for this class
        /// </summary>
        /// <param name="UserName">the unique user name in the system</param>
        /// <param name="Password">the user login password</param>
        /// <param name="VolunteerID">the id of the associated volunteer entity, if any. can be empty</param>
        /// <param name="UserType">the type of the user in the system that sets it`s permissions</param>
        public User(string UserName, string Password, string VolunteerID, UserTypeEnum UserType)
        {
            m_UserName = UserName;
            m_Password = Password;
            m_UserType = UserType;
            m_VolunteerID = VolunteerID;
        }

        /// <summary>
        /// the unique user name in the system
        /// </summary>
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        private string m_UserName;

        /// <summary>
        /// the user login password, can be empty string if password is not defined
        /// </summary>
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        private string m_Password;

        /// <summary>
        /// the id of the associated volunteer entity, if any. can be empty
        /// </summary>
        public string VolunteerID
        {
            get { return m_VolunteerID; }
            set { m_VolunteerID = value; }
        }
        private string m_VolunteerID;

        /// <summary>
        /// this enum defines the diffrent general types of actions in the system
        /// it is used to detrmine action permissions
        /// </summary>
        public enum ActionTypeEnum
        {
            UpdateEntity,
            DeleteEntity,
            CreateEntity,
            RunOperationReport,
            RunManagementReport,
            ManageUsers
        }

        /// <summary>
        /// this enum describes the diffrent user types in the system
        /// each user has a diffrent set of permissions and security settings
        /// </summary>
        public enum UserTypeEnum
        {
            מתנדב = 1,
            עובד = 2,
            מנהל = 3
        }

        /// <summary>
        /// the type of the user in the system that sets it`s permissions
        /// </summary>
        public UserTypeEnum UserType
        {
            get { return m_UserType; }
            set { m_UserType = value; }
        }
        private UserTypeEnum m_UserType;

        /// <summary>
        /// this function checks if the user can preform the requested action type
        /// </summary>
        /// <param name="actionType">the requested action type to check</param>
        /// <returns>true if the user has action permission, else false</returns>
        abstract public bool CheckActionPermission(ActionTypeEnum actionType);

        /// <summary>
        /// this method gets an array of volunteers and decides which 
        /// volunteers details can the user see according to its permissions 
        /// </summary>
        /// <param name="list">array of volunteers to filter</param>
        /// <returns>the filtered array of volunteers</returns>
        abstract public Volunteer[] FilterResults(Volunteer[] list);

        /// <summary>
        /// this method gets an array of activities and decides which 
        /// volunteers details can the user see according to its permissions 
        /// </summary>
        /// <param name="list">array of activities to filter</param>
        /// <returns>the filtered array of activities</returns>
        abstract public Activity[] FilterResults(Activity[] list);

        /// <summary>
        /// this method gets an array of users and decides which 
        /// users details can the user see according to its permissions 
        /// </summary>
        /// <param name="list">array of users to filter</param>
        /// <returns>the filtered array of users</returns>
        abstract public User[] FilterResults(User[] list);

        /// <summary>
        /// returns the user name
        /// </summary>
        /// <returns>user name</returns>
        public override string ToString()
        {
            return UserName;
        }

        /// <summary>
        /// this factory method gets the main user data and user type
        /// for a new user object and creates the correct user class
        /// according to the user type
        /// </summary>
        /// <param name="userType">the type of the user</param>
        /// <param name="UserName">the name for the user</param>
        /// <param name="Password">user`s password</param>
        /// <param name="VolunteerID">the id of the linked volunteer. empty string if there is no linked volunteer</param>
        /// <returns></returns>
        public static User CreateUser(UserTypeEnum userType, string UserName, string Password, string VolunteerID)
        {
            // check the user type and return a class of the corret type
            switch (userType)
            {
                case UserTypeEnum.מנהל:
                    return new UserAdmin(UserName, Password, VolunteerID);
                case UserTypeEnum.מתנדב:
                    return new UserVolunteer(UserName, Password, VolunteerID);
                case UserTypeEnum.עובד:
                    return new UserWorker(UserName, Password, VolunteerID);
            }
            throw new Exception("The display control type " + userType.ToString() + " is not recognized.");
        }
    }
}
