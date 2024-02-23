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
    public class NavigateToAssignUserToKeycard : CommandBase
    {
        private readonly Users _user;
        private readonly NavigateStore _navigateStore;

        public NavigateToAssignUserToKeycard(Users user, NavigateStore navigateStore)
        {
            _user = user;
            _navigateStore = navigateStore;
        }
        public override void Execute(object? parameter)
        {
            _navigateStore.CurrentViewModel = new AssignUserToKeycardViewModel(_user, _navigateStore);
        }
    }
}
