﻿using KeycardMenagmentSystem.Model;
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
        private readonly Users _user;

        public NavigateToManagerViewCommand(Users user, NavigateStore navigationStore)
        {
            _user = user;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ManagerViewModel(_user, _navigationStore);
        }
    }
}
