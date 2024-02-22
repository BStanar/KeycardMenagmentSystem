using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.Utility_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeycardMenagmentSystem.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _hashedPassword;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                _hashedPassword = PasswordHasher.HashPassword(value);
                OnPropertyChanged(nameof(Password));
            }
        }
        private string _statusMessage;
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
                OnPropertyChanged(nameof(HasStatusMessage));
            }
        }

        public bool HasStatusMessage => !string.IsNullOrEmpty(StatusMessage);

        public ICommand LoginCommand { get; }
        public ICommand NavigateToManagerViewCommand { get; private set; }
        public ICommand NavigateToEmployeeViewCommand { get; private set; }
        private NavigateStore _navigationStore;

        public LoginViewModel(NavigateStore navigationStore)
        {
            //LoginCommand = new LoginCommand(this, new AuthenticationService(), (ex) => StatusMessage = ex.Message);
            LoginCommand = new AsyncRelayCommand(Login, (ex) => StatusMessage = ex.Message);
            _navigationStore = navigationStore;
        }

        private async Task Login()
        {
            try
            {
                StatusMessage = "Logging in...";
                Model.Users user = await new AuthenticationService().Login(Username, _hashedPassword);
                StatusMessage = $"Login successful. Role: {user.Role}";

                if (user.Role == "Manager")
                {
                    NavigateToManagerViewCommand = new NavigateToManagerViewCommand(user.ID, _navigationStore);
                    NavigateToManagerViewCommand.Execute(this);
                }
                else if(user.Role=="Employee")
                {
                    NavigateToEmployeeViewCommand = new NavigateToEmployeeViewCommand(user.ID, _navigationStore);
                    NavigateToEmployeeViewCommand.Execute(this);
                }
               
            }
            catch (UnauthorizedAccessException ex)
            {
                StatusMessage = "Login failed: " + ex.Message;
            }
            catch (Exception ex)
            {
                StatusMessage = "An error occurred: " + ex.Message;
            }
        }
    }

}
