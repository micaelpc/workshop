using GymBL.Database;
using GymBL.Entities;
using GymClient.Resources.Utils;
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

        #region EventsRegisters
        public static readonly RoutedEvent NewTraineetEvent =
          EventManager.RegisterRoutedEvent("NewTraineetEvent", RoutingStrategy.Bubble,
          typeof(RoutedEventHandler), typeof(TraineeUC));

        public static readonly RoutedEvent ViewTraineeEvent =
            EventManager.RegisterRoutedEvent("ViewTraineeEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(TraineeUC));

        #endregion

        #region Model items
        public Trainee RetrivalTrainee
        {
            get { return (Trainee)GetValue(RetrivalTraineeProperty); }
            set { SetValue(RetrivalTraineeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RetrivalTrainee.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RetrivalTraineeProperty =
            DependencyProperty.Register("RetrivalTrainee", typeof(Trainee), typeof(MainWindow), new PropertyMetadata(new Trainee()));
        #endregion


        private ObservableCollection<Trainee> m_trainees = new ObservableCollection<Trainee>();
        private Trainee m_selectedTrainee = new Trainee();

        public ObservableCollection<Trainee> Trainees
        {
            get { return m_trainees; }
            set
            {
                m_trainees = value;
                NotifyPropertyChanged("Trainees");
            }
        }


        public Trainee SelectedTrainee
        {
            get { return m_selectedTrainee; }
            set
            {
                m_selectedTrainee = value;
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
            InitTrainees();
        }

        private void InitTrainees()
        {
            Trainees.Clear();
            foreach(var trainee in Database.GetInstance().GetAll<Trainee>()) {
                Trainees.Add(trainee);
            }
        }

        private ObservableCollection<Trainee> GetTraineeRerivalResults(Trainee retrivalTrainee)
        {
            var clauses = new List<string>();
            if (retrivalTrainee.IDNumber != "")
                clauses.Add($"id = '{retrivalTrainee.IDNumber}'");
            if(retrivalTrainee.Firstname != "" && retrivalTrainee.Firstname != null)
                clauses.Add($"Firstname like N'{retrivalTrainee.Firstname}'");
            if (retrivalTrainee.Surname != "" && retrivalTrainee.Surname != null)
                clauses.Add($"Surname like N'{retrivalTrainee.Surname}'");
            
            if(clauses.Count == 0)
                return new ObservableCollection<Trainee>(Database.GetInstance().GetAll<Trainee>());
            else
            {
                return new ObservableCollection<Trainee>(Database.GetInstance().GetAll<Trainee>(string.Join(" and ", clauses)));
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


        #region EventHandlers
        private void TraineeDGRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((DataGridRow)sender).DataContext is Trainee trainee)
            {
                RaiseEvent(new RoutedEventArgs(ViewTraineeEvent, trainee));
            }
        }

        private void NewTrainee_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NewTraineetEvent, new Trainee()));
        }

        private void ExcuteRetrival_Click(object sender, RoutedEventArgs e)
        {
            Trainees = GetTraineeRerivalResults(RetrivalTrainee);
        }

        #endregion

        private void ExcelExportBtn_Click(object sender, RoutedEventArgs e)
        {
            ExcelExportUtils.ExportToExcel(this.TraineesDG);
        }

        private void DeleteTraineeBtn_Click(object sender, RoutedEventArgs e)
        {
            Database.GetInstance().Delete<Trainee>(SelectedTrainee.GetId());
            MessageBox.Show("המתאמן נמחק בהצלחה");
            SelectedTrainee = null;
            InitTrainees();
        }
    }
}
