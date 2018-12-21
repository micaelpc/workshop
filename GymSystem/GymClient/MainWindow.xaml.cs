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
using GymClient.TraineeUCs;

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






        public UserControl CurrentTraineeUC
        {
            get { return (UserControl)GetValue(CurrentTraineeUCProperty); }
            set { SetValue(CurrentTraineeUCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentTraineeUC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentTraineeUCProperty =
            DependencyProperty.Register("CurrentTraineeUC", typeof(UserControl), typeof(MainWindow), new PropertyMetadata(null));





        public UserControl CurrentPageViewModel
        {
            get { return (UserControl)GetValue(CurrentPageViewModelProperty); }
            set { SetValue(CurrentPageViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPageViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register("CurrentPageViewModel", typeof(UserControl), typeof(MainWindow), new PropertyMetadata(null));







        public MainWindow()
        {
            InitializeComponent();
            InitEvents();
            InitUCs();
        }

        private void InitUCs()
        {
            CurrentPageViewModel = new UserControlTest();
            CurrentTraineeUC = new TraineeUC();
        }

        private void InitEvents()
        {
            AddHandler(TraineeUC.NewTrainertEvent,
                     new RoutedEventHandler(NewTrainertEvent_handler));
        }

        private void NewTrainertEvent_handler(object sender, RoutedEventArgs e)
        {
            CurrentTraineeUC = new NewTraineeUC();
        }
    }
}
