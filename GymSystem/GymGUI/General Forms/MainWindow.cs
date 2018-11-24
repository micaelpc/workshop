using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using VolunteerManagementGUI.Reports;
using VolunteerManagementBL;
using VolunteerManagementBL.Entities;
using VolunteerManagementBL.Reports;
using VolunteerManagementBL.Log;

namespace VolunteerManagementGUI
{
    /// <summary>
    /// this class is the main form of the system 
    /// it contains the main work views of the system that include
    /// the user view, volunteer view, activities&reminders view and report sheet
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// the user object of the current connected user.
        /// this is used in order to get the user identity (to get it`s reminders for example)
        /// and for the security & permissions reasons. every call to the system`s BL 
        /// requires a user object to check the permissions
        /// </summary>
        static public User ConnectedUser;
        /// <summary>
        /// this delegate is passed to the login screen and is used to set the 
        /// connected user object after a successful login
        /// </summary>
        private LoginScreen.SetConnectedUser m_SetConnectedUser;
        /// <summary>
        /// this delegate is passed to the login screen and is used to
        /// close the system in case the login is not successful
        /// </summary>
        private LoginScreen.CloseSystem m_CloseSystem;

        /// <summary>
        /// the constructor for this class
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            // init the diffrent delegates
            m_RefreshFunctions = new EntityWindow.MainScreenRefreshFunctions(RefreshScreenData);
            m_SetConnectedUser = new LoginScreen.SetConnectedUser(SetConnectedUser);
            m_CloseSystem = new LoginScreen.CloseSystem(CloseSystem);

