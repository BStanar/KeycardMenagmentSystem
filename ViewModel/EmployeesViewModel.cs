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
    public class EmployeesViewModel : ViewModelBase
    {
        private readonly int _userID;

        public ICommand LogOutCommand { get; }
        public ICommand AccessPointsCommand { get; }
        public ICommand KeycardsCommand { get; }
        public int UserID() { return _userID; }

        public EmployeesViewModel(int userID, NavigateStore navigationStore)
        {
            LogOutCommand = new NavigateToLoginViewCommand(navigationStore);
            AccessPointsCommand = new NavigateToManagerViewCommand(_userID, navigationStore);
            KeycardsCommand = new NavigateManagerToKeycardsCommand(_userID, navigationStore);
            _userID = userID;
        }
    }
}
