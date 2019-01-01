using GymBL.Database;
using GymBL.Entities;
using GymClient.Resources.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GymClient.TrainersUCs
{
    /// <summary>
    /// Interaction logic for TrainerFullView.xaml
    /// </summary>
    public partial class TrainerFullView : UserControl, INotifyPropertyChanged
    {

        public static readonly RoutedEvent NavToTrainerRetriveEvent =
                EventManager.RegisterRoutedEvent("NavToTrainerRetriveEvent", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(TrainerFullView));

        private ObservableCollection<TimeSpanOfWeek> m_workDays = new ObservableCollection<TimeSpanOfWeek>();

        public ObservableCollection<TimeSpanOfWeek> WorkDays
        {
            get { return m_workDays; }
            set
            {
                m_workDays = value;
                OnPropertyChanged("WorkDays");
            }
        }

        private DayOfWeek m_day;

        public DayOfWeek Day
        {
            get { return m_day; }
            set
            {
                m_day = value;
                OnPropertyChanged("Day");
            }
        }

        public TrainerFullView(Trainer trainer)
        {
            Trainer = trainer;
            WorkDays = new ObservableCollection<TimeSpanOfWeek>();
            foreach (var day in
                trainer.WorkDays)
            {
                WorkDays.Add(day);
            }


            InitializeComponent();
        }

        #region INotifyPropertyChanged Imp
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        private Trainer m_trainer;
        public Trainer Trainer
        {
            get { return m_trainer; }
            set
            {
                m_trainer = value;
                OnPropertyChanged("Trainer");

            }
        }

        private void UpdateChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            Trainer.WorkDays = WorkDays;
            Database.GetInstance().Update(Trainer);
            MessageBox.Show("עודכן בהצלחה");
        }

        private void RetriveTrainers_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NavToTrainerRetriveEvent));
        }

        private void LoadPictureBtn_Click(object sender, RoutedEventArgs e)
        {
            var bA = ImageUtils.GetImageByteArrayFromFile();
            if (bA != null)
            {
                Trainer.Picture = bA;
            }
        }

        private void AddDayOfWorkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!WorkDays.Any(x => x.Day == Day))
            {
                WorkDays.Add(new TimeSpanOfWeek { Day = Day });
            }
            else
            {
                MessageBox.Show("יום זה כבר קיים בזמינויות של המאמן");
            }
        }
    }
}
