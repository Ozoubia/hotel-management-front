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
using System.Windows.Threading;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour chambreUserControl.xaml
    /// </summary>
    public partial class chambreUserControl : UserControl
    {
        // timer used for refresh
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

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
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string designation = classes.GlobalVariable.dataRowView[1].ToString();
            
             classes.room roomObj = new classes.room();
            DataTable data = new DataTable();

          data =  roomObj.showRoomIDByName(designation);
            
          
            int id = int.Parse(data.Rows[0]["id_room"].ToString());
            new modiftyRoomWindow(id).Show();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        #region timer grid refresh part

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            this.dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            showRoomList();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // stopping the timer
            this.dispatcherTimer.Stop();
        }
        #endregion

    }
}
