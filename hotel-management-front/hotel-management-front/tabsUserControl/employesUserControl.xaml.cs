using hotel_management_front.dialog_windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour employesUserControl.xaml
    /// </summary>
    public partial class employesUserControl : UserControl
    {
        public employesUserControl()
        {
            InitializeComponent();
            showEmployeeList();
        }

        SqlConnection con = new SqlConnection(classes.GlobalVariable.databasePath);


        //function to fill the employee list
        public void showEmployeeList()
        {
            string query = "SELECT * FROM employee";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            employeeListGrid.ItemsSource = data.DefaultView;
            con.Close();
        }

        private void AjouterEmployee_Click(object sender, RoutedEventArgs e)
        {
            new addEmployeeWindow().Show();
        }

        //delete btn event
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            string query = "DELETE FROM employee WHERE id_employee = '" + classes.GlobalVariable.dataRowView[0] + "'";
            SqlCommand cmd2 = new SqlCommand(query, con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            //update dataGrid after deletion            
            showEmployeeList();
        }

        // edit btn event
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            
            // opening the modify page
            new modifyEmployeeWindow().Show();
        }

        // used for filtering
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = "SELECT * FROM employee WHERE name Like '%" + searchBar.Text + "%' OR lname LIKE'%" + searchBar.Text + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            employeeListGrid.ItemsSource = data.DefaultView;
            con.Close();
        }
    }
}
