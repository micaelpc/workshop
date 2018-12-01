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
    /// this class implements a display control for an entity of type volunteer
    /// </summary>
    public partial class VolunteerDisplayControl : UserControl, IGeneralEntityDisplayControl
    {
        /// <summary>
        /// this is the class constructor
        /// </summary>
        public VolunteerDisplayControl()
        {
            InitializeComponent();
            // get the list of voluneer types
            Array valueList = System.Enum.GetValues(typeof(Volunteer.VolunteerTypeEnum));

            foreach (Volunteer.VolunteerTypeEnum value in valueList)
            {
                comboBoxVolunteerType.Items.Add(value);
            }

            // get the list of week days
            valueList = System.Enum.GetValues(typeof(DayOfWeek));

            foreach (DayOfWeek value in valueList)
            {
                comboBoxAvailabilityDay.Items.Add(value);
            }

            // get the list of activity types
            ActivityTypeFacade facade = new ActivityTypeFacade(MainWindow.ConnectedUser);
            ActivityType[] list = new ActivityType[1];
            try
            {
                list = facade.GetActivityTypesList();
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת סוגי הפעילויות במערכת: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivityTypesList");
                throw new Exception("נכשל ניסיון לקבל את רשימת סוגי הפעילויות במערכת", e);
            }
            foreach (ActivityType value in list)
            {
                checkedListBoxActivityTypes.Items.Add(value);
            }
            
        }

        /// <summary>
        /// this method deletes the entity from the system
        /// </summary>
        /// <returns>true if success else false</returns>
        public bool DeleteEntity()
        {
            // if the entity doesn`t exist yet it can`t be deleted
            if (textBoxIDNumber.Text != "")
            {
                // delete the volnteer
                VolunteerFacade facade = new VolunteerFacade(MainWindow.ConnectedUser);
                try
                {
                    facade.DeleteVolunteer(textBoxIDNumber.Text);
                    LoadEntity("");
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון למחוק את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "DeleteVolunteer");
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
            TimeSpanOfWeek[] vatArray = new TimeSpanOfWeek[listBoxAvailability.Items.Count];
            for (int i = 0; i < listBoxAvailability.Items.Count; i++)
            {
                vatArray[i] = (TimeSpanOfWeek)listBoxAvailability.Items[i];
            }

            ActivityType[] actArray = new ActivityType[checkedListBoxActivityTypes.CheckedItems.Count];
            for (int i = 0; i < checkedListBoxActivityTypes.CheckedItems.Count; i++)
            {
                actArray[i] = (ActivityType)checkedListBoxActivityTypes.CheckedItems[i];
            }

            Volunteer newVolunteer = new Volunteer(textBoxIDNumber.Text, textBoxFirstname.Text,
            textBoxSurname.Text, textBoxAddress.Text, textBoxHomePhone.Text,
            textBoxCellPhone.Text, textBoxEMail.Text, dateTimePickerBirthdate.Value,
            textBoxComment.Text, (Volunteer.VolunteerTypeEnum)Enum.Parse(typeof(Volunteer.VolunteerTypeEnum), comboBoxVolunteerType.Text),
            vatArray, actArray);

            // add the new entity to the system
            entity = newVolunteer;
            VolunteerFacade facade = new VolunteerFacade(MainWindow.ConnectedUser);
            try
            {
                facade.AddNewVolunteer(newVolunteer);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון ליצור את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "AddNewVolunteer");
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
            if (textBoxIDNumber.Text == ""
                || (textBoxFirstname.Text == "" && textBoxSurname.Text == "")
                || (textBoxHomePhone.Text == "" && textBoxCellPhone.Text == "" && textBoxAddress.Text == "" && textBoxEMail.Text == "")
                || comboBoxVolunteerType.SelectedItem == null
                || checkedListBoxActivityTypes.CheckedItems.Count == 0)
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
                MessageBox.Show("חלק מפרטי החובה בטופס אינם מלאים. אנא מלא אותם על מנת לעדכן את הטופס", "עדכון מתנדב", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }

            // if the entity is new then execute add entity else update the current entity
            if (!IsNewEntity)
            {
                // create the updated object
                TimeSpanOfWeek[] vatArray = new TimeSpanOfWeek[listBoxAvailability.Items.Count];
                for(int i =0; i< listBoxAvailability.Items.Count;i++)
                {
                    vatArray[i] = (TimeSpanOfWeek)listBoxAvailability.Items[i];
                }

                ActivityType[] actArray = new ActivityType[checkedListBoxActivityTypes.CheckedItems.Count];
                for (int i = 0; i < checkedListBoxActivityTypes.CheckedItems.Count; i++)
                {
                    actArray[i] = (ActivityType)checkedListBoxActivityTypes.CheckedItems[i];
                }

                Volunteer currentVolunteer = new Volunteer(textBoxIDNumber.Text, textBoxFirstname.Text,
                textBoxSurname.Text, textBoxAddress.Text, textBoxHomePhone.Text,
                textBoxCellPhone.Text, textBoxEMail.Text, dateTimePickerBirthdate.Value,
                textBoxComment.Text, (Volunteer.VolunteerTypeEnum)Enum.Parse(typeof(Volunteer.VolunteerTypeEnum), comboBoxVolunteerType.Text),
                vatArray, actArray);

                entity = currentVolunteer;

                // update the data
                VolunteerFacade facade = new VolunteerFacade(MainWindow.ConnectedUser);
                try
                {
                    facade.UpdateVolunteerData(currentVolunteer);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לעדכן את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "UpdateVolunteerData");
                    MessageBox.Show("נכשל ניסיון לעדכן את הישות: " + e.Message, "עדכון ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            else
            {
                // if new entity then add to system
                if (AddEntity())
                {
                    IsNewEntity = false;
                    return true;
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
            // load empty entity for edit
            if (entityIDString == "")
            {
                IsNewEntity = true;
                SetUpdateState(true);
                entity = null;
                textBoxAddress.Text = "";
                textBoxCellPhone.Text = "";
                textBoxComment.Text = "";
                textBoxEMail.Text = "";
                textBoxFirstname.Text = "";
                textBoxHomePhone.Text = "";
                textBoxIDNumber.Text = "";
                textBoxSurname.Text = "";
                dateTimePickerBirthdate.Value = DateTime.Now;
                comboBoxVolunteerType.SelectedItem = null;
                listBoxAvailability.Items.Clear();
                bindingSourceActivities.Clear();
                
                dateTimePickerLastActivity.Value = new DateTime(2000,1,1);

                for (int i=0;i<checkedListBoxActivityTypes.Items.Count;i++)
                {
                    checkedListBoxActivityTypes.SetItemChecked(i,false);
                }
            }
                // load entity data
            else
            {
                IsNewEntity = false;
                SetUpdateState(false);
                VolunteerFacade facade = new VolunteerFacade(MainWindow.ConnectedUser);
                try
                {
                    entity = facade.GetSingleVolunteerData(entityIDString);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לקבל נתוני מתנדב: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetSingleVolunteerData");
                    return false;
                }
                textBoxAddress.Text = entity.Address;
                textBoxCellPhone.Text = entity.CellPhone;
                textBoxComment.Text = entity.Comment;
                textBoxEMail.Text = entity.EMail;
                textBoxFirstname.Text = entity.Firstname;
                textBoxHomePhone.Text = entity.HomePhone;
                textBoxIDNumber.Text = entity.IDNumber;
                textBoxSurname.Text = entity.Surname;
                dateTimePickerBirthdate.Value = entity.Birthdate;
                comboBoxVolunteerType.SelectedItem = entity.VolunteerType;
                foreach(TimeSpanOfWeek time in entity.VolunteerAvailability)
                {
                    listBoxAvailability.Items.Add(time);
                }
                DateTime latestActivityDate = new DateTime(2000, 1, 1);
                foreach(Activity activity in entity.ActivityLog)
                {
                    if (activity.EndDate> latestActivityDate)
                        latestActivityDate = activity.EndDate;
                    bindingSourceActivities.Add(activity);
                }
                dateTimePickerLastActivity.Value = latestActivityDate;
                foreach (ActivityType activityType in entity.ActivityTypes)
                {
                    for(int i=0;i< checkedListBoxActivityTypes.Items.Count;i++)
                    {
                        if (checkedListBoxActivityTypes.Items[i].ToString() == activityType.ToString())
                        {
                            checkedListBoxActivityTypes.SetItemChecked(i,true);
                            break;
                        }
                    }                    
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
                textBoxAddress.Enabled = true;
                textBoxCellPhone.Enabled = true;
                textBoxComment.Enabled = true;
                textBoxEMail.Enabled = true;
                textBoxFirstname.Enabled = true;
                textBoxHomePhone.Enabled = true;
                textBoxIDNumber.Enabled = true;
                textBoxSurname.Enabled = true;
                dateTimePickerBirthdate.Enabled = true;
                comboBoxVolunteerType.Enabled = true;
                listBoxAvailability.Enabled = true;
                checkedListBoxActivityTypes.Enabled = true;
                buttonAddAvailabilityRecord.Enabled = true;
                buttonDeleteAvailabilityRecord.Enabled = true;
                updating = true;
            }
            else
            {
                textBoxAddress.Enabled = false;
                textBoxCellPhone.Enabled = false;
                textBoxComment.Enabled = false;
                textBoxEMail.Enabled = false;
                textBoxFirstname.Enabled = false;
                textBoxHomePhone.Enabled = false;
                textBoxIDNumber.Enabled = false;
                textBoxSurname.Enabled = false;
                dateTimePickerBirthdate.Enabled = false;
                comboBoxVolunteerType.Enabled = false;
                listBoxAvailability.Enabled = false;
                checkedListBoxActivityTypes.Enabled = false;
                buttonAddAvailabilityRecord.Enabled = false;
                buttonDeleteAvailabilityRecord.Enabled = false;
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
                return "מתנדב חדש";
            else return entity.ToString();
        }

        // this boolean indicates if the entity is in update mode
        private bool updating = false;

        // this boolean indicates if the entity is a new one
        private bool IsNewEntity = false;

        // this is the instance of the entity - the actual entity object
        private Volunteer entity;

        /// <summary>
        /// this method adds a new Availability record to the volunteers 
        /// availability list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAvailabilityRecord_Click(object sender, EventArgs e)
        {
            TimeSpanOfWeek newAvailabilityTime = new TimeSpanOfWeek((DayOfWeek)comboBoxAvailabilityDay.SelectedItem,
                                                                Convert.ToInt32(comboBoxAvailabilityStartHour.SelectedItem),
                                                                Convert.ToInt32(comboBoxAvailabilityEndHour.SelectedItem));
            listBoxAvailability.Items.Add(newAvailabilityTime);
        }

        /// <summary>
        /// this method removes the selected Availability record from the volunteers 
        /// availability list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteAvailabilityRecord_Click(object sender, EventArgs e)
        {
            if (listBoxAvailability.SelectedItem != null)
            {
                listBoxAvailability.Items.Remove(listBoxAvailability.SelectedItem);
            }
        }
    }
}
