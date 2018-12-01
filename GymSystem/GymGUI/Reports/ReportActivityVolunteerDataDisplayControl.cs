using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GymBL.Reports;
using GymBL;
using GymBL.Entities;
using GymBL.Log;

namespace VolunteerManagementGUI.Reports
{
    /// <summary>
    /// this class implements a display control in order to display
    /// the data recieved from the specified report with same name.
    /// it contains methods to init and execute the report
    /// </summary>
    public partial class ReportActivityVolunteerDataDisplayControl : UserControl, IGeneralReportDisplayControl
    {
        /// <summary>
        /// the constructor for this class
        /// </summary>
        public ReportActivityVolunteerDataDisplayControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// init the report control and data
        /// </summary>
        public void StartNewReport()
        {
        }

        /// <summary>
        /// this method executes the report data using the report object
        /// in the bl and then displays the result of the report in the control
        /// </summary>
        public void LoadReport()
        {
            // create the report object
            ReportActivityVolunteerData report = new ReportActivityVolunteerData(MainWindow.ConnectedUser);
            if (comboBoxActivities.SelectedItem != null)
            {
                // set the report params 
                report.ActivityID = ((Activity)comboBoxActivities.SelectedItem).ID;
                // execute the report
                try
                {
                    report.LoadReportData();
                }
                catch (Exception e)
                {
                    LogManager.Instance.WriteEntry("נכשל ניסיון לטעון דוח: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "LoadReportData");
                    MessageBox.Show("נכשל ניסיון לטעון דוח: " + e.Message, "הרצת דוח", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //set the report data in the display
                bindingSourceVolunteersList.DataSource = report.VolunteerList;
            }
            else
            {
                bindingSourceVolunteersList.DataSource = null;
            }
        }
        public void SaveReportData(string filePath)
        {
        }

        /// <summary>
        /// get the list of available activities for the current date
        /// so that the user can choose for which activity he wants to
        /// run the report 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePickerActivityDate_ValueChanged(object sender, EventArgs e)
        {
            ActivityFacade facade = new ActivityFacade(MainWindow.ConnectedUser);
            Activity[] array = new Activity[1];
            // get the activities for the specified date
            try
            {
                array = facade.GetActivityListByDate(dateTimePickerActivityDate.Value);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל את רשימת הפעילויות: " + ex.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetActivityListByDate");
                MessageBox.Show("נכשל ניסיון לקבל את רשימת הפעילויות: " + ex.Message, "קבלת רשימת פעילויות", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // fill in the activities in the user control
            comboBoxActivities.Items.Clear();
            foreach (Activity activity in array)
            {
                comboBoxActivities.Items.Add(activity);
            }
            if (comboBoxActivities.Items.Count > 0)
                comboBoxActivities.SelectedIndex = 0;
        }
    }
}
