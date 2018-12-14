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
        public ObservableCollection<Trainee> trainees = new ObservableCollection<Trainee>();
        public MainWindow()
        {
            InitializeComponent();
            InitTraineesMock();
        }

        private void InitTraineesMock()
        {
            //trainees.Add(new Trainee
            //      ("300951212", "מיכאל", "כהן", "לויתן 6 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null));
            //trainees.Add(new Trainee
            //     ("300952212", "טל", "כהן", "לויתן 5 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null));
            //trainees.Add(new Trainee
            //     ("300953212", "מיכאל", "שלטי", "לויתן 7 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null));
            //trainees.Add(new Trainee
            //     ("300954212", "טל", "שלטי", "לויתן 86 חולון", "0528998829", "0528998829", "micaelpc@gmail.com", DateTime.Now, "רגיש ללקטוז", null));
        }

    }
}
