using GymBL.Contract;
using GymBL.Database;
using GymBL.Entities;
using GymClient.Resources.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

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
            NewTrainee = new Trainee();
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

            if (res.ResponseStatus== ResponseStatusEnum.Success)
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
                return new Response { ResponseStatus = ResponseStatusEnum.Success };
            }
            catch (Exception e) {
                return Response.FromException(e);
            }
        }

        private void LoadPictureBtn_Click(object sender, RoutedEventArgs e)
        {
           var bA= ImageUtils.GetImageByteArrayFromFile();
            if (bA!=null)
            {
                NewTrainee.Picture = bA;
            }
        }
    }
}
