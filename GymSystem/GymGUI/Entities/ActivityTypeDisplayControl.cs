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
    /// this class implements a display control for an entity of type ActivityType
    /// </summary>
    public partial class ActivityTypeDisplayControl : UserControl, IGeneralEntityDisplayControl
    {
        /// <summary>
        /// this is the class constructor
        /// </summary>
        public ActivityTypeDisplayControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// this method deletes the entity from the system
        /// </summary>
        /// <returns>true if success else false</returns>
        public bool DeleteEntity()
        {
            // an entity can be erased only if already exist in the system
            if (entity.ID > 0)
            {
                // delete the activity type
                ActivityTypeFacade facade = new ActivityTypeFacade(MainWindow.ConnectedUser);
                try
                {
                    facade.DeleteActivityType(entity.ID);
                    LoadEntity(0);
                }               
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון למחוק את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "DeleteActivityType");
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
            ActivityType currentActivityType = new ActivityType(textBoxDescription.Text, textBoxTypeName.Text, textBoxLocation.Text);

            entity = currentActivityType;

            // add the new entity to the system
            ActivityTypeFacade facade = new ActivityTypeFacade(MainWindow.ConnectedUser);
            try
            {
                facade.AddNewActivityType(currentActivityType);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון ליצור את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "AddNewActivityType");
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
            if (textBoxDescription.Text == ""
                || textBoxLocation.Text == ""
                || textBoxTypeName.Text == "")
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
                MessageBox.Show("חלק מפרטי החובה בטופס אינם מלאים. אנא מלא אותם על מנת לעדכן את הטופס", "עדכון סוג פעילות", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }

            // if the entity is new then execute add entity else update the current entity
            if (!IsNewEntity)
            {
                // create the updated object
                ActivityType currentActivityType = new ActivityType(entity.ID, textBoxDescription.Text,textBoxTypeName.Text,textBoxLocation.Text);

                entity = currentActivityType;

                // update the entity
                ActivityTypeFacade facade = new ActivityTypeFacade(MainWindow.ConnectedUser);
                try
                {
                    facade.UpdateActivityTypeData(currentActivityType);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לעדכן את הישות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "UpdateActivityTypeData");
                    MessageBox.Show("נכשל ניסיון לעדכן את הישות: " + e.Message, "עדכון ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            // if new entity add it to the system
            else
            {
                if (AddEntity())
                {
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
            int entityIDInt = 0;
            if (entityID != null)
            {
                try
                {
                    entityIDInt = Convert.ToInt32(entityID);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("מזהה לא תקין עבור סוג פעילות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivityTypeID");
                    return false;
                }
            }
            // open empty entity for edit
            if (entityIDInt == 0)
            {
                IsNewEntity = true;
                SetUpdateState(true);
                entity = null;
                textBoxLocation.Text = "";
                textBoxTypeName.Text = "";
                textBoxDescription.Text = "";
            }
            else
                // load entity data
            {
                IsNewEntity = false;
                SetUpdateState(false);
                ActivityTypeFacade facade = new ActivityTypeFacade(MainWindow.ConnectedUser);
                try
                {
                    entity = facade.GetSingleActivityType(entityIDInt);
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לקבל נתוני סוג פעילות: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetSingleActivityType");
                    return false;
                }
                textBoxLocation.Text = entity.Location;
                textBoxTypeName.Text = entity.ActivityTypeName;
                textBoxDescription.Text = entity.Description;
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
                textBoxLocation.Enabled = true;
                textBoxTypeName.Enabled = true;
                updating = true;
            }
            else
            {
                textBoxDescription.Enabled = false;
                textBoxLocation.Enabled = false;
                textBoxTypeName.Enabled = false;
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
                return "סוג פעילות חדש";
            else return entity.ToString();
        }

        // this boolean indicates if the entity is in update mode
        private bool updating = false;

        // this boolean indicates if the entity is a new one
        private bool IsNewEntity = false;

        // this is the instance of the entity - the actual entity object
        private ActivityType entity;
    }
}
