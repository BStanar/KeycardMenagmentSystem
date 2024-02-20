using KeycardMenagmentSystem.ViewModel;
using KeycardMenagmentSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticationService _authenticationService;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticationService authenticationService, Action<Exception> onException) : base(onException)
        {
            _loginViewModel = loginViewModel;
            _authenticationService = authenticationService;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.StatusMessage = "Logging in...";

            await _authenticationService.Login(_loginViewModel.Username, _loginViewModel.Password);

            _loginViewModel.StatusMessage = "Successfully logged in.";
        }
    }
}
