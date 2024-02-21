using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeycardMenagmentSystem.Services;
using System.Collections.ObjectModel;

namespace KeycardMenagmentSystem.ViewModel
{
    internal class AccessPointsViewModel
    {
        private readonly ObservableCollection<AccessPoint> _accessPoints;
        public IEnumerable<AccessPoint> AccessPoints => _accessPoints;

        private readonly IGetAccessPointService _getAccessPointService;

        public AccessPointsViewModel(IGetAccessPointService getAccessPointService)
        {
            _getAccessPointService = getAccessPointService;
            _accessPoints = new ObservableCollection<AccessPoint>();

            LoadAccessPoints();
        }

        private async void LoadAccessPoints()
        {

            var accessPoints = await _getAccessPointService.GetAccesPoints();
            _accessPoints.Clear();
            foreach (var accessPoint in accessPoints)
            {
                _accessPoints.Add(accessPoint);
            }

        }
    }
}

