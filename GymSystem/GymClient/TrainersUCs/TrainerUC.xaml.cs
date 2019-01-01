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

namespace GymClient
{
    /// <summary>
    /// Interaction logic for TrainerUC.xaml
    /// </summary>
    public partial class TrainerUC : UserControl, INotifyPropertyChanged
    {

        #region EventsRegisters
        public static readonly RoutedEvent NewTrainertEvent =
          EventManager.RegisterRoutedEvent("NewTrainertEvent", RoutingStrategy.Bubble,
          typeof(RoutedEventHandler), typeof(TrainerUC));

        public static readonly RoutedEvent ViewTrainerEvent =
            EventManager.RegisterRoutedEvent("ViewTrainerEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(TrainerUC));

        #endregion

        private Trainer m_retrivalTrainer;


        public Trainer RetrivalTrainer {
            get { return m_retrivalTrainer; }
            set { m_retrivalTrainer = value;
                OnPropertyChanged("RetrivalTrainer");
            } }


        public TrainerUC()
        {
            RetrivalTrainer = new Trainer();
            InitializeComponent();
            InitActiveTrainersList();
        }

        private void InitActiveTrainersList()
        {
            ActiveTrainers = new ObservableCollection<Trainer> (Database.GetInstance().GetAll<Trainer>());
        }

        private ObservableCollection<Trainer> m_activeTrainers = new ObservableCollection<Trainer>();

        public ObservableCollection<Trainer> ActiveTrainers {
            get { return m_activeTrainers; }
            set {
                m_activeTrainers = value;
                OnPropertyChanged("ActiveTrainers");
            }

        }




        public Trainer SelectedTrainer
        {
            get { return (Trainer)GetValue(SelectedTrainerProperty); }
            set { SetValue(SelectedTrainerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedTrainer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedTrainerProperty =
            DependencyProperty.Register("SelectedTrainer", typeof(Trainer), typeof(TrainerUC), new PropertyMetadata(new Trainer()));



        #region INotifyPropertyChanged Imp
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion



        private void ExportExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExcelExportUtils.ExportToExcel(TrainersDG);

        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((DataGridRow)sender).DataContext is Trainer trainer)
            {
                RaiseEvent(new RoutedEventArgs(ViewTrainerEvent, trainer));
            }
        }

        private void ExcuteRetrival_Click(object sender, RoutedEventArgs e)
        {

            var clauses = new List<string>();
            if (RetrivalTrainer.IDNumber != "")
                clauses.Add($"id = '{RetrivalTrainer.IDNumber}'");
            if (RetrivalTrainer.Firstname != "" && RetrivalTrainer.Firstname != null)
                clauses.Add($"Firstname like N'{RetrivalTrainer.Firstname}'");
            if (RetrivalTrainer.Surname != "" && RetrivalTrainer.Surname != null)
                clauses.Add($"Surname like N'{RetrivalTrainer.Surname}'");

            if (clauses.Count == 0)
                ActiveTrainers = new ObservableCollection<Trainer>(Database.GetInstance().GetAll<Trainer>());
            else
            {
                ActiveTrainers = new ObservableCollection<Trainer>(Database.GetInstance().GetAll<Trainer>(string.Join(" and ", clauses)));
            }
        }



        private void NewTrainer_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NewTrainertEvent));
        }

        private void DeleteTrainerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTrainer!=null)
            {
                Database.GetInstance().Delete<Trainer>(SelectedTrainer.GetId());
                MessageBox.Show("המאמן נמחק בהצלחה");
                SelectedTrainer = null;
                InitActiveTrainersList();
            }
            else
            {
                MessageBox.Show("סמן מאמן למחיקה");
            }
        }

    }
}
