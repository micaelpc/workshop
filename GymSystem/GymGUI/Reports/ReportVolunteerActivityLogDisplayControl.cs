using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VolunteerManagementBL.Reports;
using VolunteerManagementBL;
using VolunteerManagementBL.Entities;
using VolunteerManagementBL.Log;

namespace VolunteerManagementGUI.Reports
{
    /// <summary>
    /// this class implements a display control in order to display
    /// the data recieved from the specified report with same name.
    /// it contains methods to init and execute the report
    /// </summary>
    public partial class ReportVolunteerActivityLogDisplayControl : UserControl, IGeneralReportDisplayControl
    {
        /// <summary>
        /// the constructor for this class
        /// </summary>
        public ReportVolunteerActivityLogDisplayControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// init the report control and data, gets the volunteers list
        /// </summary>
        public void StartNewReport()
        {
            VolunteerFacade volunteerFacade = new VolunteerFacade(MainWindow.ConnectedUser);
            Volunteer[] availableVolunteers = new Volunteer[1];
            try
            {
                availableVolunteers = volunteerFacade.GetVolunteerList("", "", null, null, new DateTime(1, 1, 1), new DateTime(1, 1, 1), true);
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לקבל רשימת מתנדבים: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetVolunteerList");
                MessageBox.Show("נכשל אתחול הדוח: " + e.Message, "אתחול דוח", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Volunteer volunteer in availableVolunteers)
            {
                comboBoxVolunteerList.Items.Add(volunteer);
            }
        }

        /// <summary>
        /// this method executes the report data using the report object
        /// in the bl and then displays the result of the report in the control
        /// </summary>
        public void LoadReport()
        {
            // create the report object
            ReportVolunteerActivityLog report = new ReportVolunteerActivityLog(MainWindow.ConnectedUser);
            // set the report param
            report.VolunteerID = ((Volunteer)comboBoxVolunteerList.SelectedItem).IDNumber;
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
            // show the result in the control
            dataGridViewActivityByTime.DataSource = report.ActivityByTimeData;
            dataGridViewActivityByType.DataSource = report.ActivityByTypeData;
        }

        public void SaveReportData(string filePath)
        {
        }
    }
}
