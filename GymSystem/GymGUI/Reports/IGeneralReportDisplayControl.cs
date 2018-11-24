using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolunteerManagementGUI.Reports
{
    /// <summary>
    /// this is the inteface used the define the common methods
    /// for a report display control
    /// </summary>
    public interface IGeneralReportDisplayControl
    {
        /// <summary>
        /// init the report data
        /// </summary>
        void StartNewReport();

        /// <summary>
        /// execute the report and display it`s data
        /// </summary>
        void LoadReport();

        /// <summary>
        /// save the report data to a file
        /// </summary>
        /// <param name="filePath">the file path</param>
        void SaveReportData(string filePath);
    }
}
