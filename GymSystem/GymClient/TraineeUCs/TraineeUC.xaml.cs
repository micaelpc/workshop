using GymBL.Database;
using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GymClient
{
    /// <summary>
    /// Interaction logic for Trainee.xaml
    /// </summary>
    public partial class TraineeUC : UserControl, INotifyPropertyChanged
    {


        public static readonly RoutedEvent NewTrainertEvent =
            EventManager.RegisterRoutedEvent("NewTrainertEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(TraineeUC));

        public static readonly RoutedEvent ViewTraineeEvent =
            EventManager.RegisterRoutedEvent("ViewTrainertEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(TraineeUC));





        public Trainee RetrivalTrainee
        {
            get { return (Trainee)GetValue(RetrivalTraineeProperty); }
            set { SetValue(RetrivalTraineeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RetrivalTrainee.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RetrivalTraineeProperty =
            DependencyProperty.Register("RetrivalTrainee", typeof(Trainee), typeof(MainWindow), new PropertyMetadata(new Trainee()));



        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<Trainee> _trainees = new ObservableCollection<Trainee>();
        private Trainee _selectedTrainee = new Trainee();

        public ObservableCollection<Trainee> Trainees
        {
            get { return _trainees; }
            set
            {
                _trainees = value;
                NotifyPropertyChanged("Trainees");
            }
        }


        public Trainee SelectedTrainee
        {
            get { return _selectedTrainee; }
            set
            {
                _selectedTrainee = value;
                NotifyPropertyChanged("SelectedTrainee");
            }
        }




        //public ObservableCollection<Trainee> Trainees
        //{
        //    get { return (ObservableCollection<Trainee>)GetValue(TraineesProperty); }
        //    set { SetValue(TraineesProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Trainees.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty TraineesProperty =
        //    DependencyProperty.Register("Trainees", typeof(ObservableCollection<Trainee>),
        //        typeof(MainWindow), new PropertyMetadata(new ObservableCollection<Trainee>()));

        public TraineeUC()
        {
            InitializeComponent();
            InitTraineesMock();
        }

        private void InitTraineesMock()
        {
            Trainees.Clear();
            foreach(var trainee in Database.GetInstance().GetAll<Trainee>()) {
                Trainees.Add(trainee);
            }
        }

        private void NewTrainee_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NewTrainertEvent, new Trainee()));
        }

        private void ExcuteRetrival_Click(object sender, RoutedEventArgs e)
        {
            Trainees = GetTraineeRerivalResults(RetrivalTrainee);
        }

        private ObservableCollection<Trainee> GetTraineeRerivalResults(Trainee retrivalTrainee)
        {
            return new ObservableCollection<Trainee>(Database.GetInstance().GetAll<Trainee>());
        }


        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void TraineeDGRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((DataGridRow)sender).DataContext is Trainee trainee)
            {
                RaiseEvent(new RoutedEventArgs(ViewTraineeEvent, trainee));
            }
        }


    }
}
