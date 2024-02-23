using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.View;
using KeycardMenagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Commands
{
    public class NavigateTransferLogToNewKeycardCommand : CommandBase
    {
        private readonly Users _user;
        private readonly NavigateStore _navigateStore;

        public NavigateTransferLogToNewKeycardCommand(Users user, NavigateStore navigateStore)
        {
            _user = user;
            _navigateStore = navigateStore;
        }

        public override void Execute(object? parameter)
        {
            _navigateStore.CurrentViewModel = new TransferLogsToNewCardViewModel(_user, _navigateStore);
        }
    }
}
