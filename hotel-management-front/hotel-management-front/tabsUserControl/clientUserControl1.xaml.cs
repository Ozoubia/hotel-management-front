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
    /// Logique d'interaction pour clientUserControl1.xaml
    /// </summary>
    public partial class clientUserControl1 : UserControl
    {

        // timer used for refresh
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public clientUserControl1()
        {
            InitializeComponent();
            showClientList();
        }

        //function to fill the employee list
        public void showClientList()
        {
            classes.client clientObj = new classes.client();
            DataTable data = clientObj.showAllClients();

            ClientListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)ClientListGrid.Columns[0]).Binding = new Binding("name");
            ((DataGridTextColumn)ClientListGrid.Columns[1]).Binding = new Binding("lname");
            ((DataGridTextColumn)ClientListGrid.Columns[2]).Binding = new Binding("sex");
            ((DataGridTextColumn)ClientListGrid.Columns[3]).Binding = new Binding("birth_date");
            ((DataGridTextColumn)ClientListGrid.Columns[4]).Binding = new Binding("city");
            ((DataGridTextColumn)ClientListGrid.Columns[5]).Binding = new Binding("country");
            ((DataGridTextColumn)ClientListGrid.Columns[6]).Binding = new Binding("phone");
            ((DataGridTextColumn)ClientListGrid.Columns[7]).Binding = new Binding("status");
            ((DataGridTextColumn)ClientListGrid.Columns[8]).Binding = new Binding("CIN");
            ((DataGridTextColumn)ClientListGrid.Columns[9]).Binding = new Binding("arrival_date");
            ((DataGridTextColumn)ClientListGrid.Columns[10]).Binding = new Binding("departure_date");

        }

        private void addClientBtn_Click(object sender, RoutedEventArgs e)
        {
            new addClientWindow().Show();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
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
            showClientList();
        }
        
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // stopping the timer
            this.dispatcherTimer.Stop();
        }
        #endregion
    }
}
