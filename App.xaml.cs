using KeycardMenagmentSystem.Store;
using KeycardMenagmentSystem.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace KeycardMenagmentSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigateStore navigationStore = new NavigateStore();
            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
