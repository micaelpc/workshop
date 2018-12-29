using GymBL.Database;
using GymBL.Entities;
using GymClient.Resources.Utils;
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

        private ObservableCollection<TimeSpanOfWeek> _workDays = new ObservableCollection<TimeSpanOfWeek>();

        public ObservableCollection<TimeSpanOfWeek> WorkDays
        {
            get { return _workDays; }
            set
            {
                _workDays = value;
                OnPropertyChanged("WorkDays");
            }
        }

        private DayOfWeek _day;

        public DayOfWeek Day
        {
            get { return _day; }
            set
            {
                _day = value;
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

        private Trainer _trainer;
        public Trainer Trainer { get { return _trainer; } set { _trainer = value;
                OnPropertyChanged("Trainer");

            } }

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
