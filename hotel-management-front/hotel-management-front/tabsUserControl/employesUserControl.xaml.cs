﻿using hotel_management_front.dialog_windows;
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

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour employesUserControl.xaml
    /// </summary>
    public partial class employesUserControl : UserControl
    {
        public employesUserControl()
        {
            InitializeComponent();
        }

        private void AjouterEmployee_Click(object sender, RoutedEventArgs e)
        {
            new addEmployeeWindow().Show();
        }
    }
}
