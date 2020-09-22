using hotel_management_front.toolboxUserControl;
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

namespace hotel_management_front
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new tabBoardUserControl());
        }

        #region menu button
        private void dashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new tabBoardUserControl());
        }

        private void hotelBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new hotelUserControl());
        }

        private void stockBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new StockUserControl());
        }

        private void personnelBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new PersonnelUserControl());
        }

        private void parametresBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new parametresUserControl());
        }

        #endregion

        #region tab settup
        private void tabControlDragable_Loaded(object sender, RoutedEventArgs e)
        {
            //GlobalVariables.tbControl = (sender as TabControl);
            hotel_management_front.classes.GlobalVariable.tbControl = (sender as TabControl);
        }
        #endregion
    }
}
