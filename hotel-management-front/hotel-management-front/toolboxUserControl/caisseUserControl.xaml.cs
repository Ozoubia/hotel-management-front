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

        

        
        private void bonqueBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Bonque",
            };
            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            bonqueUserControl UC1 = new bonqueUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        private void caissePersonnelBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Caisse Personnel",
            };

            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            caissePersonnelUserControl UC1 = new caissePersonnelUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        private void caissePrincipaleBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Caisse Principale",
            };

            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            caissePrincipaleUserControl UC1 = new caissePrincipaleUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }
}
