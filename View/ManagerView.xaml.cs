using System.Windows.Controls;

namespace KeycardMenagmentSystem.View
{
    /// <summary>
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : UserControl
    {
        public ManagerView()
        {
            InitializeComponent();
        }

        private void Logs_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void _2DPieChart_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Logs_Loaded_1(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            KeycardsView keycardsView = new KeycardsView();
            this.Content = keycardsView;
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            AddAccesPointView keycardsView = new AddAccesPointView();
            this.Content = keycardsView;
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {

            AddUserView keycardsView = new AddUserView();
            this.Content = keycardsView;
        }
    }
}
