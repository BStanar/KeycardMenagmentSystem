using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace KeycardMenagmentSystem.ViewModel
{
    public class AccessPointsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<AccessPoint> _accessPoints;
        public ObservableCollection<AccessPoint> AccessPoints
        {
            get { return _accessPoints; }
            set
            {
                _accessPoints = value;
                OnPropertyChanged(nameof(AccessPoints));
            }
        }

        public AccessPointsViewModel()
        {
            AccessPoints = new ObservableCollection<AccessPoint>();
            LoadAccessPointsAsync();
        }

        private async void LoadAccessPointsAsync()
        {
            var service = new GetAccessPointsService();
            var accessPointsList = await service.GetAccesPoints();
            foreach (var point in accessPointsList)
            {
                AccessPoints.Add(point);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
