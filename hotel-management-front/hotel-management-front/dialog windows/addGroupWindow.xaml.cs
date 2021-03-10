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
    /// Interaction logic for addGroupWindow.xaml
    /// </summary>
    public partial class addGroupWindow : Window
    {
        string role;
        public addGroupWindow()
        {
            InitializeComponent();
            showRoleList();
        }

        //function to fill the roles list
        public void showRoleList()
        {
            classes.role roleObj = new classes.role();
            DataTable data = roleObj.showAllRoles();

            groupGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)groupGrid.Columns[0]).Binding = new Binding("description");
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            // getting the clicked role exp: administator, receptionist
            this.role = classes.GlobalVariable.dataRowView[1].ToString();

            // showing the clicked role in the fields and activating the buttons
            EditRoleField.Text = role;
            EditRoleField.IsEnabled = true;
            EditGroupBtn.IsEnabled = true;

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            string role = classes.GlobalVariable.dataRowView[1].ToString();

            classes.role roleObj = new classes.role();
            roleObj.deleteRole(role);
            MessageBox.Show("Groupe supprimee");
            showRoleList();
        }

        private void addGroupeBtn_Click(object sender, RoutedEventArgs e)
        {

                classes.role roleObj = new classes.role(roleField.Text);
                string result = roleObj.addRole();
                MessageBox.Show(result);
                //refresh grid
                showRoleList();
        }

        //
        private void EditGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.role roleObj = new classes.role();

            roleObj.modiftyRole(this.role, EditRoleField.Text);
            MessageBox.Show("Groupe modifiee");
            showRoleList();
            EditRoleField.Text = "";
            EditRoleField.IsEnabled = false;
            EditGroupBtn.IsEnabled = false;

        }

        // 
        private void roleField_GotFocus(object sender, RoutedEventArgs e)
        {
            EditRoleField.Text = "";
            EditRoleField.IsEnabled = false;
            EditGroupBtn.IsEnabled = false;
        }
    }
}
