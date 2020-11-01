using hotel_management_front.dialog_windows;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour chambreUserControl.xaml
    /// </summary>
    public partial class chambreUserControl : UserControl
    {
        public chambreUserControl()
        {
            InitializeComponent();
            showRoomList();
        }

        //function to fill the employee list
        public void showRoomList()
        {
            classes.room roomObj = new classes.room();
            DataTable data = roomObj.showAllRooms();

            roomListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)roomListGrid.Columns[0]).Binding = new Binding("name");
            ((DataGridTextColumn)roomListGrid.Columns[1]).Binding = new Binding("type");
            ((DataGridTextColumn)roomListGrid.Columns[2]).Binding = new Binding("base_price");
            ((DataGridTextColumn)roomListGrid.Columns[3]).Binding = new Binding("status");
            ((DataGridTextColumn)roomListGrid.Columns[4]).Binding = new Binding("works");

        }

        private void addRoom_Click(object sender, RoutedEventArgs e)
        {
            new addRoomWindow().Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
