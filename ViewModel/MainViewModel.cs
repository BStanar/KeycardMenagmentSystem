using KeycardMenagmentSystem.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public readonly NavigateStore _navigateStore;


        public MainViewModel(NavigateStore navigateStore)
        {
            _navigateStore = navigateStore;
            _navigateStore.CurrentViewModelChange += OnCurrentViewModelChanged;
        }
        public ViewModelBase CurrentViewModel => _navigateStore.CurrentViewModel;
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


    }
}
