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
    /// this class implements a display control for an entity of type Activity
    /// </summary>
    public partial class ActivityDisplayControl : UserControl, IGeneralEntityDisplayControl
    {
        /// <summary>
        /// this is the class constructor
        /// </summary>
        public ActivityDisplayControl()
        {
            InitializeComponent();

            // get the list of activity types
            ActivityTypeFacade facade = new ActivityTypeFacade(MainWindow.ConnectedUser);
            ActivityType[] list = new ActivityType[1];
            try
            {
                list = facade.GetActivityTypesList();
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת סוגי הפעילויות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivityTypesList");
                throw new Exception("נכשל ניסיון לקבל את רשימת סוגי הפעילויות",e);
            }

            foreach (ActivityType value in list)
            {
                comboBoxActivityType.Items.Add(value);
            }

            // get the list of the diffrent cycle timing options for an activity
            Array valueList = System.Enum.GetValues(typeof(Activity.TimingEnum));

            foreach (Activity.TimingEnum value in valueList)
            {
                comboBoxActivityTiming.Items.Add(value);
            }
        }

        /// <summary>
        /// this method deletes the entity from the system
        /// </summary>
        /// <returns>true if success else false</returns>
        public bool DeleteEntity()
        {
            // if the entity already exists in the system it can be erased
            if (entity.ID > 0)
            {
                // check if the user wants to delete the entire activity 
                // series - if this activity is part of a series
                bool deleteActivitySeries = false;
                if (entity.TimingType != Activity.TimingEnum.חד_פעמי)
                {
                    DialogResult result = MessageBox.Show("האם ברצונך למחוק את כל סדרת הפעילויות? לחיצה על אישור תמחק את כל הפעילויות העתידיות שמשויכות לסדרת פעילויות זו, ולחיצה על ביטול תמחק רק את הפעילות הנוכחית", "מחיקת פעילות", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    if (result == DialogResult.Yes)
                    {
                        deleteActivitySeries = true;
                    }
                }

                // delete the activity 
                ActivityFacade facade = new ActivityFacade(MainWindow.ConnectedUser);
                try
                {
                    facade.DeleteActivity(entity.ID, deleteActivitySeries);
                    LoadEntity(0);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון למחוק את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "DeleteActivity");
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
            //create the new activity object
            Volunteer[] volunteerArray = new Volunteer[listBoxAssignedVolunteers.Items.Count];
            for (int i = 0; i < listBoxAssignedVolunteers.Items.Count; i++)
            {
                volunteerArray[i] = (Volunteer)listBoxAssignedVolunteers.Items[i];
            }

            Activity currentActivity = new Activity(textBoxDescription.Text,
                dateTimePickerActivityStartTime.Value, dateTimePickerActivityEndTime.Value,
                textBoxLocation.Text, (ActivityType)comboBoxActivityType.SelectedItem,
                (Activity.TimingEnum)Enum.Parse(typeof(Activity.TimingEnum), comboBoxActivityTiming.Text),
                dateTimePickerActivityTimingFinishDate.Value,
                volunteerArray);

            entity = currentActivity;

            // add the new entity to the system
            ActivityFacade facade = new ActivityFacade(MainWindow.ConnectedUser);
            try
            {
                facade.AddNewActivity(currentActivity, -1);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון ליצור את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "AddNewActivity");
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
            if (comboBoxActivityTiming.SelectedItem == null
                || comboBoxActivityType.SelectedItem == null
                || dateTimePickerActivityStartTime.Value > dateTimePickerActivityEndTime.Value)
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
                MessageBox.Show("חלק מפרטי החובה בטופס אינם מלאים. אנא מלא אותם על מנת לעדכן את הטופס", "עדכון פעילות", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }

            // if the entity is new then execute add entity else update the current entity
            if (!IsNewEntity)
            {
                // create the new updated object
                Volunteer[] volunteerArray = new Volunteer[listBoxAssignedVolunteers.Items.Count];
                for(int i =0; i< listBoxAssignedVolunteers.Items.Count;i++)
                {
                    volunteerArray[i] = (Volunteer)listBoxAssignedVolunteers.Items[i];
                }

                Activity currentActivity = new Activity(entity.ID, textBoxDescription.Text,
                    dateTimePickerActivityStartTime.Value, dateTimePickerActivityEndTime.Value,
                    textBoxLocation.Text,(ActivityType)comboBoxActivityType.SelectedItem,
                    (Activity.TimingEnum)Enum.Parse(typeof(Activity.TimingEnum), comboBoxActivityTiming.Text),
                    dateTimePickerActivityTimingFinishDate.Value,
                    volunteerArray);

                // check if the user wants to update the entire activity series
                // if the activity is part of a series of activities
                bool changeTiming = false;
                if (entity.ActivityTimingFinishDate != currentActivity.ActivityTimingFinishDate
                    || entity.TimingType != currentActivity.TimingType)
                {
                    DialogResult result = MessageBox.Show("התבצע שינוי בפרטי סדרת הפעילויות. האם ברצונך לאשר שינוי זה? אישור השינוי יגרום למחיקה של כל הפעילויות העתידיות של הסדרה ולהקצאה של פעילויות חדשות במקומן", "עדכון סדרת פעילויות", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    if (result == DialogResult.Yes)
                        changeTiming = true;
                    else
                    {
                        comboBoxActivityTiming.SelectedItem = entity.TimingType;
                        dateTimePickerActivityTimingFinishDate.Value = entity.ActivityTimingFinishDate;
                    }
                }

                entity = currentActivity;
                // update the entity data
                ActivityFacade facade = new ActivityFacade(MainWindow.ConnectedUser);
                try
                {
                    facade.UpdateActivityData(currentActivity,changeTiming);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לעדכן את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "UpdateActivityData");
                    MessageBox.Show("נכשל ניסיון לעדכן את הישות: " + e.Message, "עדכון ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //System.Threading.Thread.Sleep(1000);

                return true;
            }
            // add the new entity to the system
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
            IsLoading = true;
            int entityIDInt = 0;

            if (entityID != null)
            {
                try
                {
                    entityIDInt = Convert.ToInt32(entityID);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("מזהה לא תקין עבור פעילות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivityID");
                    return false;
                }
            }
            // open empty form for edit
            if (entityIDInt == 0)
            {
                IsNewEntity = true;
                SetUpdateState(true);
                entity = null;
                textBoxLocation.Text = "";
                textBoxDescription.Text = "";
                comboBoxActivityType.SelectedItem = null;
                dateTimePickerActivityStartTime.Value = DateTime.Now;
                dateTimePickerActivityEndTime.Value = DateTime.Now;
                dateTimePickerActivityEndTime.Value = DateTime.Now;
                listBoxAssignedVolunteers.Items.Clear();
                comboBoxActivityTiming.SelectedItem = null;
            }
            // load the entity data
            else
            {
                IsNewEntity = false;
                SetUpdateState(false);
                ActivityFacade facade = new ActivityFacade(MainWindow.ConnectedUser);
                try
                {
                    entity = facade.GetSingleActivityData(entityIDInt);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לקבל נתוני פעילות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetSingleActivityData");
                    return false;
                }
                textBoxLocation.Text = entity.Location;
                textBoxDescription.Text = entity.Description;
                for (int i = 0; i < comboBoxActivityType.Items.Count; i++)
                {
                    if (comboBoxActivityType.Items[i].ToString() == entity.Type.ToString())
                    {
                        comboBoxActivityType.SelectedIndex = i;
                        break;
                    }
                }
                comboBoxActivityTiming.SelectedItem = entity.TimingType;
                dateTimePickerActivityStartTime.Value = entity.StartDate;
                dateTimePickerActivityEndTime.Value = entity.EndDate;
                dateTimePickerActivityTimingFinishDate.Value = entity.ActivityTimingFinishDate;
                listBoxAssignedVolunteers.Items.Clear();
                foreach (Volunteer volunteer in entity.Volunteers)
                {
                    listBoxAssignedVolunteers.Items.Add(volunteer);
                }
                VolunteerFacade volunteerFacade = new VolunteerFacade(MainWindow.ConnectedUser);
                try
                {
                    Volunteer[] availableVolunteers = volunteerFacade.GetVolunteerList("", "", entity.Type, new VolunteerAvailabilityTime(entity.StartDate.DayOfWeek, entity.StartDate.Hour, entity.EndDate.Hour), new DateTime(1, 1, 1), new DateTime(1, 1, 1), true);
                    listBoxAvailableVolunteers.Items.Clear();
                    foreach (Volunteer volunteer in availableVolunteers)
                    {
                        listBoxAvailableVolunteers.Items.Add(volunteer);
                    }
                    Volunteer[] unAvailableVolunteers = volunteerFacade.GetVolunteerList("", "", entity.Type, new VolunteerAvailabilityTime(entity.StartDate.DayOfWeek, entity.StartDate.Hour, entity.EndDate.Hour), new DateTime(1, 1, 1), new DateTime(1, 1, 1), false);
                    listBoxNotAvailableVolunteers.Items.Clear();
                    foreach (Volunteer volunteer in unAvailableVolunteers)
                    {
                        listBoxNotAvailableVolunteers.Items.Add(volunteer);
                    }
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לקבל רשימת מתנדבים: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetVolunteerList");
                    return false;
                }
            }
            IsLoading = false;
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
                textBoxLocation.Enabled = true;
                comboBoxActivityType.Enabled = true;
                dateTimePickerActivityStartTime.Enabled = true;
                dateTimePickerActivityEndTime.Enabled = true;
                buttonAddAvailableVolunteer.Enabled = true;
                buttonAddNotAvailableVolunteer.Enabled = true;
                buttonClearAssignedVolunteers.Enabled = true;
                buttonRemoveAssignedVolunteer.Enabled = true;
                comboBoxActivityTiming.Enabled = true;
                dateTimePickerActivityTimingFinishDate.Enabled = true;
                updating = true;
            }
            else
            {
                textBoxDescription.Enabled = false;
                textBoxLocation.Enabled = false;
                comboBoxActivityType.Enabled = false;
                dateTimePickerActivityStartTime.Enabled = false;
                dateTimePickerActivityEndTime.Enabled = false;
                buttonAddAvailableVolunteer.Enabled = false;
                buttonAddNotAvailableVolunteer.Enabled = false;
                buttonClearAssignedVolunteers.Enabled = false;
                buttonRemoveAssignedVolunteer.Enabled = false;
                comboBoxActivityTiming.Enabled = false;
                dateTimePickerActivityTimingFinishDate.Enabled = false;
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
                return "פעילות חדשה";
            else return entity.ToString();
        }

        // this boolean indicates if the entity is in update mode
        private bool updating = false;

        // this boolean indicates if the entity is a new one
        private bool IsNewEntity = false;

        // this is the instance of the entity - the actual entity object
        private Activity entity;

        /// <summary>
        /// this method changed the activity basic data according to it`s type.
        /// every time the type changes then the basic fields change too
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxActivityType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                ActivityType type = (ActivityType)comboBoxActivityType.SelectedItem;
                textBoxLocation.Text = type.Location;
                textBoxDescription.Text = type.Description;
            }
        }

        // this indicates if the entity is loading at the current time
        private bool IsLoading = true;

        /// <summary>
        /// this method adds the selected volunteer from the Available Volunteer list
        /// to the assinged volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAvailableVolunteer_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableVolunteers.SelectedItem != null
                && IsUpdateable() == true)
            {
                for (int i = 0; i < listBoxAssignedVolunteers.Items.Count; i++)
                {
                    if (((Volunteer)listBoxAssignedVolunteers.Items[i]).IDNumber == ((Volunteer)listBoxAvailableVolunteers.SelectedItem).IDNumber)
                        return;
                }
                listBoxAssignedVolunteers.Items.Add(listBoxAvailableVolunteers.SelectedItem);
            }
        }

        /// <summary>
        /// this method adds the selected volunteer from the not Available Volunteer list
        /// to the assinged volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddNotAvailableVolunteer_Click(object sender, EventArgs e)
        {
            if (listBoxNotAvailableVolunteers.SelectedItem != null
                && IsUpdateable() == true)
            {
                for (int i = 0; i < listBoxAssignedVolunteers.Items.Count; i++)
                {
                    if (((Volunteer)listBoxAssignedVolunteers.Items[i]).IDNumber == ((Volunteer)listBoxNotAvailableVolunteers.SelectedItem).IDNumber)
                        return;
                }
                listBoxAssignedVolunteers.Items.Add(listBoxNotAvailableVolunteers.SelectedItem);
            }
        }

        /// <summary>
        /// this method removes the selectes volunteer from the assigned volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveAssignedVolunteer_Click(object sender, EventArgs e)
        {
            listBoxAssignedVolunteers.Items.Remove(listBoxAssignedVolunteers.SelectedItem);
        }

        /// <summary>
        /// this method clears the assinged volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearAssignedVolunteers_Click(object sender, EventArgs e)
        {
            listBoxAssignedVolunteers.Items.Clear();
        }

        /// <summary>
        /// this method adds the selected volunteer from the Available Volunteer list
        /// to the assinged volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxAvailableVolunteers_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxAvailableVolunteers.SelectedItem != null
                && IsUpdateable() == true)
            {
                for (int i = 0; i < listBoxAssignedVolunteers.Items.Count; i++)
                {
                    if (((Volunteer)listBoxAssignedVolunteers.Items[i]).IDNumber == ((Volunteer)listBoxAvailableVolunteers.SelectedItem).IDNumber)
                        return;
                }
                listBoxAssignedVolunteers.Items.Add(listBoxAvailableVolunteers.SelectedItem);
            }
        }

        /// <summary>
        /// this method adds the selected volunteer from the not Available Volunteer list
        /// to the assinged volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxNotAvailableVolunteers_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxNotAvailableVolunteers.SelectedItem != null
                && IsUpdateable() == true)
            {
                for (int i = 0; i < listBoxAssignedVolunteers.Items.Count; i++)
                {
                    if (((Volunteer)listBoxAssignedVolunteers.Items[i]).IDNumber == ((Volunteer)listBoxNotAvailableVolunteers.SelectedItem).IDNumber)
                        return;
                }
                listBoxAssignedVolunteers.Items.Add(listBoxNotAvailableVolunteers.SelectedItem);
            }
        }

        /// <summary>
        /// this method removes the selected volunteer from the assinged Volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxAssignedVolunteers_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxAssignedVolunteers.SelectedItem != null
                && IsUpdateable() == true)
            {
                listBoxAssignedVolunteers.Items.Remove(listBoxAssignedVolunteers.SelectedItem);
            }
        }

        /// <summary>
        /// this method opens the entity window for the selected volunteer
        /// in the Assigned Volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisplayAssignedVolunteerData_Click(object sender, EventArgs e)
        {
            if (listBoxAssignedVolunteers.SelectedItem != null)
            {
                EntityWindow window = new EntityWindow();
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Volunteer, ((Volunteer)listBoxAssignedVolunteers.SelectedItem).IDNumber);
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method opens the entity window for the selected volunteer
        /// in the Available Volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisplayAvailableVolunteerData_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableVolunteers.SelectedItem != null)
            {
                EntityWindow window = new EntityWindow();
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Volunteer, ((Volunteer)listBoxAvailableVolunteers.SelectedItem).IDNumber);
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method opens the entity window for the selected volunteer
        /// in the not Available Volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisplayNotAvailableVolunteerData_Click(object sender, EventArgs e)
        {
            if (listBoxNotAvailableVolunteers.SelectedItem != null)
            {
                EntityWindow window = new EntityWindow();
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Volunteer, ((Volunteer)listBoxNotAvailableVolunteers.SelectedItem).IDNumber);
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method filters the volunteers in the Available Volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindAvailableVolunteer_Click(object sender, EventArgs e)
        {
            VolunteerFacade volunteerFacade = new VolunteerFacade(MainWindow.ConnectedUser);
            Volunteer[] availableVolunteers = new Volunteer[1];
            try
            {
                availableVolunteers = volunteerFacade.GetVolunteerList("", textBoxFindAvailableVolunteer.Text, entity.Type, new VolunteerAvailabilityTime(entity.StartDate.DayOfWeek, entity.StartDate.Hour, entity.EndDate.Hour), new DateTime(1, 1, 1), new DateTime(1, 1, 1), true);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל רשימת מתנדבים: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetVolunteerList");
                MessageBox.Show("נכשל ניסיון לטעון את רשימת המתנדבים הזמינים: " + ex.Message, "טעינת מתנדבים זמינים", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (availableVolunteers != null)
            {
                listBoxAvailableVolunteers.Items.Clear();
                foreach (Volunteer volunteer in availableVolunteers)
                {
                    listBoxAvailableVolunteers.Items.Add(volunteer);
                }
            }
        }

        /// <summary>
        /// this method filters the volunteers in the not Available Volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindNotAvailableVolunteer_Click(object sender, EventArgs e)
        {
            VolunteerFacade volunteerFacade = new VolunteerFacade(MainWindow.ConnectedUser);
            Volunteer[] unAvailableVolunteers = new Volunteer[1];
            try
            {
                unAvailableVolunteers = volunteerFacade.GetVolunteerList("", "", entity.Type, new VolunteerAvailabilityTime(entity.StartDate.DayOfWeek, entity.StartDate.Hour, entity.EndDate.Hour), new DateTime(1, 1, 1), new DateTime(1, 1, 1), false);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל רשימת מתנדבים: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetVolunteerList");
                MessageBox.Show("נכשל ניסיון לטעון את רשימת המתנדבים הלא זמינים: " + ex.Message, "טעינת מתנדבים לא זמינים", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (unAvailableVolunteers != null)
            {
                listBoxNotAvailableVolunteers.Items.Clear();
                foreach (Volunteer volunteer in unAvailableVolunteers)
                {
                    if (volunteer.Firstname.Contains(textBoxFindNotAvailableVolunteer.Text)
                        || volunteer.Surname.Contains(textBoxFindNotAvailableVolunteer.Text))
                        listBoxNotAvailableVolunteers.Items.Add(volunteer);
                }
            }
        }
    }
}
