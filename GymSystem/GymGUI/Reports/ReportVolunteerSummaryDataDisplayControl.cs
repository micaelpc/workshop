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
    public partial class ReportVolunteerSummaryDataDisplayControl : UserControl, IGeneralReportDisplayControl
    {
        /// <summary>
        /// the constructor for this class
        /// </summary>
        public ReportVolunteerSummaryDataDisplayControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// init the report control and data, gets the list of the volunteer attributes
        /// </summary>
        public void StartNewReport()
        {
            Array valueList = System.Enum.GetValues(typeof(ReportVolunteerSummaryData.VolunteerAttributeEnum));

            foreach (ReportVolunteerSummaryData.VolunteerAttributeEnum value in valueList)
            {
                comboBoxVolunteerAttribute.Items.Add(value);
            }
        }

        /// <summary>
        /// this method executes the report data using the report object
        /// in the bl and then displays the result of the report in the control
        /// </summary>
        public void LoadReport()
        {
            if (comboBoxVolunteerAttribute.SelectedItem != null)
            {
                // create the report object
                ReportVolunteerSummaryData report = new ReportVolunteerSummaryData(MainWindow.ConnectedUser);
                // set the report param
                report.VolunteerAttribute = (ReportVolunteerSummaryData.VolunteerAttributeEnum)Enum.Parse(typeof(ReportVolunteerSummaryData.VolunteerAttributeEnum), comboBoxVolunteerAttribute.Text);
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
                // show the report result in the control
                dataGridViewVolunteersSummaryData.DataSource = report.SummaryData;
            }

        }
        public void SaveReportData(string filePath)
        {
        }
    }
}
