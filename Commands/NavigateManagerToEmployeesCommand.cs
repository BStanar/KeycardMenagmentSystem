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
    public class NavigateManagerToEmployeesCommand : CommandBase
    {
        private readonly Users _user;
        private readonly NavigateStore _navigationStore;

        public NavigateManagerToEmployeesCommand(Users user, NavigateStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new EmployeesViewModel(_user, _navigationStore);
        }
    }
}
