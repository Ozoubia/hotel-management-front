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

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour présenceUserControl1.xaml
    /// </summary>
    public partial class présenceUserControl1 : UserControl
    {
        public présenceUserControl1()
        {
            InitializeComponent();
            todayDateField.SelectedDate = DateTime.Today;
        }
    }
}
