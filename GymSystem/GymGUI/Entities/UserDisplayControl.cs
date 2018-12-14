using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GymBL;
using GymBL.Entities;
using GymBL.Log;

namespace VolunteerManagementGUI.Entities
{
    /// <summary>
    /// this class implements a display control for an entity of type user
    /// </summary>
    public partial class UserDisplayControl : UserControl, IGeneralEntityDisplayControl
    {
        /// <summary>
        /// this is the class constructor
        /// </summary>
        public UserDisplayControl()
        {
            InitializeComponent();

            // get the list of user types
            Array valueList = System.Enum.GetValues(typeof(User.UserTypeEnum));

            foreach (User.UserTypeEnum value in valueList)
            {
                comboBoxPermissionType.Items.Add(value);
            }

            // get the list of volunteers in the system
            VolunteerFacade volunteerFacade = new VolunteerFacade(MainWindow.ConnectedUser);
            Volunteer[] availableVolunteers = new Volunteer[1];
            try
            {
                availableVolunteers = volunteerFacade.GetVolunteerList("", "", null, null, new DateTime(1, 1, 1), new DateTime(1, 1, 1), true);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת המתנדבים במערכת: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetVolunteerList");
                throw new Exception("נכשל ניסיון לקבל את רשימת המתנדבים במערכת", e);
            }
            foreach (Volunteer volunteer in availableVolunteers)
            {
                comboBoxVolunteerList.Items.Add(volunteer);
            }
        }

