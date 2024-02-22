using KeycardMenagmentSystem.Model;
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
        private readonly Users _user;
        private readonly NavigateStore _navigationStore;

        public NavigateToEmployeeViewCommand(Users user, NavigateStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
           _navigationStore.CurrentViewModel = new EmployeeViewModel(_user, _navigationStore);
        }
    }
}