            // open the login screen before the load of the main window
            LoginScreen window = new LoginScreen(m_SetConnectedUser,m_CloseSystem);
            window.ShowDialog();
        }

        /// <summary>
        /// this method returns the connected user name
        /// </summary>
        /// <returns>the connected user name</returns>
        static public string GetUserName()
        {
            if (ConnectedUser == null)
                return "";
            else return ConnectedUser.UserName;
        }

        /// <summary>
        /// this method loads the volunteers list into the volunteers grid
        /// using the filters of activity type, name and volunteer id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindVolunteer_Click(object sender, EventArgs e)
        {
            VolunteerFacade facade = new VolunteerFacade(MainWindow.ConnectedUser);
            try
            {
                bindingSourceVolunteersList.DataSource = facade.GetVolunteerList(textBoxVolunteerID.Text, textBoxVolunteerName.Text, (ActivityType)comboBoxVolunteerActivityType.SelectedItem, null, new DateTime(1, 1, 1), new DateTime(1, 1, 1), true);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת המתנדבים: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetVolunteerList");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת המתנדבים: " + ex.Message, "קבלת רשימת מתנדבים", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// this method opens an entity window of type volunteer
        /// for the selected volunteer in the volunteer grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadVolunteer_Click(object sender, EventArgs e)
        {
            if (dataGridViewVolunteers != null
                && dataGridViewVolunteers.SelectedCells.Count > 0)
            {
                EntityWindow window = new EntityWindow(m_RefreshFunctions);
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Volunteer, dataGridViewVolunteers.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method opens an empty entity window of type volunteer
        /// in update mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddNewVolunteer_Click(object sender, EventArgs e)
        {
            EntityWindow window = new EntityWindow(m_RefreshFunctions);
            window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Volunteer, "");
            window.ShowDialog();
        }

        /// <summary>
        /// this method loads the list of activities and reminders for
        /// the specific date chosen by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendarActivities_DateChanged(object sender, DateRangeEventArgs e)
        {
            ActivityFacade facade = new ActivityFacade(MainWindow.ConnectedUser);
            Activity[] array = new Activity[1];
            try
            {
                array = facade.GetActivityListByDate(monthCalendarActivities.SelectionStart);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת הפעילויות: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivityListByDate");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת הפעילויות: " + ex.Message, "קבלת רשימת פעילויות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listBoxActivities.Items.Clear();
            foreach (Activity activity in array)
            {
                listBoxActivities.Items.Add(activity);
            }

            ReminderFacade reminderfacade = new ReminderFacade(MainWindow.ConnectedUser);
            Reminder[] reminderarray = new Reminder[1];
            try
            {
                reminderarray = reminderfacade.GetReminderList(ConnectedUser.UserName, monthCalendarActivities.SelectionStart, -1);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת התזכורות: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetReminderList");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת התזכורות: " + ex.Message, "קבלת רשימת תזכורות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listBoxAllReminders.Items.Clear();
            foreach (Reminder current in reminderarray)
            {
                listBoxAllReminders.Items.Add(current);
            }
        }

        /// <summary>
        /// this method opens an entity window of type activity
        /// for the selected activity in the activities list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadActivity_Click(object sender, EventArgs e)
        {
            if (listBoxActivities.SelectedItem != null)
            {
                EntityWindow window = new EntityWindow(m_RefreshFunctions);
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Activity, ((Activity)listBoxActivities.SelectedItem).ID);
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method opens an empty entity window of type activity
        /// in update mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddNewActivity_Click(object sender, EventArgs e)
        {
            EntityWindow window = new EntityWindow(m_RefreshFunctions);
            window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Activity, 0);
            window.ShowDialog();
        }

        /// <summary>
        /// this method loads the list of activities and reminders for
        /// the specific date chosen by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendarActivities_VisibleChanged(object sender, EventArgs e)
        {
            ActivityFacade facade = new ActivityFacade(MainWindow.ConnectedUser);
            DateTime[] dateArray = new DateTime[1];
            try
            {
                dateArray = facade.GetActivitiesDates();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת תאריכי הפעילויות: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivitiesDates");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת תאריכי הפעילויות: " + ex.Message, "קבלת רשימת תאריכי פעילויות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            monthCalendarActivities.BoldedDates = dateArray;

            Activity[] activityArray = new Activity[1];
            try
            {
                activityArray = facade.GetActivityListByDate(monthCalendarActivities.SelectionStart);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת הפעילויות: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivityListByDate");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת הפעילויות: " + ex.Message, "קבלת רשימת פעילויות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listBoxActivities.Items.Clear();
            foreach (Activity activity in activityArray)
            {
                listBoxActivities.Items.Add(activity);
            }

            ReminderFacade reminderfacade = new ReminderFacade(MainWindow.ConnectedUser);
            Reminder[] reminderarray = new Reminder[1];
            try
            {
                reminderarray = reminderfacade.GetReminderList(ConnectedUser.UserName, monthCalendarActivities.SelectionStart, -1);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת התזכורות: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetReminderList");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת התזכורות: " + ex.Message, "קבלת רשימת תזכורות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listBoxAllReminders.Items.Clear();
            foreach (Reminder current in reminderarray)
            {
                listBoxAllReminders.Items.Add(current);
            }
        }

        /// <summary>
        /// this method loads the list of activity type to the activity types
        /// combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxActivityTypes_VisibleChanged(object sender, EventArgs e)
        {
            ActivityTypeFacade facade = new ActivityTypeFacade(MainWindow.ConnectedUser);
            ActivityType[] array = new ActivityType[1];
            try
            {
                array = facade.GetActivityTypesList();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת סוגי הפעילויות: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivityTypesList");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת סוגי הפעילויות: " + ex.Message, "קבלת רשימת סוגי פעילויות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            comboBoxActivityTypes.Items.Clear();
            foreach (ActivityType activityType in array)
            {
                comboBoxActivityTypes.Items.Add(activityType);
            }
        }

        /// <summary>
        /// this method opens an entity window of type activitytype
        /// for the selected activityType in the activity types list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadActivityType_Click(object sender, EventArgs e)
        {
            if (comboBoxActivityTypes.SelectedItem != null)
            {
                EntityWindow window = new EntityWindow(m_RefreshFunctions);
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.ActivityType, ((ActivityType)comboBoxActivityTypes.SelectedItem).ID);
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method opens an empty entity window of type activitytype
        /// in update mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddNewActivityType_Click(object sender, EventArgs e)
        {
            EntityWindow window = new EntityWindow(m_RefreshFunctions);
            window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.ActivityType, 0);
            window.ShowDialog();
        }

        /// <summary>
        /// this method loads the activity types list to the combo box.
        /// this list is used to filter the volunteers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxVolunteerActivityType_VisibleChanged(object sender, EventArgs e)
        {
            ActivityTypeFacade facade = new ActivityTypeFacade(MainWindow.ConnectedUser);
            ActivityType[] array = new ActivityType[1];
            try
            {
                array = facade.GetActivityTypesList();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת סוגי הפעילויות: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivityTypesList");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת סוגי הפעילויות: " + ex.Message, "קבלת רשימת סוגי פעילויות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            comboBoxVolunteerActivityType.Items.Clear();
            foreach (ActivityType activityType in array)
            {
                comboBoxVolunteerActivityType.Items.Add(activityType);
            }
        }

        /// <summary>
        /// this method refreshs the main screen data. it is used
        /// by other windows that make changes to the data of the system
        /// and makes sure that the data is up to date
        /// </summary>
        private void RefreshScreenData()
        {
            System.Threading.Thread.Sleep(3000);
            monthCalendarActivities_VisibleChanged(null,null);
            comboBoxVolunteerActivityType_VisibleChanged(null, null);
            comboBoxActivityTypes_VisibleChanged(null, null);
            monthCalendarActivities_DateChanged(null,null);
            VolunteerFacade facade = new VolunteerFacade(MainWindow.ConnectedUser);
            try
            {
                bindingSourceVolunteersList.DataSource = facade.GetVolunteerList(textBoxVolunteerID.Text, textBoxVolunteerName.Text, (ActivityType)comboBoxVolunteerActivityType.SelectedItem, null, new DateTime(1, 1, 1), new DateTime(1, 1, 1), true);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת המתנדבים: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetVolunteerList");
            }
        }

        /// <summary>
        /// this method sets the connected user object 
        /// and loads the user details from the db
        /// </summary>
        /// <param name="connectedUserName"></param>
        private void SetConnectedUser(string connectedUserName)
        {
            UserFacade facade = new UserFacade(MainWindow.ConnectedUser);
            ConnectedUser = facade.GetSingleUserData(connectedUserName);
        }

        /// <summary>
        /// this method loggs off and closes the system
        /// </summary>
        private void CloseSystem()
        {
            UserFacade facade = new UserFacade(MainWindow.ConnectedUser);
            facade.LogoffUser();
            Application.Exit();
        }

        /// <summary>
        /// this delegate is used by the entity window to refresh
        /// the data in the main window after some data change
        /// outside of the main form
        /// </summary>
        private EntityWindow.MainScreenRefreshFunctions m_RefreshFunctions;

        /// <summary>
        /// this method opens an entity window of type volunteer
        /// for the selected volunteer in the volunteer grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewVolunteers_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewVolunteers != null
                && dataGridViewVolunteers.SelectedCells.Count > 0)
            {
                EntityWindow window = new EntityWindow(m_RefreshFunctions);
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Volunteer, dataGridViewVolunteers.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method opens an entity window of type activity
        /// for the selected activity in the activity list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxActivities_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxActivities.SelectedItem != null)
            {
                EntityWindow window = new EntityWindow(m_RefreshFunctions);
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Activity, ((Activity)listBoxActivities.SelectedItem).ID);
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method loads the list of available reports in the
        /// system so the user can choose the requested report to run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxReportType_VisibleChanged(object sender, EventArgs e)
        {
            Array valueList = System.Enum.GetValues(typeof(Report.ReportTypeEnum));

            comboBoxReportType.Items.Clear();
            foreach (Report.ReportTypeEnum value in valueList)
            {
                comboBoxReportType.Items.Add(value);
            }
        }

        /// <summary>
        /// this method loads the report display control into the report panel
        /// every time the user changes the report type to run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxReportType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                activeReportControl = ReportDisplayControlFactory.CreateDisplayControl((Report.ReportTypeEnum)Enum.Parse(typeof(Report.ReportTypeEnum), comboBoxReportType.Text));
                activeReportControl.StartNewReport();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לטעון את רכיב הדוח: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "LoadReportDisplayControl");
                MessageBox.Show("נכשל ניסיון לטעון את רכיב הדוח: " + ex.Message, "טעינת רכיב דוח", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserControl uc = (UserControl)activeReportControl;
            uc.Dock = DockStyle.Top;
            panelReportView.Controls.Clear();
            panelReportView.Controls.Add(uc);
        }

        /// <summary>
        /// this is the active report display control used to execute the report
        /// </summary>
        IGeneralReportDisplayControl activeReportControl;

        /// <summary>
        /// this method fills the users grid with the system users data,
        /// it filters the users by the user name and user type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindUser_Click(object sender, EventArgs e)
        {
            UserFacade facade = new UserFacade(MainWindow.ConnectedUser);
            try
            {
                bindingSourceUsersList.DataSource = facade.GetUserList(textBoxUserName.Text, comboBoxUserType.Text);
            }
            catch(Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת המשתמשים: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetUserList");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת המשתמשים: " + ex.Message, "קבלת רשימת משתמשים", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// gets the list of user types used to filter the user list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxUserType_VisibleChanged(object sender, EventArgs e)
        {
            Array valueList = System.Enum.GetValues(typeof(User.UserTypeEnum));
            comboBoxUserType.Items.Clear();
            foreach (User.UserTypeEnum value in valueList)
            {
                comboBoxUserType.Items.Add(value);
            }
        }

        /// <summary>
        /// this method opens an entity window of type user
        /// for the selected user in the users grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers != null
                && dataGridViewUsers.SelectedCells.Count > 0)
            {
                EntityWindow window = new EntityWindow(m_RefreshFunctions);
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.User, dataGridViewUsers.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method opens an empty entity window of type activitytype
        /// in update mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddNewUser_Click(object sender, EventArgs e)
        {
            EntityWindow window = new EntityWindow(m_RefreshFunctions);
            window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.User, "");
            window.ShowDialog();
        }

        /// <summary>
        /// this method opens an entity window of type user
        /// for the selected user in the users grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewUsers_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewUsers != null
                && dataGridViewUsers.SelectedCells.Count > 0)
            {
                EntityWindow window = new EntityWindow(m_RefreshFunctions);
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.User, dataGridViewUsers.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method opens an empty entity window of type activitytype
        /// in update mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddReminder_Click(object sender, EventArgs e)
        {
            EntityWindow window = new EntityWindow(m_RefreshFunctions);
            window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Reminder, "");
            window.ShowDialog();
        }

        /// <summary>
        /// this method changes the status of the selected reminder to attended
        /// and advances the reminder to the next date if the reminder is cyclic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAttendReminder_Click(object sender, EventArgs e)
        {
            if (listBoxAllReminders.SelectedItem != null)
            {
                Reminder current = (Reminder)listBoxAllReminders.SelectedItem;
                current.IsAttended = true;
                ReminderFacade facade = new ReminderFacade(MainWindow.ConnectedUser);
                try
                {
                    current = facade.AdvanceReminder(current);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לקדם תזכורת: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "AdvanceReminder");
                    MessageBox.Show("נכשל ניסיון לקדם תזכורת: " + ex.Message, "טיפול בתזכורת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (monthCalendarActivities.SelectionStart.Date == current.ReminderTime.Date)
                {
                    listBoxAllReminders.Items[listBoxAllReminders.SelectedIndex] = current;
                    listBoxAllReminders.Refresh();
                }
                else
                    listBoxAllReminders.Items.Remove(current);
            }
        }

        /// <summary>
        /// this method opens an entity window of type reminder
        /// for the selected reminder in the reminder list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxAllReminders_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxAllReminders.SelectedItem != null)
            {
                EntityWindow window = new EntityWindow(m_RefreshFunctions);
                window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Reminder, ((Reminder)listBoxAllReminders.SelectedItem).ID);
                window.ShowDialog();
            }
        }

        /// <summary>
        /// this method executes the chosen report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExecuteReport_Click(object sender, EventArgs e)
        {
            activeReportControl.LoadReport();
        }

        /// <summary>
        /// this method gets the list of cyclic timing values for 
        /// a report reminder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxReportReminderCycleTime_VisibleChanged(object sender, EventArgs e)
        {
            Array valueList = System.Enum.GetValues(typeof(Activity.TimingEnum));
            comboBoxReportReminderCycleTime.Items.Clear();
            foreach (Activity.TimingEnum value in valueList)
            {
                comboBoxReportReminderCycleTime.Items.Add(value);
            }
        }

        /// <summary>
        /// this method adds a new reminder to the system, the reminder content
        /// is to run a specific report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddReportReminder_Click(object sender, EventArgs e)
        {
            ReminderFacade facade = new ReminderFacade(MainWindow.ConnectedUser);
            Reminder reportReminder = new Reminder("","הרצת דוח " + comboBoxReportType.SelectedItem.ToString(),
                dateTimePickerReportReminderFinishDate.Value,false,(Activity.TimingEnum)comboBoxReportReminderCycleTime.SelectedItem,ConnectedUser.UserName);
            try
            {
                facade.AddNewReminder(reportReminder);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון להוסיף תזכורת: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "AddNewReminder");
                MessageBox.Show("נכשל ניסיון להוסיף תזכורת: " + ex.Message, "הוספת תזכורת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// this method makes sure that the user logged off and that the system
        /// is properly closed if the form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseSystem();
        }
    }
}