        /// <summary>
        /// this method deletes the entity from the system
        /// </summary>
        /// <returns>true if success else false</returns>
        public bool DeleteEntity()
        {
            // if the entity doesn`t exist it can`t be deleted
            if (entity != null)
            {
                
                UserFacade facade = new UserFacade(MainWindow.ConnectedUser);
                
                // chcek if the user wants the delete the volunteer linked to this user 
                // or only the user entity
                bool deleteVolunteer = false;
                if (entity.VolunteerID != "")
                {
                    DialogResult result = MessageBox.Show("האם ברצונך למחוק את המתנדב שמקושר למשתמש זה?", "מחיקת משתמש", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        deleteVolunteer = true;
                }
                // delete the user
                try
                {
                    facade.DeleteUser(entity, deleteVolunteer);
                    LoadEntity("");
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון למחוק את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "DeleteUser");
                    MessageBox.Show("נכשל ניסיון למחוק את הישות: " + e.Message, "מחיקת ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            MessageBox.Show("ישות זו אינה קיימת עדיין ולכן לא ניתן למחוק אותה", "מחיקת ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        /// <summary>
        /// this methods adds a new entity to the system
        /// </summary>
        /// <returns>true if success else false</returns>
        public bool AddEntity()
        {
            // create the new object
            Volunteer linkedVolunteer = (Volunteer)comboBoxVolunteerList.SelectedItem;
            string volunteerID = "";
            if (linkedVolunteer != null)
            {
                volunteerID = linkedVolunteer.IDNumber;
            }

            User currentUser = User.CreateUser((User.UserTypeEnum)comboBoxPermissionType.SelectedItem,
                textBoxUserName.Text,textBoxPassword.Text,volunteerID);

            entity = currentUser;

            // add the new entity to the system
            UserFacade facade = new UserFacade(MainWindow.ConnectedUser);
            try
            {
                facade.AddNewUser(currentUser);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון ליצור את ישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "AddNewUser");
                MessageBox.Show("נכשל ניסיון ליצור את ישות: " + e.Message, "יצירת ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// this method checks if all the mandatory fields are filled with data
        /// </summary>
        /// <returns>true if the data is valid else false</returns>
        private bool ValidateFormData()
        {
            if (comboBoxPermissionType.SelectedItem == null
                || textBoxPassword.Text != textBoxPasswordVerify.Text
                || textBoxUserName.Text == "")
                return false;
            else return true;
        }


        /// <summary>
        /// this method updates the current entity data
        /// </summary>
        /// <returns>true if success else false</returns>
        public bool UpdateEntity()
        {
            // check if the data is valid 
            if (!ValidateFormData())
            {
                MessageBox.Show("חלק מפרטי החובה בטופס אינם מלאים. אנא מלא אותם על מנת לעדכן את הטופס", "עדכון משתמש", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }

            // if the entity is new then execute add entity else update the current entity
            if (!IsNewEntity)
            {
                // create the updated object
                Volunteer linkedVolunteer = (Volunteer)comboBoxVolunteerList.SelectedItem;
                string volunteerID = "";
                if (linkedVolunteer != null)
                {
                    volunteerID = linkedVolunteer.IDNumber;
                }

                User currentUser = User.CreateUser((User.UserTypeEnum)comboBoxPermissionType.SelectedItem,
                    textBoxUserName.Text,textBoxPassword.Text, volunteerID);

                entity = currentUser;

                // update the data
                UserFacade facade = new UserFacade(MainWindow.ConnectedUser);
                try
                {
                    facade.UpdateUserData(currentUser);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לעדכן את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "UpdateUserData");
                    MessageBox.Show("נכשל ניסיון לעדכן את הישות: " + e.Message, "עדכון ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //System.Threading.Thread.Sleep(1000);

                return true;
            }
            else
            {
                // if new entity then add to system
                if (AddEntity())
                {
                    System.Threading.Thread.Sleep(5000);
                    if (LoadEntity(entity.UserName))
                        return true;
                    else return false;
                }
                else
                    return false;
            }
        }


        /// <summary>
        /// this method loads an entity data from the db into
        /// the control display controls
        /// </summary>
        /// <param name="entityID">the requested entity id</param>
        /// <returns>true if success else false</returns>
        public bool LoadEntity(object entityID)
        {
            // check the id provided. if empty open new form 
            // for update else load the entity data
            string entityIDString = "";
            if (entityID != null)
                entityIDString = entityID.ToString();
            // load empty entity in edit mode
            if (entityIDString == "")
            {
                IsNewEntity = true;
                SetUpdateState(true);
                entity = null;
                textBoxPassword.Text = "";
                textBoxPasswordVerify.Text = "";
                textBoxUserName.Text = "";
                comboBoxVolunteerList.SelectedItem = null;
                comboBoxPermissionType.SelectedItem = null;
            }
                // load entity data
            else
            {
                IsNewEntity = false;
                SetUpdateState(false);

                UserFacade userFacade = new UserFacade(MainWindow.ConnectedUser);
                try
                {
                    entity = userFacade.GetSingleUserData(entityIDString);

                    if (entity.VolunteerID != "")
                    {
                        VolunteerFacade volunteerFacade = new VolunteerFacade(MainWindow.ConnectedUser);
                        Volunteer linkedVolunteer = volunteerFacade.GetSingleVolunteerData(entity.VolunteerID);
                        comboBoxVolunteerList.SelectedItem = linkedVolunteer;
                    }
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לקבל נתוני מתנדב: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetSingleVolunteerData");
                    return false;
                }
                textBoxPassword.Text = entity.Password;
                textBoxPasswordVerify.Text = entity.Password;
                textBoxUserName.Text = entity.UserName;
                comboBoxPermissionType.SelectedItem = entity.UserType;
            }
            return true;
        }

        /// <summary>
        /// this method checks if the entity is in update mode
        /// </summary>
        /// <returns>true if in update mode, else false</returns>
        public bool IsUpdateable()
        {
            return updating;
        }

        /// <summary>
        /// this method changes the update mode of the entity.
        /// an entity in update mode can be saved to the db and
        /// it`s data can be changed. otherwise the entity data is
        /// readonly
        /// </summary>
        /// <param name="updateState">the desired update mode - true for update mode</param>
        public void SetUpdateState(bool updateState)
        {
            if (updateState)
            {
                textBoxPassword.Enabled = true;
                textBoxPasswordVerify.Enabled = true;
                textBoxUserName.Enabled = true;
                comboBoxVolunteerList.Enabled = true;
                comboBoxPermissionType.Enabled = true;
                updating = true;
            }
            else
            {
                textBoxPassword.Enabled = false;
                textBoxPasswordVerify.Enabled = false;
                textBoxUserName.Enabled = false;
                comboBoxVolunteerList.Enabled = false;
                comboBoxPermissionType.Enabled = false;
                updating = false;
            }
        }

        /// <summary>
        /// this entity gets the entity name for the form caption
        /// </summary>
        /// <returns>the current entity name</returns>
        public string GetEntityName()
        {
            if (IsNewEntity)
                return "משתמש חדש";
            else return entity.ToString();
        }

        // this boolean indicates if the entity is in update mode
        private bool updating = false;

        // this boolean indicates if the entity is a new one
        private bool IsNewEntity = false;

        // this is the instance of the entity - the actual entity object
        private User entity;


    }
}
