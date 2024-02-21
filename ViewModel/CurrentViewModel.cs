using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.ViewModel
{
    public class CurrentViewModel
    {
        private static readonly CurrentViewModel _instance = new CurrentViewModel();

        public static CurrentViewModel Instance => _instance;

        private ViewModelBase _currentVM;

        public ViewModelBase CurrentVM
        {
            get => _currentVM;
            set
            {
                _currentVM = value;
                // Notify any listeners that the current view model has changed
                // You may use an event or a similar mechanism for this purpose
            }
        }
    }
}
