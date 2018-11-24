using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementBL.Entities
{
    public class UserWorker : User
    {
        /// <summary>
        /// constructor for the volunteer class. uses the base class
        /// </summary>
        /// <param name="UserName">the unique user name in the system</param>
        /// <param name="Password">the user login password</param>
        /// <param name="VolunteerID">the id of the associated volunteer entity, if any. can be empty</param>

        public UserWorker(string UserName, string Password, string VolunteerID)
            : base (UserName, Password, VolunteerID, UserTypeEnum.עובד)
        {
        }

        /// <summary>
        /// this function checks if the worker can preform the requested action type.
        /// workers can do all actions except management actions
        /// </summary>
        /// <param name="actionType">the requested action type to check</param>
        /// <returns>true if the user has action permission, else false</returns>
        public override bool CheckActionPermission(User.ActionTypeEnum actionType)
        {
            switch (actionType)
            {
                case ActionTypeEnum.RunManagementReport:
                    return false;
                case ActionTypeEnum.ManageUsers:
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// this method gets an array of volunteers and decides which 
        /// volunteers details can the user see according to its permissions .
        /// a worker can watch all the volunteers details
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
        /// a worker can watch all the activities details
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
        /// a worker can only watch it`s own details
        /// </summary>
        /// <param name="list">array of users to filter</param>
        /// <returns>the filtered array of users</returns>
        public override User[] FilterResults(User[] list)
        {
            foreach (User u in list)
            {
                if (u.UserName == this.UserName)
                    return new User[] { u };
            }
            return new User[0];
        }
    }
}
