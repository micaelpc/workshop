using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using VolunteerManagementDAL;
using VolunteerManagementBL.Entities;

namespace VolunteerManagementBL
{
    /// <summary>
    /// this class defines a entity facade that contains all of the 
    /// diffrent methods and logic needed to provide the entity
    /// full functionality - create, update, delete and get.
    /// this is the base class for all the facades and includes 
    /// only the common utilities functions
    /// </summary>
    public class Facade
    {
        /// <summary>
        /// the active system user that determines the security settings
        /// </summary>
        protected User m_ActiveUser;

        /// <summary>
        /// constructor for this class
        /// </summary>
        /// <param name="currentUser">the system logged in user</param>
        public Facade(User currentUser)
        {
            m_ActiveUser = currentUser;
        }

        /// <summary>
        /// this is the db connection used in the db operations of the class
        /// </summary>
        protected DBConnection m_Connection = null;

        /// <summary>
        /// initializes the db connection
        /// </summary>
        protected void Init()
        {
            m_Connection = ConnectionQueue.Instance.GetConnection();
            while (m_Connection == null)
            {
                System.Threading.Thread.Sleep(100);
                m_Connection = ConnectionQueue.Instance.GetConnection();
            }
        }

        /// <summary>
        /// returns the db connection to the pool
        /// </summary>
        protected void Close()
        {
            ConnectionQueue.Instance.ReturnConnection(m_Connection);
        }

        /// <summary>
        /// this method checks if the current user can preform the 
        /// requested action
        /// </summary>
        /// <param name="actionType">the requested action type</param>
        /// <returns>true if the user has permissions else false</returns>
        protected bool CheckPermissions(User.ActionTypeEnum actionType)
        {
            return m_ActiveUser.CheckActionPermission(actionType);
        }
    }
}
