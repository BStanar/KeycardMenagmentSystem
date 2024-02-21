using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Commands
{
    public class NavigateToManagerViewCommand : CommandBase
    {
        private readonly NavigateStore _navigationStore;

        public NavigateToManagerViewCommand(NavigateStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ManagerViewModel(_navigationStore);
        }
    }
}
