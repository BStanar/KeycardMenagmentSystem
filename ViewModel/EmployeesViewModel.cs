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
    public class EmployeesViewModel : ViewModelBase
    {
        private readonly Users _user;

        public ICommand LogOutCommand { get; }
        public ICommand AccessPointsCommand { get; }
        public ICommand KeycardsCommand { get; }

        public EmployeesViewModel(Users user, NavigateStore navigationStore)
        {
            LogOutCommand = new NavigateToLoginViewCommand(navigationStore);
            AccessPointsCommand = new NavigateToManagerViewCommand(_user, navigationStore);
            KeycardsCommand = new NavigateManagerToKeycardsCommand(_user, navigationStore);
            _user = user;
        }
    }
}
