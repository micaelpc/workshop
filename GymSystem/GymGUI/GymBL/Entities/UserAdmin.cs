using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementBL.Entities
{
    /// <summary>
    /// this class is used to describe an admin user in the system. this
    /// user has full permissions in the system
    /// </summary>
    public class UserAdmin : User
    {
        /// <summary>
        /// constructor for the admin class. uses the base class
        /// </summary>
        /// <param name="UserName">the unique user name in the system</param>
        /// <param name="Password">the user login password</param>
        /// <param name="VolunteerID">the id of the associated volunteer entity, if any. can be empty</param>
        public UserAdmin(string UserName, string Password, string VolunteerID)
            : base (UserName, Password, VolunteerID, UserTypeEnum.מנהל)
        {
        }

        /// <summary>
        /// this function checks if the admin can preform the requested action type.
        /// an admin can preform all the actions in the system
        /// </summary>
        /// <param name="actionType">the requested action type to check</param>
        /// <returns>true if the user has action permission, else false</returns>
        public override bool CheckActionPermission(User.ActionTypeEnum actionType)
        {
            return true;
        }

        /// <summary>
        /// this method gets an array of volunteers and decides which 
        /// volunteers details can the user see according to its permissions .
        /// an admin can watch all the volunteers details
        /// </summary>
        /// <param name="list">array of volunteers to filter</param>
        /// <returns>the filtered array of volunteers</returns>
        public override Volunteer[] FilterResults(Volunteer[] list)
        {
            return list;
        }

        /// <summary>
        /// this method gets an array of activities and decides which 
        /// volunteers details can the user see according to its permissions 
        /// an admin can watch all the activities details
        /// </summary>
        /// <param name="list">array of activities to filter</param>
        /// <returns>the filtered array of activities</returns>
        public override Activity[] FilterResults(Activity[] list)
        {
            return list;
        }

        /// <summary>
        /// this method gets an array of users and decides which 
        /// users details can the user see according to its permissions .
        /// an admin can watch all users details
        /// </summary>
        /// <param name="list">array of users to filter</param>
        /// <returns>the filtered array of users</returns>
        public override User[] FilterResults(User[] list)
        {
            return list;
        }
    }
}
