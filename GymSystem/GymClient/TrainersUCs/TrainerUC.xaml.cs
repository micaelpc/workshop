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

namespace GymClient
{
    /// <summary>
    /// Interaction logic for TrainerUC.xaml
    /// </summary>
    public partial class TrainerUC : UserControl, INotifyPropertyChanged
    {
        public TrainerUC()
        {
            InitializeComponent();
            InitActiveTrainersList();
        }

        private void InitActiveTrainersList()
        {
            //TODO TAL set List of all active trainerts (with prop is active 1 )
            ///and replace that mock
            ///in the active trainers
            ActiveTrainers =  new ObservableCollection<Trainer> {
                new Trainer {Firstname = "מאמני" ,Surname="מגניבי",IDNumber="123456789"},
                new Trainer {Firstname = "מאמני1" ,Surname="מגניבי1",IDNumber="122456789"},
                new Trainer {Firstname = "2מאמני" ,Surname="מגניבי2",IDNumber="124456789"}
            };
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









    }
}
