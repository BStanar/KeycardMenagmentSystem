﻿using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeycardMenagmentSystem.ViewModel
{
    public class ManagerViewModel : ViewModelBase
    {
        public ICommand LogOutCommand { get; }
        public ICommand EmployeesCommand { get; }
        public ICommand KeycardsCommand { get; }
        public ManagerViewModel(NavigateStore navigationStore)
        {
            LogOutCommand = new NavigateToLoginViewCommand(navigationStore);
            EmployeesCommand = new NavigateManagerToEmployeesCommand(navigationStore);
            KeycardsCommand = new NavigateManagerToKeycardsCommand(navigationStore);
        }

    }
}
