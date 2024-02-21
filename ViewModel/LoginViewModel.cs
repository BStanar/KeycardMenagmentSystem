using KeycardMenagmentSystem.Commands;
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
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
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
        public ICommand NavigateToAccessPointListing { get; private set; }
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
                Model.Users user = await new AuthenticationService().Login(Username, Password);
                StatusMessage = $"Login successful. Role: {user.Role}";

                if (user.Role == "Manager")
                {
                    NavigateToAccessPointListing = new NavigateToAccessPointListingCommand(_navigationStore);
                    NavigateToAccessPointListing.Execute(this);
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
