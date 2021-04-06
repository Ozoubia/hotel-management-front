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
using hotel_management_front.dialog_windows;
using System.Windows.Threading;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour utilisateurUserControl.xaml
    /// </summary>
    public partial class utilisateurUserControl : UserControl
    {

        // timer used for refresh
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public utilisateurUserControl()
        {
            InitializeComponent();
            showUseriList();
        }

        //function to fill the User list
        public void showUseriList()
        {
            classes.user userObj = new classes.user();
            DataTable data = userObj.showAllUsers();

            userGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)userGrid.Columns[0]).Binding = new Binding("username");
            ((DataGridTextColumn)userGrid.Columns[1]).Binding = new Binding("isActive");

        }

        // add user click event
        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            new addUserWindow().Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            // opening the modify page
            new modifyUserWindow().Show();
        }

        private void permissionBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string user = classes.GlobalVariable.dataRowView[1].ToString();

            // empty grid
            rightGrid.Children.Clear();

            // getting the role of the user
            classes.user userObj = new classes.user();
            string userRole = userObj.getUserRoleByName(user);
            // getting the id of the user role (exp admin, his id is 1)
            classes.role roleObj = new classes.role();
            DataTable data = roleObj.getRoleIdByName(userRole);
            string roleId = data.Rows[0]["id_role"].ToString();

            //new instance
            rightGrid.Children.Add(new permissionsUserControl(roleId, userRole));


        }

        #region timer grid refresh part
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            this.dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            showUseriList();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // stopping the timer
            this.dispatcherTimer.Stop();
        }
        #endregion


    }
}
