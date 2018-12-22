using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using GymClient.PrivateTrainingUCs;
using GymClient.ReportsUCs;
using GymClient.TraineeUCs;

namespace GymClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region UC Navigators
        public UserControl CurrentPrivateTrainingUC
        {
            get { return (UserControl)GetValue(CurrentPrivateTrainingUCProperty); }
            set { SetValue(CurrentPrivateTrainingUCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPrivateTrainingUC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPrivateTrainingUCProperty =
            DependencyProperty.Register("CurrentPrivateTrainingUC", typeof(UserControl), typeof(MainWindow), new PropertyMetadata(null));


        public UserControl CurrentTrainerUC
        {
            get { return (UserControl)GetValue(CurrentTrainerUCProperty); }
            set { SetValue(CurrentTrainerUCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentTrainerUC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentTrainerUCProperty =
            DependencyProperty.Register("CurrentTrainerUC", typeof(UserControl), typeof(MainWindow), new PropertyMetadata(null));


        public UserControl CurrentReportUC
        {
            get { return (UserControl)GetValue(CurrentReportUCProperty); }
            set { SetValue(CurrentReportUCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentReportUC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentReportUCProperty =
            DependencyProperty.Register("CurrentReportUC", typeof(UserControl), typeof(MainWindow), new PropertyMetadata(null));

        public UserControl CurrentTraineeUC
        {
            get { return (UserControl)GetValue(CurrentTraineeUCProperty); }
            set { SetValue(CurrentTraineeUCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentTraineeUC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentTraineeUCProperty =
            DependencyProperty.Register("CurrentTraineeUC", typeof(UserControl), typeof(MainWindow), new PropertyMetadata(null));
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            InitEvents();
            InitUCs();
        }

        private void InitUCs()
        {
            CurrentTraineeUC = new TraineeUC();
            CurrentReportUC = new ReportsMenuUC();
            CurrentTrainerUC = new TrainerUC();
            CurrentPrivateTrainingUC = new PrivateTrainingUC();
        }

        private void InitEvents()
        {
            AddHandler(TraineeUC.NewTrainertEvent,
                     new RoutedEventHandler(NewTrainertEvent_handler));

            AddHandler(NewTraineeUC.NavToTraineeRetriveEvent,
                 new RoutedEventHandler(NavToTraineeRetriveEvent_handler));

            AddHandler(TraineeUC.ViewTraineeEvent,
                new RoutedEventHandler(ViewTraineeEvent_handler));

            AddHandler(TraineeFullView.NavToTraineeRetriveEvent,
                new RoutedEventHandler(NavToTraineeRetriveEvent_handler));
        }


        #region Event Handlers
        private void ViewTraineeEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTraineeUC = new TraineeFullView((Trainee)e.OriginalSource);
        }

        private void NavToTraineeRetriveEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTraineeUC = new TraineeUC();
        }

        private void NewTrainertEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTraineeUC = new NewTraineeUC();
        }
        #endregion

    }
}
