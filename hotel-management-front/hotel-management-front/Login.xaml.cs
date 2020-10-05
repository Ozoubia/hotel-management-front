using System.Windows;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

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
            }
            else
            {
                MessageBox.Show("Username or password incorrect");
            }

        }
    }
}
