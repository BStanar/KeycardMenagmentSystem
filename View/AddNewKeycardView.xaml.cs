using KeycardMenagmentSystem.ViewModel;
using KeycardManagementSystem;
using KeycardManagmentSystem.Services;
using KeycardManagementSystem;
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
using KeycardMenagmentSystem;
using KeycardMenagmentSystem.ViewModel;
using KeycardMenagmentSystem.Services;

namespace KeycardManagmentSystem.View
{
    /// <summary>
    /// Interaction logic for AddNewKeycardView.xaml
    /// </summary>
    public partial class AddNewKeycardView : UserControl
    {
        public AddNewKeycardView()
        {
            InitializeComponent();
            var keycardService = new AddKeycardService(); // Create an instance of your service
            this.DataContext = new AddNewKeycardViewModel(keycardService); // Pass it to the ViewModel constructor
        }
    }

}
