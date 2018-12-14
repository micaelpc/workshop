using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GymBL.Reports;
using GymBL.Log;

namespace VolunteerManagementGUI.Reports
{
    /// <summary>
    /// this class implements a display control in order to display
    /// the data recieved from the specified report with same name.
    /// it contains methods to init and execute the report
    /// </summary>
    public partial class ReportWorkDistributionDisplayControl : UserControl, IGeneralReportDisplayControl
    {
        /// <summary>
        /// the constructor for this class
        /// </summary>
        public ReportWorkDistributionDisplayControl()
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
            ReportWorkDistribution report = new ReportWorkDistribution(MainWindow.ConnectedUser);
            // set the report params
            report.FinishDate = dateTimePickerFinishDate.Value.AddDays(1);
            report.StartDate = dateTimePickerStartDate.Value;
            //execute the report
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
            //get the result data
            bindingSourceVolunteersList.DataSource = report.VolunteerList;

            int totalVolunteerNumber = report.TotalVolunteerNumber;
            labelNumOfVolunteers.Text = totalVolunteerNumber.ToString();
            int totalActivityNumber = report.TotalActivityNumber;
            labelNumOfActivities.Text = totalActivityNumber.ToString();

            int activitySum = 0;
            int activeVolunteers = 0;
            // add the number of activities data to each volunteer row
            foreach (DataGridViewRow row in dataGridViewVolunteers.Rows)
            {
                int activityNumber = (int)report.VolunteerActivityNum[row.Cells[0].Value.ToString()];
                row.Cells["NumOfActivities"].Value = activityNumber;
                activitySum += activityNumber;
                if (activityNumber > 0)
                {
                    activeVolunteers++;
                }
            }

            labelAverageActivitiesForVolunteer.Text = ((double)activitySum / (double)totalVolunteerNumber).ToString("n1");
            labelActiveVolunteerPercent.Text = ((double)activeVolunteers / (double)totalVolunteerNumber * 100).ToString("n1");

        }
        public void SaveReportData(string filePath)
        {
        }
    }
}
