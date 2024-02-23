using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Services;
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
using KeycardManagementSystem.Model;
using KeycardMenagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace KeycardMenagmentSystem.View
{
    /// <summary>
    /// Interaction logic for EMMenagmentView.xaml
    /// </summary>
    /// 
    
    public partial class EMMenagmentView : UserControl
    {

        public List<Users> users= new List<Users>();
        public EMMenagmentView()
        {
        InitializeComponent();

        }

        public void InitializeList()
        {
           UserService usersService = new UserService();
        }

        
    }

    

}
