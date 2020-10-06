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
using System.Data.SqlClient;
using System.Data;
using hotel_management_front.classes;

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
            showEmployeeList();
        }
        SqlConnection con = new SqlConnection(classes.GlobalVariable.databasePath);

        public void showEmployeeList()
        {
            classes.presence presenceObj = new classes.presence();
            DataTable data = presenceObj.showAllEmployees1();

            presenceListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)presenceListGrid.Columns[0]).Binding = new Binding("name");
            ((DataGridTextColumn)presenceListGrid.Columns[1]).Binding = new Binding("lname");
            ((DataGridTextColumn)presenceListGrid.Columns[2]).Binding = new Binding("departement");
           con.Close();
        }
        private void searchBar1_TextChanged(object sender, TextChangedEventArgs e)
        {
            classes.presence pesenceObj = new classes.presence();
            DataTable data = pesenceObj.searchEmployee(searchBar1.Text);
            presenceListGrid.ItemsSource = data.DefaultView;
            con.Close();
        }

        private void ValiderBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
