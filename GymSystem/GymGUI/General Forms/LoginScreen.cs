using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VolunteerManagementBL.Entities;
using VolunteerManagementBL;
using VolunteerManagementBL.Log;

namespace VolunteerManagementGUI
{
    /// <summary>
    /// this form is the login screen of the system. it is loaded at the
    /// start of the application execution and verifies the user identity.
    /// after the user login it sets the connected user object for the
    /// use of the other system components
    /// </summary>
    public partial class LoginScreen : Form
    {
        /// <summary>
        /// this is the constructor for this class
        /// </summary>
        /// <param name="setUserDelegateFunction">this is a delegate that is used to set the connected user object value after the login</param>
        /// <param name="closeDelegateFunction">this delegate is used when the login is aborted and the system needs to be closed</param>
        public LoginScreen(SetConnectedUser setUserDelegateFunction, CloseSystem closeDelegateFunction)
        {
            InitializeComponent();
            m_SetConnectedUser = setUserDelegateFunction;
            m_CloseSystem = closeDelegateFunction;
        }

        /// <summary>
        /// this delegate allows is used to set the identity of the 
        /// connected user in the main form
        /// </summary>
        /// <param name="connectedUserName">the connected user name</param>
        public delegate void SetConnectedUser(string connectedUserName);
        private SetConnectedUser m_SetConnectedUser;

        /// <summary>
        /// this delegate is used when the system needs to be closed
        /// </summary>
        public delegate void CloseSystem();
        private CloseSystem m_CloseSystem;

        /// <summary>
        /// this method is activated when the user tries to login.
        /// it verifies the user login data and sets the connected user identity
        /// if the login is successful
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonApproveLogin_Click(object sender, EventArgs e)
        {
            // try to login
            UserFacade facade = new UserFacade(MainWindow.ConnectedUser);
            bool answer = false;
            try
            {
                answer = facade.LoginUser(textBoxUserName.Text, textBoxUserPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("נכשל ניסיון להיכנס למערכת: " + ex.Message, "כניסה למערכת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if the login is successful set the connected user object
            // and close this form, else show the user a proper message
            if (answer)
            {
                try
                {
                    m_SetConnectedUser(textBoxUserName.Text);
                }
                catch(Exception ex)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון להיכנס למערכת: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "LoginUser");
                    MessageBox.Show("נכשל ניסיון להיכנס למערכת: " + ex.Message, "כניסה למערכת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("אחד מהפרטים שהכנסת אינו נכון. בדוק שוב את שם המשתמש והסיסמא", "כניסה למערכת", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }

        /// <summary>
        /// this method is activated when the user cancels his login and
        /// as a result closes the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelLogin_Click(object sender, EventArgs e)
        {
            m_CloseSystem();
        }

    }
}
