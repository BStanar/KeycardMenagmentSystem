using System;
using System.ComponentModel;
using System.Windows.Input;
using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Services;

namespace KeycardMenagmentSystem.ViewModel
{
    public class AddUserViewModel : INotifyPropertyChanged
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private DateTime _dateOfEmployment;
        public DateTime DateOfEmployment
        {
            get { return _dateOfEmployment; }
            set
            {
                _dateOfEmployment = value;
                OnPropertyChanged("DateOfEmployment");
            }
        }

        private bool _isManager;
        public bool IsManager
        {
            get { return _isManager; }
            set
            {
                _isManager = value;
                OnPropertyChanged("IsManager");
            }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged("StatusMessage");
            }
        }

        public ICommand AddUserCommand { get; private set; }

        public AddUserViewModel()
        {
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);
        }

        private void AddUser(object parameter)
        {
            var newUser = new Users
            {
                Email = Email,
                Password = Password,
                FirstName = Name,
                Lastname = LastName,
                StartOfEmployment = DateOfEmployment,
                
                
            };

            UserService service = new UserService();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            service.AddUser(newUser);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            StatusMessage = "User added successfully.";
            ClearFields();
        }

        private bool CanAddUser(object parameter)
        {
            return !string.IsNullOrEmpty(Email) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(Name) &&
                   !string.IsNullOrEmpty(LastName) &&
                   DateOfEmployment != default(DateTime);
        }

        private void ClearFields()
        {
            Email = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            DateOfEmployment = default(DateTime);
            IsManager = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
