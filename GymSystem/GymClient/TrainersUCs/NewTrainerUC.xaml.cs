using GymBL.Database;
using GymBL.Entities;
using GymClient.Resources.Utils;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for NewTrainerUC.xaml
    /// </summary>
    public partial class NewTrainerUC : UserControl, INotifyPropertyChanged
    {
        public static readonly RoutedEvent NavToTrainerRetriveEvent =
            EventManager.RegisterRoutedEvent("NavToTrainerRetriveEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(NewTrainerUC));

        public NewTrainerUC()
        {
            NewTrainer = new Trainer();
            InitializeComponent();
        }

        private Trainer _newTrainer;

        public Trainer NewTrainer { get { return _newTrainer; }
            set {
                _newTrainer = value;
                OnPropertyChanged("NewTrainer");
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

        private void AddNewTrainerBtn_Click(object sender, RoutedEventArgs e)
        {
            Database.GetInstance().Insert(NewTrainer);
            MessageBox.Show("המאמן הוכנס בהצלחה");

            RaiseEvent(new RoutedEventArgs(NavToTrainerRetriveEvent));
        }

        private void LoadPictureBtn_Click(object sender, RoutedEventArgs e)
        {
            var bA = ImageUtils.GetImageByteArrayFromFile();
            if (bA != null)
            {
                NewTrainer.Picture = bA;
            }
        }

        private void ReturntToDefaltBtn_Click(object sender, RoutedEventArgs e)
        {
            NewTrainer = new Trainer();
        }



        private void RetriveTrainer_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NavToTrainerRetriveEvent));
        }
    }
}
