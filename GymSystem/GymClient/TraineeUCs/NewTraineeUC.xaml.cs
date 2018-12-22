using GymBL.Entities;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for NewTraineeUC.xaml
    /// </summary>
    public partial class NewTraineeUC : UserControl
    {
        public NewTraineeUC()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent NavToTraineeRetriveEvent =
            EventManager.RegisterRoutedEvent("NavToTraineeRetriveEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(TraineeUC));

        private void RetriveTrainee_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NewTraineeUC.NavToTraineeRetriveEvent, new Trainee()));
        }



        private void ReturntToDefaltBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewTrainee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
