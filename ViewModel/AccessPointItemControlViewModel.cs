using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeycardMenagmentSystem.Model;

namespace KeycardMenagmentSystem.ViewModel
{
    internal class AccessPointItemControlViewModel
    {
        public List<AccessPoint> AccessPoints { get; set; } = new List<AccessPoint>();
        public string StatusMessage { get; set; }

        private readonly ObservableCollection<AccessPoint> _productViewModels;
        public IEnumerable<AccessPoint> ProductViewModels => _productViewModels;

        public AccessPointItemControlViewModel()
        {
            
        }
    }
}
