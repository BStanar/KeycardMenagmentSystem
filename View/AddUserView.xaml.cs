﻿using KeycardMenagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace KeycardMenagmentSystem.View
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : UserControl
    {
        public AddUserView()
        {
            InitializeComponent();
            DataContext = new AddUserViewModel();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ManagerView keycardsView = new ManagerView();
            this.Content = keycardsView;
        }
    }
}


