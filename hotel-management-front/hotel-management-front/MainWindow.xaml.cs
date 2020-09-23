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

namespace hotel_management_front
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-7JO0IDO\\SQLEXPRESS;Initial Catalog=test2;Integrated Security=True");


        private void login(object sender, RoutedEventArgs e)
        {
            
            string user = usernameField.Text;
            string pass = passwordField.Password;
            string query = "SELECT * FROM userTable WHERE username=@name AND password=@pass";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", user);
            ada.SelectCommand.Parameters.AddWithValue("@pass", pass);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                new DashBoard().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password incorrect");
            }

        }
    }
}
