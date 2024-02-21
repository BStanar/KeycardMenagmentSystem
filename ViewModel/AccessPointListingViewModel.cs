using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeycardMenagmentSystem.ViewModel
{
    public class AccessPointListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AccessPointViewModel> _accessPoints;
        public IEnumerable<AccessPointViewModel> AccessPoints => _accessPoints;


        public AccessPointListingViewModel()
        {
            _accessPoints = new ObservableCollection<AccessPointViewModel>();

            _accessPoints.Add(new AccessPointViewModel(new Model.AccessPoint(1, "ime1")));
            _accessPoints.Add(new AccessPointViewModel(new Model.AccessPoint(2, "ime2")));
            _accessPoints.Add(new AccessPointViewModel(new Model.AccessPoint(4, "ime3")));
            _accessPoints.Add(new AccessPointViewModel(new Model.AccessPoint(5, "ime4")));
            _accessPoints.Add(new AccessPointViewModel(new Model.AccessPoint(6, "ime5")));
        }
    }
}
