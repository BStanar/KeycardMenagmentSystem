﻿using KeycardMenagmentSystem.CustomControlls;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeycardMenagmentSystem.View
{
    /// <summary>
    /// Interaction logic for AccesPoint.xaml
    /// </summary>
    public partial class AccesPoint : UserControl
    {
        public AccesPoint()
        {
            InitializeComponent();
            this.DataContext = new AccessPointsViewModel();


        }


    }
}
