using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace KeycardManagmentSystem.Commands
{
    class NavigateToAccessPointViewCommand : CommandBase
    {
        private readonly NavigateStore _navigationStore;
        private readonly Users _user;
        public NavigateToAccessPointViewCommand(Users user,NavigateStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new AccessPointsViewModel(_user, _navigationStore);
        }
    }
}
