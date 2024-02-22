using KeycardManagementSystem.Model;
using KeycardMenagmentSystem.View;
using KeycardMenagmentSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeycardMenagmentSystem.Model;


namespace KeycardMenagmentSystem.ViewModel
{
    internal class LogsViewModel
    {
        private readonly ObservableCollection<AccessLog> _accessLog;
        public IEnumerable<AccessLog> AccessLogs => _accessLog;

        private readonly IGetAccessLogs _getAccessLogsService;

        public LogsViewModel(IGetAccessLogs getAccessLogsService)
        {
            _getAccessLogsService = getAccessLogsService;
            _accessLog = new ObservableCollection<AccessLog>();

            LoadAccessLogs();
        }
        public LogsViewModel(IGetAccessLogs getAccessLogsService,Users user)
        {
            _getAccessLogsService = getAccessLogsService;
            _accessLog = new ObservableCollection<AccessLog>();

            LoadAccessLogsOfOneUser(user);
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
    }
}
