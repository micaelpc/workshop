using GymBL.Database;
using GymBL.Entities;
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
            try
            {
                Database.GetInstance().Update(Trainee);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        private void RetriveTrainees_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("השינויים שביצעת ברשומת המתאמן לא ישמרו ,\n האם אתה בטוח ?", "השנויים שביצעת בסכנה", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                RaiseEvent(new RoutedEventArgs(TraineeFullView.NavToTraineeRetriveEvent));
            }
        }

        private void LoadPictureBtn_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage img;
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == DialogResult.OK)
            {
                img = new BitmapImage(new Uri(op.FileName));
                Trainee.Picture = ImageToByte(img);
            }

        }

        public Byte[] ImageToByte(BitmapImage imageSource)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
    }
}
