using KeycardMenagmentSystem.Commands;
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
        private readonly int _userID;
        public int UserID() { return _userID; }
        public ManagerViewModel(int userID, NavigateStore navigationStore)
        {
            _userID = userID;
            LogOutCommand = new NavigateToLoginViewCommand(navigationStore);
            EmployeesCommand = new NavigateManagerToEmployeesCommand(_userID, navigationStore);
            KeycardsCommand = new NavigateManagerToKeycardsCommand(_userID, navigationStore) ;
        }

    }
}
