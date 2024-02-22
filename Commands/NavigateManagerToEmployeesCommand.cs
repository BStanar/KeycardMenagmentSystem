using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Commands
{
    public class NavigateManagerToEmployeesCommand : CommandBase
    {
        private readonly int _userID;
        private readonly NavigateStore _navigationStore;

        public NavigateManagerToEmployeesCommand(int userID, NavigateStore navigationStore)
        {
            _userID = userID;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new EmployeesViewModel(_userID, _navigationStore);
        }
    }
}
