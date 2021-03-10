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

            user userOjb = new user(user, pass);
            bool result = userOjb.login();

            //if successful do this 
            if (result)
            {
                // showing the main window
                GlobalVariable.username = user;
                new DashBoard(GlobalVariable.username).Show();
                this.Close();

                //login historique
                string par = "Login";
                string nom = GlobalVariable.username;
                DateTime dateAction = DateTime.Today;
                classes.client clientObj = new classes.client();
                clientObj.ajouterHistorique(nom, par, dateAction);

                //getting the user permission and storing them in the global variable permission list
                GlobalVariable.permissionList = userOjb.GetUserPermissions();

            }
            else
            {
                MessageBox.Show("Username or password incorrect");
            }
            
        }
        
        
    }
}
