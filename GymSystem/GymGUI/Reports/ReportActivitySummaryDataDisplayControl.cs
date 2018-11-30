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
    public partial class ReportActivitySummaryDataDisplayControl : UserControl, IGeneralReportDisplayControl
    {
        /// <summary>
        /// the constructor for this class
        /// </summary>
        public ReportActivitySummaryDataDisplayControl()
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
            ReportActivitySummaryData report = new ReportActivitySummaryData(MainWindow.ConnectedUser);
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
            //set the report result in the display
            dataGridViewSummaryData.DataSource = report.SummaryData;
        }
        public void SaveReportData(string filePath)
        {
        }
    }
}
