﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace KeycardMenagmentSystem.View
{
    /// <summary>
    /// Interaction logic for AssignUserToKeycard.xaml
    /// </summary>
    public partial class AssignUserToKeycard : UserControl
    {
        public AssignUserToKeycard()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Add your logic here for what should happen when the button is clicked
            MessageBox.Show("Button clicked!");
        }
    }
}
