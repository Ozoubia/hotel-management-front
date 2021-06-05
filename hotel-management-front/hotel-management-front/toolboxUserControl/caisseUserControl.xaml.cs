using hotel_management_front.classes;
using hotel_management_front.tabsUserControl;
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

namespace hotel_management_front.toolboxUserControl
{
    /// <summary>
    /// Logique d'interaction pour caisseUserControl.xaml
    /// </summary>
    public partial class caisseUserControl : UserControl
    {
        public caisseUserControl()
        {
            InitializeComponent();
        }

        private void caisseBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Caisses",
            };
            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            caissesUserControl UC1 = new caissesUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        private void opCaisseBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Operations Caisses",
            };
            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            opCaissesUserControl UC1 = new opCaissesUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        private void inventaireBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Inventaire",
            };
            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            inventaireUserControl UC1 = new inventaireUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }
}
