using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VolunteerManagementBL.Entities
{
    public class UserVolunteer : User
    {
        /// <summary>
        /// constructor for the volunteer class. uses the base class
        /// </summary>
        /// <param name="UserName">the unique user name in the system</param>
        /// <param name="Password">the user login password</param>
        /// <param name="VolunteerID">the id of the associated volunteer entity, if any. can be empty</param>

        public UserVolunteer(string UserName, string Password, string VolunteerID)
            : base (UserName, Password, VolunteerID, UserTypeEnum.מתנדב)
        {
        }

        /// <summary>
        /// this function checks if the volunteer can preform the requested action type.
        /// a volunteer can only preform the basic system actions of create and update
        /// </summary>
        /// <param name="actionType">the requested action type to check</param>
        /// <returns>true if the user has action permission, else false</returns>
        public override bool CheckActionPermission(User.ActionTypeEnum actionType)
        {
            switch (actionType)
            {
                case ActionTypeEnum.CreateEntity:
                    return true;
                case ActionTypeEnum.UpdateEntity:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// this method gets an array of volunteers and decides which 
        /// volunteers details can the user see according to its permissions .
        /// a volunteer can only watch it`s linked volunteer details
        /// </summary>
        /// <param name="list">array of volunteers to filter</param>
        /// <returns>the filtered array of volunteers</returns>
        public override Volunteer[] FilterResults(Volunteer[] list)
        {
            if (this.VolunteerID == "")
                return new Volunteer[0];

            foreach(Volunteer v in list)
            {
                if (v.IDNumber == this.VolunteerID)
                    return new Volunteer[]{v};
            }
            return new Volunteer[0];
        }

        /// <summary>
        /// this method gets an array of activities and decides which 
        /// volunteers details can the user see according to its permissions 
        /// a volunteer can watch only activities that he is assigned to
        /// </summary>
        /// <param name="list">array of activities to filter</param>
        /// <returns>the filtered array of activities</returns>
        public override Activity[] FilterResults(Activity[] list)
        {
            if (this.VolunteerID == "")
                return new Activity[0];

            VolunteerFacade facade = new VolunteerFacade(this);
            Activity[] volunteerActivityList = facade.GetSingleVolunteerData(this.VolunteerID).ActivityLog;
            Stack activities = new Stack();
            foreach (Activity current in list)
            {
                foreach (Activity a in volunteerActivityList)
                {
                    if (current.ID == a.ID)
                    {
                        activities.Push(current);
                        break;
                    }
                }
            }
            Activity[] finalResult = new Activity[activities.Count];
            for (int i =0; i< finalResult.Length;i++)
            {
                finalResult[i] = (Activity)activities.Pop();
            }
            return finalResult;
        }

        /// <summary>
        /// this method gets an array of users and decides which 
        /// users details can the user see according to its permissions .
        /// a volunteer can only watch it`s own details
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
