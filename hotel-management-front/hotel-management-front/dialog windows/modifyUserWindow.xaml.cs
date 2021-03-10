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
using System.Windows.Shapes;

namespace hotel_management_front.dialog_windows
{
    /// <summary>
    /// Interaction logic for modifyUserWindow.xaml
    /// </summary>
    public partial class modifyUserWindow : Window
    {
        public bool isActive;
        

        public modifyUserWindow()
        {
            InitializeComponent();
            getPreviousInfo();
            
        }

        // getting the previous user data and showing it in the fields
        private void getPreviousInfo()
        {
            // employee object
            classes.user userObj = new classes.user();

            // getting the index of the row 
            int rowIndex = int.Parse(classes.GlobalVariable.dataRowView[0].ToString());

            // getting the employee information of the clicked index
            DataTable result = userObj.getUser(rowIndex);

            // assigning the variable to the fields
            usernameField.Text = result.Rows[0]["username"].ToString();
            passField.Text = result.Rows[0]["password"].ToString();
            activateAccountCheckbox.IsChecked = bool.Parse(result.Rows[0]["isActive"].ToString());

            //setting the account satte var
            this.isActive = bool.Parse(result.Rows[0]["isActive"].ToString());

        }
        
        //modify user
        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            // getting the index of the row 
            int rowIndex = int.Parse(classes.GlobalVariable.dataRowView[0].ToString());

            // var fields assignings
            string username = usernameField.Text;
            string pass = passField.Text;
            bool checkbox = (bool)activateAccountCheckbox.IsChecked;

            classes.user userObj = new classes.user(username, pass);

            userObj.modiftyUser(rowIndex, isActive);

            MessageBox.Show("Utilisateur modifiee");
        }

        
        //delete user
        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameField.Text;

            classes.user userObj = new classes.user();
            userObj.deleteUser(username);
            this.Close();
            MessageBox.Show("Utilisateur supprimee");
            
        }

        #region activate account checkbox 
        private void activateAccountCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            this.isActive = true;
        }

        private void activateAccountCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.isActive = false;

        }
        #endregion
    }
}
