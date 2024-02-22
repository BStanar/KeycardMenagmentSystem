using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeycardMenagmentSystem.ViewModel
{
    public class KeycardsViewModel : ViewModelBase
    {
        public ICommand LogOutCommand { get; }
        public ICommand AccessPointsCommand { get; }
        public ICommand EmployeesCommand { get; }

        public KeycardsViewModel(NavigateStore navigateStore) 
        {
            LogOutCommand = new NavigateToLoginViewCommand(navigateStore);
            EmployeesCommand = new NavigateManagerToEmployeesCommand(navigateStore);
            AccessPointsCommand = new NavigateToManagerViewCommand(navigateStore);
        }
    }
}
