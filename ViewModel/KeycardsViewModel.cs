using KeycardMenagmentSystem.Commands;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeycardMenagmentSystem.ViewModel
{
    public class KeycardsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Keycard> _allAccessLogs;

        private readonly ObservableCollection<Keycard> _accessLog;
        public IEnumerable<Keycard> AccessLogs => _accessLog;

        private readonly IGetKeycardsService _getAccessLogsService;
        public ObservableCollection<Keycard> Keycards { get; private set; }

        public KeycardsViewModel(IGetKeycardsService getAccessLogsService)
        {
            _getAccessLogsService = getAccessLogsService;
            _accessLog = new ObservableCollection<Keycard>();
            LoadAccessLogs();
            Keycards = new ObservableCollection<Keycard>();
        }

        private async void LoadAccessLogs()
        {
            var accessPoints = await _getAccessLogsService.GetAccessLogsService();
            foreach (var accessPoint in accessPoints)
            {
                Keycards.Add(accessPoint);
            }
        }
    }
}
