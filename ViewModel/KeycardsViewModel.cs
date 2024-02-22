using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeycardMenagmentSystem.ViewModel
{
    public class KeycardsViewModel : ViewModelBase
    {
        private readonly Users _user;

        public ICommand LogOutCommand { get; }
        public ICommand AccessPointsCommand { get; }
        public ICommand EmployeesCommand { get; }
        
        public KeycardsViewModel(Users user, NavigateStore navigateStore) 
        {
            LogOutCommand = new NavigateToLoginViewCommand(navigateStore);
            EmployeesCommand = new NavigateManagerToEmployeesCommand(_user, navigateStore);
            AccessPointsCommand = new NavigateToManagerViewCommand(_user, navigateStore);
            _user = user;
        }
    }
}
