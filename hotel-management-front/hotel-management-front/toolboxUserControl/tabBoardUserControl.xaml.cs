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
    /// Interaction logic for tabBoardUserControl.xaml
    /// </summary>
    public partial class tabBoardUserControl : UserControl
    {
        
        public tabBoardUserControl()
        {
            InitializeComponent();
        }

        private void planingBtn_Click(object sender, RoutedEventArgs e)
        {
                Grid tabGrid = new Grid();

                TabItem newTabItem = new TabItem
                {
                    Header = "Planing",
                };

                GlobalVariable.tbControl.Items.Add(newTabItem);
                newTabItem.Content = tabGrid;
                tabGrid.Children.Clear();
                planiningTabUserControl UC1 = new planiningTabUserControl();
                tabGrid.Children.Add(UC1);
                newTabItem.IsSelected = true;
  
        }

        private void statBtn_Click(object sender, RoutedEventArgs e)
        {   
            
                Grid tabGrid = new Grid();

                TabItem newTabItem = new TabItem
                {
                    Header = "Statistiques",
                };


                GlobalVariable.tbControl.Items.Add(newTabItem);
                newTabItem.Content = tabGrid;
                tabGrid.Children.Clear();
                StatTabUserControl UC1 = new StatTabUserControl();
                tabGrid.Children.Add(UC1);
                newTabItem.IsSelected = true;

        }
    }
}
