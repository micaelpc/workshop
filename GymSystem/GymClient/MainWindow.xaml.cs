using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using GymBL.Entities;

namespace GymClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {




        public string koko
        {
            get { return (string)GetValue(kokoProperty); }
            set { SetValue(kokoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for koko.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty kokoProperty =
            DependencyProperty.Register("koko", typeof(string), typeof(MainWindow), new PropertyMetadata("ghfjhfjhgf"));



        public UserControl CurrentPageViewModel
        {
            get { return (UserControl)GetValue(CurrentPageViewModelProperty); }
            set { SetValue(CurrentPageViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPageViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register("CurrentPageViewModel", typeof(UserControl), typeof(MainWindow), new PropertyMetadata(null));




        public ObservableCollection<Trainee> Trainees
        {
            get { return (ObservableCollection<Trainee>)GetValue(TraineesProperty); }
            set { SetValue(TraineesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Trainees.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TraineesProperty =
            DependencyProperty.Register("Trainees", typeof(ObservableCollection<Trainee>),
                typeof(MainWindow), new PropertyMetadata(new ObservableCollection<Trainee>()));



        public MainWindow()
        {
            InitializeComponent();
            InitTraineesMock();
            CurrentPageViewModel = new UserControlTest();

        }

        private void InitTraineesMock()
        {

            Trainees.Add(new Trainee
                  ("300951212", "מיכאל", "כהן", "לויתן 6 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null));
            Trainees.Add(new Trainee
                 ("300952212", "טל", "כהן", "לויתן 5 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null));
            Trainees.Add(new Trainee
                 ("300953212", "מיכאל", "שלטי", "לויתן 7 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null));
            Trainees.Add(new Trainee
                 ("300954212", "טל", "שלטי", "לויתן 86 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null));
        }

    }
}
