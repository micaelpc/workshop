using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GymClient.TraineeUCs
{
    /// <summary>
    /// Interaction logic for PrivateTraining.xaml
    /// </summary>
    public partial class PrivateTrainingUC : UserControl, INotifyPropertyChanged
    {
        public static readonly RoutedEvent NavToTraineeRetriveEvent =
            EventManager.RegisterRoutedEvent("NavToTraineeRetriveEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(PrivateTrainingUC));

        public static readonly RoutedEvent NavToFullViewTrainerEvent =
            EventManager.RegisterRoutedEvent("NavToFullViewTrainerEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(PrivateTrainingUC));


        public ObservableCollection<int> Numbers = new ObservableCollection<int> { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };

        public PrivateTrainingUC(Trainee trainee)
        {
            SelectedDate = DateTime.Today;

            Trainee = trainee;
            InitializeComponent();
            ReloadAvailableTrainers();
        }

        private ObservableCollection<Trainer> _availableTrainers;
        public ObservableCollection<Trainer> AvailableTrainers
        {
            get { return _availableTrainers; }
            set
            {
                _availableTrainers = value;
                OnPropertyChanged("AvailableTrainers");


            }
        }


        private int _hour;
        public int Hour
        {
            get { return _hour; }
            set
            {
                _hour = value;

                SelectedDate =   SelectedDate.Date;

                OnPropertyChanged("Hour");
                OnPropertyChanged("SelectedDate");
                ReloadAvailableTrainers();
            }
        }


        private void ReloadAvailableTrainers()
        {
            //TODO - TAL - load avilable by the selected Date (in containas the time also)
            /// AvailableTrainers  =  //here
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;

                OnPropertyChanged("SelectedDate");
                ReloadAvailableTrainers();
            }
        }


        private Trainee _trainee;
        public Trainee Trainee
        {
            get { return _trainee; }
            set
            {
                _trainee = value;
                OnPropertyChanged("Trainee");

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

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void SetPrivateTrainingBtn_Click(object sender, RoutedEventArgs e)
        {
            ///TODO - TAL Set Private Training!
        }

        private void BackToTrainerViewBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NavToFullViewTrainerEvent, Trainee));
        }

        private void RetriveTraineesBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NavToTraineeRetriveEvent, Trainee));
        }
    }
}
