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
using System.Windows.Shapes;

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

        private void SeeAllCards (object sender, RoutedEventArgs e)
        {
            CardsView cardsView = new CardsView();
            this.Visibility = Visibility.Hidden;
            cardsView.Visibility = Visibility.Visible;
        }

        private void GenerateReport(object sender, RoutedEventArgs e)
        {

        }
    }
}
