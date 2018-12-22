using GymBL.Contract;
using GymBL.Database;
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
            NewTrainee.Firstname = "קוקוקו";
            InitializeComponent();
        }

        public static readonly RoutedEvent NavToTraineeRetriveEvent =
            EventManager.RegisterRoutedEvent("NavToTraineeRetriveEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(TraineeUC));





        public Trainee NewTrainee
        {
            get { return (Trainee)GetValue(NewTraineeProperty); }
            set { SetValue(NewTraineeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewTrainee.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewTraineeProperty =
            DependencyProperty.Register("NewTrainee", typeof(Trainee), typeof(NewTraineeUC), new PropertyMetadata(new Trainee()));





        private void RetriveTrainee_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NewTraineeUC.NavToTraineeRetriveEvent, new Trainee()));
        }



        private void ReturntToDefaltBtn_Click(object sender, RoutedEventArgs e)
        {
            NewTrainee = new Trainee();
        }

        private void AddNewTrainee_Click(object sender, RoutedEventArgs e)
        {
           Response res =   AddNewTrainee(NewTrainee);

            if (res.ResponseStatus== ResponseStatusType.Success)
            {
                MessageBox.Show("המתאמן הוכנס בהצלחה");
                RaiseEvent(new RoutedEventArgs(NewTraineeUC.NavToTraineeRetriveEvent, new Trainee()));
            }
            else
            {
                MessageBox.Show(res.FailedReasons.FirstOrDefault(), "אירעה שגיאה");
            }
        }

        private Response AddNewTrainee(Trainee newTrainee)
        {
            try
            {
                Database.GetInstance().Insert(newTrainee);
                return new Response { ResponseStatus = ResponseStatusType.Success };
            }
            catch (Exception e) {
                return Response.FromException(e);
            }
        }
    }
}
