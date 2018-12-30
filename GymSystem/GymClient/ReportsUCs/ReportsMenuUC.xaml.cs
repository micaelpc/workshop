using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GymBL.Entities;
using GymBL.Report;
using GymClient.Resources.Utils;

namespace GymClient.ReportsUCs
{
    /// <summary>
    /// Interaction logic for ReportsMenu.xaml
    /// </summary>
    public partial class ReportsMenuUC : UserControl, INotifyPropertyChanged
    {
        public DateTime FromDate
        {
            get { return (DateTime)GetValue(FromDateProperty); }
            set { SetValue(FromDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FromDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FromDateProperty =
            DependencyProperty.Register("FromDate", typeof(DateTime), typeof(ReportsMenuUC), new PropertyMetadata(DateTime.Today.AddMonths(-1)));

        
        public DateTime ToDate
        {
            get { return (DateTime)GetValue(ToDateProperty); }
            set { SetValue(ToDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToDateProperty =
            DependencyProperty.Register("ToDate", typeof(DateTime), typeof(ReportsMenuUC), new PropertyMetadata(DateTime.Today));

        private List<Trainee> subscriptionNearEndTrainees;
        public List<Trainee> SubscriptionNearEndTrainees { get {
                return subscriptionNearEndTrainees;


            } set {
                subscriptionNearEndTrainees = value;
                NotifyPropertyChanged("SubscriptionNearEndTrainees");
            } }

        private List<Trainee> newSubscribersReportTrainees;
        public List<Trainee> NewSubscribersReportTrainees
        {
            get
            {
                return newSubscribersReportTrainees;


            }
            set
            {
                newSubscribersReportTrainees = value;
                NotifyPropertyChanged("NewSubscribersReportTrainees");
            }
        }


        #region INotifyPropertyChanged Items
        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion


        public void GetReportResults() {

            SubscriptionNearEndTrainees = new SubscriptionNearEnd(FromDate, ToDate).Trainees;
            var report2 = new NewSubscribersReport(FromDate, ToDate).Trainees;

        }

        public ReportsMenuUC()
        {
            InitializeComponent();
        }

        private void ExcuteReportRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            GetReportResults();
        }

        private void ExcelExpairedBtn_Click(object sender, RoutedEventArgs e)
        {
            ExcelExportUtils.ExportToExcel(this.TraineesAboutToExpireDG);
        }

        private void ExcelNewBtn_Click(object sender, RoutedEventArgs e)
        {
            ExcelExportUtils.ExportToExcel(this.TraineesNewDG);
        }
    }
}
