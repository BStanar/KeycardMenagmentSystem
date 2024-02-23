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
        public ICommand AddNewKeycard { get; }
        public ICommand AssignUserToKeycard { get; }
        public ICommand TranswerLogToNewKeycard { get; }
        public KeycardsViewModel(Users user, NavigateStore navigateStore)
        { 
            _user = user;
            LogOutCommand = new NavigateToLoginViewCommand(navigateStore);
            EmployeesCommand = new NavigateManagerToEmployeesCommand(_user, navigateStore);
            AccessPointsCommand = new NavigateToManagerViewCommand(_user, navigateStore);
            AddNewKeycard = new NavigateToAddNewKeycardCommand(_user, navigateStore);
            AssignUserToKeycard = new NavigateToAssignUserToKeycard(_user, navigateStore);
            TranswerLogToNewKeycard = new NavigateTransferLogToNewKeycardCommand(_user, navigateStore);
        }

    }
}
