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
    /// Logique d'interaction pour clientUserControl1.xaml
    /// </summary>
    public partial class clientUserControl1 : UserControl
    {
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

            employeeListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)employeeListGrid.Columns[0]).Binding = new Binding("name");
            ((DataGridTextColumn)employeeListGrid.Columns[1]).Binding = new Binding("lname");
            ((DataGridTextColumn)employeeListGrid.Columns[2]).Binding = new Binding("sex");
            ((DataGridTextColumn)employeeListGrid.Columns[3]).Binding = new Binding("birth_date");
            ((DataGridTextColumn)employeeListGrid.Columns[4]).Binding = new Binding("city");
            ((DataGridTextColumn)employeeListGrid.Columns[5]).Binding = new Binding("country");
            ((DataGridTextColumn)employeeListGrid.Columns[6]).Binding = new Binding("phone");
            ((DataGridTextColumn)employeeListGrid.Columns[7]).Binding = new Binding("status");
            ((DataGridTextColumn)employeeListGrid.Columns[8]).Binding = new Binding("CIN");
            ((DataGridTextColumn)employeeListGrid.Columns[9]).Binding = new Binding("arrival_date");
            ((DataGridTextColumn)employeeListGrid.Columns[10]).Binding = new Binding("departure_date");

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

       
    }
}
