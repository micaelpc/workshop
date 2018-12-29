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
using GymClient.ReportsUCs;
using GymClient.TraineeUCs;
using GymClient.TrainersUCs;
using PrivateTrainingUC = GymClient.TraineeUCs.PrivateTrainingUC;

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

        }

        private void InitEvents()
        {
            #region Trainers Events Regs

            AddHandler(TrainerUC.NewTrainertEvent,
                  new RoutedEventHandler(NewTrainertEvent_handler));

            AddHandler(NewTrainerUC.NavToTrainerRetriveEvent,
                  new RoutedEventHandler(NavToTrainerRetriveEvent_handler));

            AddHandler(TrainerFullView.NavToTrainerRetriveEvent,
                 new RoutedEventHandler(NavToTrainerRetriveEvent_handler));

            AddHandler(TrainerUC.ViewTrainerEvent,
                 new RoutedEventHandler(ViewTrainerEvent_handler));


            // ViewTrainerEvent

            #endregion

            #region Trainee Event reg
            AddHandler(TraineeUC.NewTraineetEvent,
                        new RoutedEventHandler(NewTraineetEvent_handler));

                    AddHandler(NewTraineeUC.NavToTraineeRetriveEvent,
                         new RoutedEventHandler(NavToTraineeRetriveEvent_handler));

                    AddHandler(TraineeUC.ViewTraineeEvent,
                        new RoutedEventHandler(ViewTraineeEvent_handler));

            AddHandler(TraineeFullView.NavToPrivateTraining,
                     new RoutedEventHandler(NavToPrivateTraining_handler));

            AddHandler(TraineeFullView.NavToTraineeRetriveEvent,
                        new RoutedEventHandler(NavToTraineeRetriveEvent_handler));

            AddHandler(PrivateTrainingUC.NavToFullViewTrainerEvent,
            new RoutedEventHandler(ViewTraineeEvent_handler));

            AddHandler(PrivateTrainingUC.NavToTraineeRetriveEvent,
                    new RoutedEventHandler(NavToTraineeRetriveEvent_handler));

            //
            #endregion
        }






        #region Event Handlers

        #region Trainee Handlers
        private void ViewTraineeEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTraineeUC = new TraineeFullView((Trainee)e.OriginalSource);
        }

        private void NavToTraineeRetriveEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTraineeUC = new TraineeUC();
        }

        private void NewTraineetEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTraineeUC = new NewTraineeUC();
        }


        private void NavToPrivateTraining_handler(object sender, RoutedEventArgs e)
        {
            CurrentTraineeUC = new PrivateTrainingUC((Trainee)e.OriginalSource);
        }

        #endregion

        #region Trainers Handlers

        private void ViewTrainerEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTrainerUC = new TrainerFullView((Trainer)e.OriginalSource);
        }

        private void NavToTrainerRetriveEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTrainerUC = new TrainerUC();
        }

        private void NewTrainertEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTrainerUC = new NewTrainerUC();
        }

        #endregion


        #endregion

    }
}
