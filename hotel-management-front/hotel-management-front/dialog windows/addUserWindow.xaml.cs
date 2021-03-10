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
using System.Windows.Shapes;

namespace hotel_management_front.dialog_windows
{
    /// <summary>
    /// Interaction logic for addUserWindow.xaml
    /// </summary>
    public partial class addUserWindow : Window
    {
        public addUserWindow()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameField.Text;
            string pass = passField.Password;

            classes.user userObj = new classes.user(username, pass);
            string result = userObj.addUser();
            MessageBox.Show(result);
        }
    }
}
