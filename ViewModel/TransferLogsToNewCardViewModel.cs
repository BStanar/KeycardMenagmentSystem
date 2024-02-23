using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeycardMenagmentSystem.ViewModel
{
    public class TransferLogsToNewCardViewModel : ViewModelBase
    {
        private readonly Users _user;
        public ICommand EmployeesCommand { get; }
        public ICommand LogOutCommand { get; }
        public ICommand AddNewKeycard { get; }
        public ICommand TransferLogToNewCard { get; }
        public TransferLogsToNewCardViewModel(Users user, NavigateStore navigateStore)
        {
            _user = user;
            EmployeesCommand = new NavigateManagerToEmployeesCommand(user, navigateStore);
            LogOutCommand = new NavigateToLoginViewCommand(navigateStore);
            AddNewKeycard = new NavigateToAddNewKeycardCommand(user, navigateStore);
            TransferLogToNewCard = new NavigateTransferLogToNewKeycardCommand(user, navigateStore);
        }
    }
}
