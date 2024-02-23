using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeycardMenagmentSystem.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly Users _user;

        public ICommand LogOutCommand { get; }

        public string usernameEmployee => _user.Username;
        public string nameEmployee => _user.FirstName;
        public string cardNumberEmployee => _user.CardSerialNumber;

        public EmployeeViewModel(Users user, NavigateStore navigationStore)
        {
            LogOutCommand = new NavigateToLoginViewCommand(navigationStore);
            _user = user;
        }
    }
}
