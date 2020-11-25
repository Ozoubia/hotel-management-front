using System.Windows;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using hotel_management_front.classes;
using System;
using System.Data;

namespace hotel_management_front
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public MainWindow()
        {
            InitializeComponent();
            createRoomImg();
        }

        // if folders doesn't exist create it 
        public void createRoomImg()
        {
            bool photo_exists = Directory.Exists("images");

            if (!photo_exists)
                Directory.CreateDirectory("images");
        }

        //login button click event 
        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            string user = usernameField.Text;
            string pass = passwordField.Password;

            classes.user userOjb = new classes.user(user, pass);
            bool result = userOjb.login();

            //if successful do this 
            if (result)
            {
                new DashBoard().Show();
                this.Close();
                classes.GlobalVariable.username = user;
                //historique
                string par = "Login";
               string nom = classes.GlobalVariable.username;
                DateTime dateAction = DateTime.Today;
                classes.client clientObj = new classes.client();
                clientObj.ajouterHistorique(nom, par, dateAction);
              
            }
            else
            {
                MessageBox.Show("Username or password incorrect");
            }
            
        }
        
        
    }
}
