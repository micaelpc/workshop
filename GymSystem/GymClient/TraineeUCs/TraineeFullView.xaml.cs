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
    /// Interaction logic for TraineeFullView.xaml
    /// </summary>
    public partial class TraineeFullView : UserControl
    {

        public static readonly RoutedEvent NavToTraineeRetriveEvent =
            EventManager.RegisterRoutedEvent("NavToTraineeRetriveEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(TraineeFullView));

        public Trainee Trainee
        {
            get { return (Trainee)GetValue(TraineeProperty); }
            set { SetValue(TraineeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Trainee.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TraineeProperty =
            DependencyProperty.Register("Trainee", typeof(Trainee), typeof(TraineeFullView), new PropertyMetadata(new Trainee()));


        public TraineeFullView(Trainee trainee)
        {
            Trainee = trainee;
            InitializeComponent();
        }

        private void UpdateChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SetChangesToTrainee(Trainee))
            {
                MessageBox.Show("נתוני המתאמן עודכנו בהצלחה");
            }
            else
            {
                MessageBox.Show("שיבוש בעדכון");
            }
        }

        private bool SetChangesToTrainee(Trainee trainee)
        {

            //TODO - TAL set function that update the trainee details - and return true if succeded - false if not


            return true;
        }

        private void RetriveTrainees_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("השינויים שביצעת ברשומת המתאמן לא ישמרו ,\n האם אתה בטוח ?", "השנויים שביצעת בסכנה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                RaiseEvent(new RoutedEventArgs(TraineeFullView.NavToTraineeRetriveEvent));
            }
        }
    }
}
