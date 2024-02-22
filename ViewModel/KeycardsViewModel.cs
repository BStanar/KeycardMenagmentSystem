using KeycardMenagmentSystem.Commands;
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
        private readonly  int _userID;

        public ICommand LogOutCommand { get; }
        public ICommand AccessPointsCommand { get; }
        public ICommand EmployeesCommand { get; }
        public int UserID() { return _userID; }
        
        public KeycardsViewModel(int userID, NavigateStore navigateStore) 
        {
            LogOutCommand = new NavigateToLoginViewCommand(navigateStore);
            EmployeesCommand = new NavigateManagerToEmployeesCommand(_userID, navigateStore);
            AccessPointsCommand = new NavigateToManagerViewCommand(_userID, navigateStore);
            _userID = userID;
        }
    }
}
