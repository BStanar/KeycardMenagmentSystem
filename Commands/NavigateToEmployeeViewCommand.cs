using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Commands
{
    public class NavigateToEmployeeViewCommand : CommandBase
    {
        private readonly int _userID;
        private readonly NavigateStore _navigationStore;

        public NavigateToEmployeeViewCommand(int userID, NavigateStore navigationStore)
        {
            _userID = userID;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
           _navigationStore.CurrentViewModel = new EmployeeViewModel(_userID, _navigationStore);
        }
    }
}
