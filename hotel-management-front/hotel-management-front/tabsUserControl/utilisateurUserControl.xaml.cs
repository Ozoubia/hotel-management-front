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

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour utilisateurUserControl.xaml
    /// </summary>
    public partial class utilisateurUserControl : UserControl
    {
        public utilisateurUserControl()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(classes.GlobalVariable.databasePath);


        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            //checking if a user exists 
            string user = usernameField.Text;
            string pass = passwordField.Password;
            string query = "SELECT * FROM users WHERE username=@name AND password=@pass";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", user);
            ada.SelectCommand.Parameters.AddWithValue("@pass", pass);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                MessageBox.Show("User already exists");
            }
            else
            {
                string query1= "INSERT INTO users (username, password, isActive) VALUES (@name, @pass, @state)";
                SqlCommand com = new SqlCommand(query1, con);
                com.Parameters.AddWithValue("@name", user);
                com.Parameters.AddWithValue("@pass", pass);
                com.Parameters.AddWithValue("@state", true);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("user added");
            }
        }

        
    }
}
