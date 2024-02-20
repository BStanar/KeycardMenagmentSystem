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
        }
    }
}
