using GymBL.Database;
using GymBL.Entities;
using GymClient.Resources.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GymClient.PrivateTrainingsUC
{
    /// <summary>
    /// Interaction logic for PrivateTrainingsViewUC.xaml
    /// </summary>
    public partial class PrivateTrainingsViewUC : UserControl, INotifyPropertyChanged
    {
        public PrivateTrainingsViewUC()
        {
            InitPrivateTrainings();
            InitializeComponent();
        }

        private void InitPrivateTrainings()
        {
            var privateTrainings = Database.GetInstance().GetAll<PrivateTraining>();
            if (TraineeNameStr != "")
            {
                privateTrainings = privateTrainings.Where(x => x.Trainee.Firstname == TraineeNameStr || x.Trainee.Surname == TraineeNameStr).ToList();
            }
            if (TrainerNameStr != "")
            {
                privateTrainings = privateTrainings.Where(x => x.Trainer.Firstname == TrainerNameStr || x.Trainer.Surname == TrainerNameStr).ToList();
            }
            PrivateTraining = new ObservableCollection<PrivateTraining>(privateTrainings);
        }

        private ObservableCollection<PrivateTraining> _privateTrainings = new ObservableCollection<PrivateTraining>();

        public ObservableCollection<PrivateTraining> PrivateTraining
        {
            get { return _privateTrainings; }
            set
            {
                _privateTrainings = value;
                NotifyPropertyChanged("PrivateTraining");
            }
        }

        public string TrainerNameStr
        {
            get { return (string)GetValue(TrainerNameStrProperty); }
            set { SetValue(TrainerNameStrProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TrainerNameStr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TrainerNameStrProperty =
            DependencyProperty.Register("TrainerNameStr", typeof(string), typeof(PrivateTrainingsViewUC), new PropertyMetadata(string.Empty));




        public string TraineeNameStr
        {
            get { return (string)GetValue(TraineeNameStrProperty); }
            set { SetValue(TraineeNameStrProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TraineeNameStr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TraineeNameStrProperty =
            DependencyProperty.Register("TraineeNameStr", typeof(string), typeof(PrivateTrainingsViewUC), new PropertyMetadata(string.Empty));









        public PrivateTraining SelectedPrivateTraining
        {
            get { return (PrivateTraining)GetValue(SelectedPrivateTrainingProperty); }
            set { SetValue(SelectedPrivateTrainingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedPrivateTraining.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPrivateTrainingProperty =
            DependencyProperty.Register("SelectedPrivateTraining", typeof(PrivateTraining), typeof(PrivateTrainingsViewUC), new PropertyMetadata(null));










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

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            InitPrivateTrainings();
        }

        private void DeletePrivateTrainingBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPrivateTraining != null)
            {
                Database.GetInstance().Delete<PrivateTraining>(SelectedPrivateTraining.Id);
                MessageBox.Show("אימון הפרטי בוטל בהצלחה");
                SelectedPrivateTraining = null;
                InitPrivateTrainings();
            }
        }

        private void ExportExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExcelExportUtils.ExportToExcel(PrivateTrainingDG);

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            InitPrivateTrainings();
        }
    }
}
