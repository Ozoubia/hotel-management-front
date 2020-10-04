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
    /// Interaction logic for PersonnelUserControl.xaml
    /// </summary>
    public partial class PersonnelUserControl : UserControl
    {
        public PersonnelUserControl()
        {
            InitializeComponent();
        }

        private void employes_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Reservation",
            };

            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            employesUserControl UC1 = new employesUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        private void présence_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Présence",
            };

            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            présenceUserControl1 UC1 = new présenceUserControl1();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }

        
    }

