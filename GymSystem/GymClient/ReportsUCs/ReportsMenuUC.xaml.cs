using System;
using System.Collections.Generic;
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

namespace GymClient.ReportsUCs
{
    /// <summary>
    /// Interaction logic for ReportsMenu.xaml
    /// </summary>
    public partial class ReportsMenuUC : UserControl
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
        
        public object GetReportResults() {

            ///TODO -TAL get reports by datefrom and dateTo

            return null;
        }

        public ReportsMenuUC()
        {
            InitializeComponent();
        }

        private void ExcuteReportRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            GetReportResults();
        }
    }
}
