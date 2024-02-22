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
    public class EmployeesViewModel : ViewModelBase
    {
        public ICommand LogOutCommand { get; }
        public ICommand AccessPointsCommand { get; }
        public ICommand KeycardsCommand { get; }
        public EmployeesViewModel(NavigateStore navigationStore)
        {
            LogOutCommand = new NavigateToLoginViewCommand(navigationStore);
            AccessPointsCommand = new NavigateToManagerViewCommand(navigationStore);
            KeycardsCommand = new NavigateManagerToKeycardsCommand(navigationStore);
        }
    }
}
