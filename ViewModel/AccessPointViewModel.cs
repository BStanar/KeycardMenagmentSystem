using KeycardMenagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.ViewModel
{
    public class AccessPointViewModel : ViewModelBase
    {
        private readonly AccessPoint? _accessPoint;

        public string AccessPointID => _accessPoint.AccesPointID.ToString();
        public string Name => _accessPoint.Name;

        public AccessPointViewModel(AccessPoint accessPoint)
        {
            _accessPoint = accessPoint;
        }
    }
}
