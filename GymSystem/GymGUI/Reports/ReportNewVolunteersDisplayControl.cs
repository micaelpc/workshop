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
    public partial class ReportNewVolunteersDisplayControl : UserControl, IGeneralReportDisplayControl
    {
        /// <summary>
        /// the constructor for this class
        /// </summary>
        public ReportNewVolunteersDisplayControl()
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
            ReportNewVolunteers report = new ReportNewVolunteers(MainWindow.ConnectedUser);
            // set the report params
            report.FinishDate = dateTimePickerFinishDate.Value.AddDays(1);
            report.StartDate = dateTimePickerStartDate.Value;
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
            //show the result data in the display
            bindingSourceVolunteersList.DataSource = report.VolunteerList;
            labelNumOfVolunteers.Text = bindingSourceVolunteersList.Count.ToString();
        }
        public void SaveReportData(string filePath)
        {
        }

        /// <summary>
        /// opens a volunteer entity window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewVolunteers_DoubleClick(object sender, EventArgs e)
        {
            EntityWindow window = new EntityWindow();
            window.LoadEntityType(VolunteerManagementGUI.Entities.EntityDisplayControlFactory.DisplayControlTypeEnum.Volunteer, dataGridViewVolunteers.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
            window.ShowDialog();
        }


    }
}
