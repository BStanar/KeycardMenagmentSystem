using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.Store;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace KeycardMenagmentSystem.ViewModel
{
    internal class AccessPointsViewModel : ViewModelBase
    {
        private string _serial;
        public string Serial
        {
            get { return _serial; }
            set
            {
                _serial = value;
                OnPropertyChanged("Serial");
            }
        }
        private string _apName;
        public string APName
        {
            get { return _apName; }
            set
            {
                _apName = value;
                OnPropertyChanged("APName");
            }
        }
        public ObservableCollection<AccessPoint> AccessPoints { get; }
        private readonly IGetAccessPointService _getAccessPointService;

        private readonly Users _user;

        // Commands
        public ICommand SaveAccessPointCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand SelectAccessPointCommand { get; }
        public AccessPointsViewModel(Users user, NavigateStore navigateStore)
        {
            _user = user;
        }

        public AccessPointsViewModel(IGetAccessPointService getAccessPointService)
        {
            _getAccessPointService = getAccessPointService;
            AccessPoints = new ObservableCollection<AccessPoint>();

            SaveAccessPointCommand = new RelayCommand(async _ =>
            {
                var newAccessPoint = new AccessPoint(APName, Serial);
                await AddAccessPoint(newAccessPoint);
                ClearFields(); // Ensure fields are cleared after adding.
            });

            CancelCommand = new RelayCommand(_ => ClearFields()); // Consider what "Cancel" should do, e.g., clear fields.

            SelectAccessPointCommand = new RelayCommand(SelectAccessPoint);
            LoadAccessPoints();
        }

        private void SelectAccessPoint(object obj)
        {
            if (obj is AccessPoint accessPoint)
            {
                // Handle the click event, such as displaying details or performing navigation
                MessageBox.Show($"Access Point Selected: ID = {accessPoint.AccesPointID}");
            }
        }

        private async void LoadAccessPoints()
        {
            var accessPoints = await _getAccessPointService.GetAccesPoints();
            AccessPoints.Clear();
            foreach (var accessPoint in accessPoints)
            {
                AccessPoints.Add(accessPoint);
            }
        }

        public async Task AddAccessPoint(AccessPoint accessPoint)
        {
            await _getAccessPointService.AddAccessPoint(accessPoint);
            AccessPoints.Add(accessPoint);

            ClearFields();
            LoadAccessPoints();
        }


        private void ClearFields()
        {
            Serial = string.Empty;
            APName = string.Empty;
        }
    }
}
