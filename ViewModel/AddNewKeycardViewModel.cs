using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Commands;
using KeycardManagmentSystem.Services;
using KeycardMenagmentSystem.ViewModel;

namespace KeycardMenagmentSystem.ViewModel
{
    public class AddNewKeycardViewModel : INotifyPropertyChanged
    {
        private readonly IAddNewKeycard _keycardService;
        private string _serialCode;
        private int _userId;
        private bool _activated;
        public ICommand AddKeycardCommand { get; }

        public string SerialCode
        {
            get => _serialCode;
            set
            {
                _serialCode = value;
                OnPropertyChanged(nameof(SerialCode));
                // Notify that the CanExecute state of the AddKeycardCommand may have changed
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public bool Activated
        {
            get => _activated;
            set
            {
                _activated = value;
                OnPropertyChanged(nameof(Activated));
            }
        }

        public AddNewKeycardViewModel(IAddNewKeycard keycardService)
        {
            _keycardService = keycardService;
            AddKeycardCommand = new RelayCommand(async (o) => await AddKeycard(), (o) => CanAddKeycard());
        }

        private bool CanAddKeycard()
        {
            return !string.IsNullOrWhiteSpace(SerialCode); // Only enable the command if a serial code is present
        }

        private async Task AddKeycard()
        {
            if (!CanAddKeycard()) return; // Additional check to guard against direct method calls

            var keycard = new Keycard(this.SerialCode, this.UserId, this.Activated);
            

            await _keycardService.AddNewKeycard(keycard);
            // Reset or update the UI as needed after adding the keycard
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Assuming RelayCommand is implemented somewhere in your project, following ICommand interface
    // Adjust it according to your actual implementation
}
