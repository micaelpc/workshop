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
using VolunteerManagementBL.Log;

namespace VolunteerManagementGUI.Reports
{
    /// <summary>
    /// this class implements a display control in order to display
    /// the data recieved from the specified report with same name.
    /// it contains methods to init and execute the report
    /// </summary>
    public partial class ReportActivityLogDisplayControl : UserControl, IGeneralReportDisplayControl
    {
        /// <summary>
        /// the constructor for this class
        /// </summary>
        public ReportActivityLogDisplayControl()
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
            ReportActivityLog report = new ReportActivityLog(MainWindow.ConnectedUser);
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

            // set the result data in the display
            bindingSourceActivities.DataSource = report.ActivityList;
            labelNumOfActivities.Text = bindingSourceActivities.Count.ToString();
            // get the number of volunteers for each activity
            try
            {
                foreach (DataGridViewRow row in dataGridViewActivities.Rows)
                {
                    ActivityFacade facade = new ActivityFacade(MainWindow.ConnectedUser);
                    row.Cells["NumOfVolunteers"].Value = facade.GetSingleActivityData(Convert.ToInt32(row.Cells["ID"].Value)).Volunteers.Length;
                }
            }
            catch (Exception e)
            {
                LogManager.Instance.WriteEntry("נכשל ניסיון לטעון דוח: " + e.Message, Logger.LogLevelEnum.Errors, MainWindow.GetUserName(), "GetSingleActivityData");
                MessageBox.Show("נכשל ניסיון לטעון דוח: " + e.Message, "הרצת דוח", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveReportData(string filePath)
        {
        }

        /// <summary>
        /// opens an activity entity window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewActivities_DoubleClick(object sender, EventArgs e)
        {
            EntityWindow window = new EntityWindow();
            window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Activity, dataGridViewActivities.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            window.ShowDialog();
        }
    }
}
