﻿using KeycardMenagmentSystem.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace KeycardMenagmentSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new LoginViewModel()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
