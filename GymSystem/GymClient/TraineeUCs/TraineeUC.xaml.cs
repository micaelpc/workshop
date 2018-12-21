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
    /// Interaction logic for Trainee.xaml
    /// </summary>
    public partial class TraineeUC : UserControl ,INotifyPropertyChanged
    {


        public static readonly RoutedEvent NewTrainertEvent =
            EventManager.RegisterRoutedEvent("NewTrainertEvent", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(TraineeUC));




        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Trainee RetrivalTrainee
        {
            get { return (Trainee)GetValue(RetrivalTraineeProperty); }
            set { SetValue(RetrivalTraineeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RetrivalTrainee.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RetrivalTraineeProperty =
            DependencyProperty.Register("RetrivalTrainee", typeof(Trainee), typeof(MainWindow), new PropertyMetadata(null));



        public ObservableCollection<Trainee> Trainees
        {
            get { return (ObservableCollection<Trainee>)GetValue(TraineesProperty); }
            set { SetValue(TraineesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Trainees.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TraineesProperty =
            DependencyProperty.Register("Trainees", typeof(ObservableCollection<Trainee>),
                typeof(MainWindow), new PropertyMetadata(new ObservableCollection<Trainee>()));

        public TraineeUC()
        {
            InitializeComponent();
            InitTraineesMock();
            RetrivalTrainee = new Trainee
            {
                IDNumber = "123456789",
                Surname = "כהן",
                Firstname = "מיכאל"
            };
        }

        private void InitTraineesMock()
        {
            Trainees.Clear();
            Trainees.Add(new Trainee
                  ("300951212", "מיכאל", "כהן", "לויתן 6 חולון", 
                  "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now,
                  "רגיש ללקטוז", null,new List<Subscription>()));
            Trainees.Add(new Trainee
                 ("300952212", "טל", "כהן", "לויתן 5 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null, new List<Subscription>()));
            Trainees.Add(new Trainee
                 ("300953212", "מיכאל", "שלטי", "לויתן 7 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null, new List<Subscription>()));
            Trainees.Add(new Trainee
                 ("300954212", "טל", "שלטי", "לויתן 86 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null, new List<Subscription>()));
        }

        private void NewTrainee_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NewTrainertEvent,new Trainee()));
        }
    }
}
