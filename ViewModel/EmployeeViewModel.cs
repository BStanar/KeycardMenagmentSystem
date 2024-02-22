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
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly int _userID;

        public ICommand LogOutCommand { get; }
        
        public EmployeeViewModel(int userID, NavigateStore navigationStore)
        {
            LogOutCommand = new NavigateToLoginViewCommand(navigationStore);
            _userID = userID;
        }
    }
}
