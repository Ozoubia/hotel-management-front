using hotel_management_front.dialog_windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Interaction logic for permissionsUserControl.xaml
    /// </summary>
    public partial class permissionsUserControl : UserControl
    {
        private string selectedRole;
        private int roleID;
        public permissionsUserControl(string roleID, string selectedRole)
        {
            InitializeComponent();
            this.selectedRole = selectedRole;
            this.roleID = int.Parse(roleID);
            fillRoleCombo();
            //fillPermissions();
            generatePerChecks();
        }

        //generating the permissions checkboxes.
        private void generatePerChecks()
        {
            classes.user userObj = new classes.user();            
            DataTable data = userObj.getAllPermissions();  // all permission in the table
            List<string> rolepermissions = userObj.GetUserPermissionsByRole(this.selectedRole);  // role permissions
            int perCount = data.Rows.Count;
            
            // looping through all the permission
            for (int i = 0; i < perCount; i++)
            {
                string permission = data.Rows[i]["description"].ToString();
                // generating the checkboxes
                CheckBox check = new CheckBox();
                check.Content = permission;
                check.Name = "check" + i.ToString();
                permissionList.Children.Add(check);

                // if the checkbox exist in the list, (meaning that it is checked)
                if (rolepermissions.Contains(permission) )
                {
                    check.IsChecked = true;
                }
                

                //checked and unchecked events
                check.Checked += new RoutedEventHandler(permissionChecked);
                check.Unchecked += new RoutedEventHandler(permissionUnchecked);
            }

            
        }

        // unchecked
        private void permissionUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            string permissionName = check.Content.ToString();

            //getting permission Id from name
            classes.user userObj = new classes.user();
            int perID = userObj.getPermissionIDbyName(permissionName);

            //deleting permission from the role
            classes.role roleObj = new classes.role();
            roleObj.takeOffRolePermission(this.roleID, perID);
        }

        //checked
        private void permissionChecked(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            string permissionName = check.Content.ToString();

            //getting permission Id from name
            classes.user userObj = new classes.user();
            int perID = userObj.getPermissionIDbyName(permissionName);

            //giving permission to the role
            //deleting permission from the role
            classes.role roleObj = new classes.role();
            roleObj.giveRolePermission(this.roleID, perID);
        }

        private void fillRoleCombo()
        {
            classes.role roleObj = new classes.role();
            DataTable data = roleObj.showAllRoles();
            int data_length = data.Rows.Count;

            // looping through the client list
            for (int i = 0; i < data_length; i++)
            {
                string type = data.Rows[i]["description"].ToString();
                groupeCombo.Items.Add(type);
            }

            // setting the user role as selected index
            groupeCombo.SelectedIndex = groupeCombo.Items.IndexOf(this.selectedRole);
        }

        private void addGroupeBtn_Click(object sender, RoutedEventArgs e)
        {
            new addGroupWindow().Show();
        }
    }
}
