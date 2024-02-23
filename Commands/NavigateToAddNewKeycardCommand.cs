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
    public class NavigateToAddNewKeycardCommand : CommandBase
    {
        private readonly Users user;
        private readonly NavigateStore _navigateStore;

        public NavigateToAddNewKeycardCommand(Users user, NavigateStore navigateStore)
        {
            this.user = user;
            _navigateStore = navigateStore;
        }

        public override void Execute(object? parameter)
        {
            _navigateStore.CurrentViewModel = new AddNewKeycardViewModel(user, _navigateStore);
        }
    }
}
