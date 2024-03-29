﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.Utility_Classes;

namespace KeycardMenagmentSystem.ViewModel
{
    public class AddUserViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _hashedPassword;

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
                _hashedPassword = PasswordHasher.HashPassword(_password);
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
            string role1;
            if (IsManager) role1 = "Manager";
            else role1 = "Employee";

            var newUser = new Users
            {
                Email = Email,
                Password = _hashedPassword,
                FirstName = Name,
                Lastname = LastName,
                StartOfEmployment = DateOfEmployment,
                Role = role1
            };

            var result = MessageBox.Show("Are you sure you want to add this user?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
           
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("User Added");
                UserService service = new UserService();
                service.AddUser(newUser);

                StatusMessage = "User added successfully.";
                ClearFields();
            }
            else
            {
                StatusMessage = "User addition canceled.";
            }
        }

        private bool CanAddUser(object parameter)
        {
            return !string.IsNullOrEmpty(Email) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(Name) &&
                   !string.IsNullOrEmpty(LastName) &&
                   DateOfEmployment != default;
        }

        private void ClearFields()
        {
            Email = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            DateOfEmployment = default;
            IsManager = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
