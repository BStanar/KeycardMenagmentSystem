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

namespace KeycardMenagmentSystem.View
{
    /// <summary>
    /// Interaction logic for AddNewCardViewModel.xaml
    /// </summary>
    public partial class AddNewCardView : UserControl
    {
        public AddNewCardView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KeycardsView keycardsView = new KeycardsView();
            this.Content = keycardsView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            AddUserView keycardsView = new AddUserView();
            this.Content = keycardsView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddAccesPointView keycardsView = new AddAccesPointView();
            this.Content = keycardsView;
        }
    }
}
