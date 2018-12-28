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

        private Trainer _retrivalTrainer;


        public Trainer RetrivalTrainer {
            get { return _retrivalTrainer; }
            set { _retrivalTrainer = value;
                OnPropertyChanged("RetrivalTrainer");
            } }

        public TrainerUC()
        {
            InitializeComponent();
            InitActiveTrainersList();
        }

        private void InitActiveTrainersList()
        {
            //TODO TAL set List of all active trainerts (with prop is active 1 )
            //TODO Michael there's no prop is active. We can delete inactive. easier.
            ActiveTrainers =  new ObservableCollection<Trainer> (Database.GetInstance().GetAll<Trainer>());
        }

        private ObservableCollection<Trainer> _activeTrainers = new ObservableCollection<Trainer>();

        public ObservableCollection<Trainer> ActiveTrainers {
            get { return _activeTrainers; }
            set {
                _activeTrainers = value;
                OnPropertyChanged("ActiveTrainers");
            }

        }




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

        }

        private void ExcuteRetrival_Click(object sender, RoutedEventArgs e)
        {
            ///TODO TAL retrival by RetrivalTrainer props
            ///
            //ActiveTrainers = //TODO TAL put the results here

        }



        private void NewTrainer_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NewTrainertEvent));
        }
    }
}
