using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VolunteerManagementBL;
using VolunteerManagementBL.Entities;
using VolunteerManagementBL.Log;

namespace VolunteerManagementGUI.Entities
{
    /// <summary>
    /// this class implements a display control for an entity of type reminder
    /// </summary>
    public partial class ReminderDisplayControl : UserControl, IGeneralEntityDisplayControl
    {
        /// <summary>
        /// this is the class constructor
        /// </summary>
        public ReminderDisplayControl()
        {
            InitializeComponent();

            //get the list of the diffrent cyclic timing values for a reminder
            Array valueList = System.Enum.GetValues(typeof(Activity.TimingEnum));

            foreach (Activity.TimingEnum value in valueList)
            {
                comboBoxTimingType.Items.Add(value);
            }

            // get the list of users in the system
            UserFacade facade = new UserFacade(MainWindow.ConnectedUser);
            User[] users = new User[1];
            try
            {
                users = facade.GetUserList("", "");
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת המשתמשים במערכת: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetUserList");
                throw new Exception("נכשל ניסיון לקבל את רשימת המשתמשים במערכת", e);
            }
            foreach (User user in users)
            {
                comboBoxUserList.Items.Add(user);
            }
            
        }

        /// <summary>
        /// this method deletes the entity from the system
        /// </summary>
        /// <returns>true if success else false</returns>
        public bool DeleteEntity()
        {
            // an entity can be erased only if it already exists in the system
            if (entity != null)
            {
                // delete the reminder from the system
                ReminderFacade facade = new ReminderFacade(MainWindow.ConnectedUser);
                try
                {
                    facade.DeleteReminder(entity.ID);
                    LoadEntity("");
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון למחוק את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "DeleteReminder");
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
            bool isAttended = false;
            if (comboBoxAttentionStatus.SelectedIndex == 0)
                isAttended = true;
            Reminder currentReminder = new Reminder("",textBoxDescription.Text,
                dateTimePickerNextReminderDate.Value, isAttended, (Activity.TimingEnum)comboBoxTimingType.SelectedItem,
                ((User)comboBoxUserList.SelectedItem).UserName);

            entity = currentReminder;

            // add the new object to the system
            ReminderFacade facade = new ReminderFacade(MainWindow.ConnectedUser);
            try
            {
                entity.ID = facade.AddNewReminder(currentReminder);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון ליצור את ישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "AddNewReminder");
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
            if (comboBoxUserList.SelectedItem == null
                || comboBoxTimingType.SelectedItem == null
                || textBoxDescription.Text == "")
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
                MessageBox.Show("חלק מפרטי החובה בטופס אינם מלאים. אנא מלא אותם על מנת לעדכן את הטופס", "עדכון תזכורת", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }

            // if the entity is new then execute add entity else update the current entity
            if (!IsNewEntity)
            {
                // create the updated object
                bool isAttended = false;
                if (comboBoxAttentionStatus.SelectedIndex == 0)
                    isAttended = true;
                Reminder currentReminder = new Reminder(entity.ID, textBoxDescription.Text,
                    dateTimePickerNextReminderDate.Value, isAttended, (Activity.TimingEnum)comboBoxTimingType.SelectedItem,
                    ((User)comboBoxUserList.SelectedItem).UserName);

                entity = currentReminder;

                // update the data
                ReminderFacade facade = new ReminderFacade(MainWindow.ConnectedUser);
                try
                {
                    facade.UpdateReminderData(currentReminder);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לעדכן את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "UpdateReminderData");
                    MessageBox.Show("נכשל ניסיון לעדכן את הישות: " + e.Message, "עדכון ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //System.Threading.Thread.Sleep(1000);

                return true;
            }
            // if new entity then add to system
            else
            {
                if (AddEntity())
                {
                    System.Threading.Thread.Sleep(5000);
                    if (LoadEntity(entity.ID))
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
            // open empty entity for edit
            if (entityIDString == "")
            {
                IsNewEntity = true;
                SetUpdateState(true);
                entity = null;
                textBoxDescription.Text = "";
                dateTimePickerNextReminderDate.Value = DateTime.Now;
                comboBoxUserList.SelectedItem = null;
                comboBoxTimingType.SelectedIndex = 0;
                comboBoxAttentionStatus.SelectedIndex = 1;
            }
                // load entity data
            else
            {
                IsNewEntity = false;
                SetUpdateState(false);

                ReminderFacade facade = new ReminderFacade(MainWindow.ConnectedUser);
                try
                {
                    entity = facade.GetSingleReminderData(entityIDString);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לקבל נתוני תזכורת: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetSingleReminderData");
                    return false;
                }

                textBoxDescription.Text = entity.Content;
                dateTimePickerNextReminderDate.Value = entity.ReminderTime;
                comboBoxTimingType.SelectedItem = entity.Timing;
                if (entity.IsAttended)
                    comboBoxAttentionStatus.SelectedIndex = 0;
                else
                    comboBoxAttentionStatus.SelectedIndex = 1;

                foreach (User value in comboBoxUserList.Items)
                {
                    if (value.UserName == entity.UserName)
                        comboBoxUserList.SelectedItem = value;
                }
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
                textBoxDescription.Enabled = true;
                dateTimePickerNextReminderDate.Enabled = true;
                comboBoxUserList.Enabled = true;
                comboBoxTimingType.Enabled = true;
                comboBoxAttentionStatus.Enabled = true;
                updating = true;
            }
            else
            {
                textBoxDescription.Enabled = false;
                dateTimePickerNextReminderDate.Enabled = false;
                comboBoxUserList.Enabled = false;
                comboBoxTimingType.Enabled = false;
                comboBoxAttentionStatus.Enabled = false;
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
                return "תזכורת חדשה";
            else return entity.ToString();
        }

        // this boolean indicates if the entity is in update mode
        private bool updating = false;

        // this boolean indicates if the entity is a new one
        private bool IsNewEntity = false;

        // this is the instance of the entity - the actual entity object
        private Reminder entity;


    }
}
