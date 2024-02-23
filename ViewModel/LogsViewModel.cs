
using KeycardMenagmentSystem.View;
using KeycardMenagmentSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.ViewModel;
using KeycardMenagmentSystem.Commands;
using System.Windows.Input;


namespace KeycardMenagmentSystem.ViewModel
{
    internal class LogsViewModel
    {
        private readonly ObservableCollection<AccessLog> _allAccessLogs;

        private readonly ObservableCollection<AccessLog> _accessLog;
        public IEnumerable<AccessLog> AccessLogs => _accessLog;

        private readonly IGetAccessLogs _getAccessLogsService;
        public ObservableCollection<AccessPoint> AccessPoints { get; private set; }

        private readonly GetAccessPointsService _accessPointsService;

        public LogsViewModel(IGetAccessLogs getAccessLogsService)
        {
            _getAccessLogsService = getAccessLogsService;
            _accessLog = new ObservableCollection<AccessLog>();
            LoadAccessLogs();
            AccessPoints = new ObservableCollection<AccessPoint>();
            _accessPointsService = new GetAccessPointsService();
            LoadAccessPoints();

            // Initialize commands here
            FilterLogsCommand = new RelayCommand(_ => FilterLogs());
            SelectAccessPointCommand = new RelayCommand(parameter => SelectAccessPoint(parameter));

        }

        public LogsViewModel(IGetAccessLogs getAccessLogsService, Users user)
        {
            _getAccessLogsService = getAccessLogsService;
            _accessLog = new ObservableCollection<AccessLog>();

            LoadAccessLogsOfOneUser(user);
        }

        public LogsViewModel(AccessPointsViewModel accessPointsViewModel)
        {
            accessPointsViewModel = new AccessPointsViewModel();
        }

        private async void LoadAccessPoints()
        {
            var accessPoints = await _accessPointsService.GetAccesPoints();
            foreach (var accessPoint in accessPoints)
            {
                AccessPoints.Add(accessPoint);
            }
        }

        private async void LoadAccessLogsOfOneUser(Users user)
        {

            var accessLogs = await _getAccessLogsService.GetAccesLogs(user.ID);
            _accessLog.Clear();
            foreach (var accesslog in accessLogs)
            {
                _accessLog.Add(accesslog);
            }

        }

        private async void LoadAccessLogs()
        {

            var accessLogs = await _getAccessLogsService.GetAccesLogs();
            _accessLog.Clear();
            foreach (var accesslog in accessLogs)
            {
                _accessLog.Add(accesslog);
            }
        }
        private async void LoadAccessLogs22()
        {

            var accessLogs = await _getAccessLogsService.GetAccesLogs();
            _accessLog.Clear();
            foreach (var accesslog in accessLogs)
            {
                _accessLog.Add(accesslog);
            }
            
        }


        public string SelectedAccessPointName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Attempt { get; set; } // Assuming this is a string, adjust based on actual data type


        public ICommand FilterLogsCommand { get; private set; }

        private void FilterLogs()
        {
            // Example filtering logic (adjust based on your needs and data structure)
            var filteredLogs = _accessLog.Where(log =>
                (string.IsNullOrEmpty(SelectedAccessPointName) || log.AccessPointName == SelectedAccessPointName) &&
                (!FromDate.HasValue || log.EventDate >= FromDate.Value) &&
                (!ToDate.HasValue || log.EventDate <= ToDate.Value) &&
                (string.IsNullOrEmpty(FirstName) || log.Firstname.Contains(FirstName)) &&
                (string.IsNullOrEmpty(LastName) || log.Lastname.Contains(LastName))
            // Handle 'Attempt' filtering based on your data structure and requirements
            ).ToList();

            // Update your ObservableCollection or bindable list with the filtered results
            // This example clears and re-adds filtered items, which is not the most efficient method for large datasets.
            
            foreach (var log in filteredLogs)
            {
                _accessLog.Add(log);
            }
        }
        public ICommand SelectAccessPointCommand { get; private set; }

        private void SelectAccessPoint(object parameter)
        {
            SelectedAccessPointName = parameter as string;
            // Optionally, automatically trigger filtering upon selection
            FilterLogs();
            
        }

        


    }
}
