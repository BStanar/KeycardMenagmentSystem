using KeycardManagmentSystem.Commands;
using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace KeycardMenagmentSystem.ViewModel
{
    public class ManagerViewModel : ViewModelBase
    {
        public ICommand LogOutCommand { get; }
        public ICommand EmployeesCommand { get; }
        public ICommand KeycardsCommand { get; }
        public ICommand AccessPointCommand { get; }
        private readonly Users _user;
        public ManagerViewModel(Users user, NavigateStore navigationStore)
        {
            _user = user;
            LogOutCommand = new NavigateToLoginViewCommand(navigationStore);
            EmployeesCommand = new NavigateManagerToEmployeesCommand(_user, navigationStore);
            KeycardsCommand = new NavigateManagerToKeycardsCommand(_user, navigationStore) ;
            AccessPointCommand = new NavigateToAccessPointViewCommand(_user, navigationStore);
        }

    }
}
