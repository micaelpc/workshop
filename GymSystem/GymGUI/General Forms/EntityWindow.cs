using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VolunteerManagementGUI.Entities;
using GymBL.Log;

namespace VolunteerManagementGUI
{
    /// <summary>
    /// this class is the form that hosts all of the entity display controls.
    /// it provides the basic logic needed for every entity such as
    /// create new, update and delete. this class loads the entity display
    /// control and uses it`s common functions
    /// </summary>
    public partial class EntityWindow : Form
    {
        /// <summary>
        /// this is the class constructor with no refresh delegate
        /// </summary>
        public EntityWindow()
        {
            InitializeComponent();
            m_MainScreenRefreshFunctions = null;
        }

        /// <summary>
        /// this constructor gets a refresh delegate so if any changes
        /// are made to the system data while the form is open,
        /// then the data could be refreshed in the main form
        /// </summary>
        /// <param name="delegateFunctions">a delegate to a main window method that refreshs the main window display data</param>
        public EntityWindow(MainScreenRefreshFunctions delegateFunctions)
        {
            InitializeComponent();
            m_MainScreenRefreshFunctions = delegateFunctions;
        }

        /// <summary>
        /// a delegate used by the main window to refresh the main window display data
        /// </summary>
        public delegate void MainScreenRefreshFunctions();
        private MainScreenRefreshFunctions m_MainScreenRefreshFunctions;

        /// <summary>
        /// this method loads the correct display control for the current entity 
        /// and shows the entity data in the form
        /// </summary>
        /// <param name="controlType">the type of the current entity</param>
        /// <param name="entityID">the id of the current entity</param>
        public void LoadEntityType(EntityDisplayControlFactory.DisplayControlTypeEnum controlType, object entityID)
        {
            //get the display control
            try
            {
                displayControl = EntityDisplayControlFactory.CreateDisplayControl(controlType);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לטעון את נתוני הישות: " + e.Message,Logger.LogLevelEnum.Errors,MainWindow.GetUserName(),"LoadEntityDisplayControl");
                MessageBox.Show("נכשל ניסיון לטעון את נתוני הישות: " + e.Message, "פתיחת ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            //load the entity data
            if (displayControl.LoadEntity(entityID))
            {
                this.Text = displayControl.GetEntityName();
                UserControl uc = (UserControl)displayControl;
                uc.Dock = DockStyle.Top;
                panelEntityDisplayControl.Controls.Add(uc);
                //if (entityID.ToString() == "" || Convert.ToInt32(entityID) == 0)
                if (displayControl.IsUpdateable())
                {
                    //displayControl.SetUpdateState(true);
                    buttonSaveUpdate.Text = "שמור מידע";
                }
            }
            else
            {
                MessageBox.Show("נכשל ניסיון לטעון את נתוני הישות", "פתיחת ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// this is the entity display control showed in the form
        /// </summary>
        private IGeneralEntityDisplayControl displayControl;

        /// <summary>
        /// this button enables the update of the entity data 
        /// if the form is in view mode or
        /// saves the new data if the entity`s data already been 
        /// changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveUpdate_Click(object sender, EventArgs e)
        {
            // if the control is in view only mode make it updateable
            if (!displayControl.IsUpdateable())
            {
                displayControl.SetUpdateState(true);
                buttonSaveUpdate.Text = "שמור מידע";
            }
            // if the form is in update mode then save the data for the entity
            // and update the data in the main window display
            else
            {
                if (displayControl.UpdateEntity())
                {
                    this.Text = displayControl.GetEntityName();
                    displayControl.SetUpdateState(false);
                    buttonSaveUpdate.Text = "עדכן מידע";
                    System.Threading.Thread.Sleep(1000);
                    if (m_MainScreenRefreshFunctions != null)
                        m_MainScreenRefreshFunctions();
                }
            }
        }

        /// <summary>
        /// this method creates a new display control in update mode
        /// in order to create a new entity. if the entity is already in 
        /// update mode it gives the user a chance to cancel the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            // if in update mode give the user a chance to save changes
            if (displayControl.IsUpdateable())
            {
                DialogResult result = MessageBox.Show("יצירת כרטסת חדשה תסגור את הכרטסת הנוכחית ללא שמירת שינויים. אם ברצונך להמשיך הקש אישור", "יצירת כרטסת חדשה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (result == DialogResult.Cancel)
                    return;
            }

            //load a new entity in update mode
            if (!displayControl.IsUpdateable())
                buttonSaveUpdate_Click(null, null);
            if (displayControl.LoadEntity(null))
            {
                this.Text = displayControl.GetEntityName();
            }
            else
            {
                MessageBox.Show("נכשל ניסיון לפתוח כרטסת ישות חדשה", "יצירת ישות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// this method deletes the entity from the system db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //verify the operation with user
            DialogResult result = MessageBox.Show("האם אתה בטוח שברצונך למחוק את הכרטסת? להמשך לחץ על אישור", "מחיקת כרטסת", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (result == DialogResult.Yes)
            {
                //delete the entity from the db and update the data in the main window display
                if (displayControl.DeleteEntity())
                {
                    this.Text = displayControl.GetEntityName();
                    System.Threading.Thread.Sleep(1000);
                    if (m_MainScreenRefreshFunctions != null)
                        m_MainScreenRefreshFunctions();
                }
            }
        }

        /// <summary>
        /// this method closes the display window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCloseEntity_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// this method makes sure that no unsaved data is lost before the 
        /// closing of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntityWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (displayControl.IsUpdateable())
            {
                // if data has changed then give the user a chance to save the data
                DialogResult result = MessageBox.Show("ביצעת שינויים ללא שמירה, אם ברצונך לשמור אותם לפני סגירת הכרטסת הקש אישור", "סגירת כרטסת", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (result == DialogResult.Yes)
                {
                    buttonSaveUpdate_Click(null,null);
                    //displayControl.UpdateEntity();
                    //this.Text = displayControl.GetEntityName();
                    //displayControl.SetUpdateState(false);
                    //buttonSaveUpdate.Text = "עדכן מידע";
                    //System.Threading.Thread.Sleep(1000);
                    //m_MainScreenRefreshFunctions();
                }
            }
        }

        private void EntityWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
