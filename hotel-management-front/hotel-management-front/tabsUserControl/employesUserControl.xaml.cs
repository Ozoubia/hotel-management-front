using hotel_management_front.dialog_windows;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Threading;
using System;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour employesUserControl.xaml
    /// </summary>
    public partial class employesUserControl : UserControl
    {

        // timer used for refresh
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public employesUserControl()
        {
            InitializeComponent();
            showEmployeeList();
        }

        //function to fill the employee list
        public void showEmployeeList()
        {
            classes.employee employeeObj = new classes.employee();
            DataTable data = employeeObj.showAllEmployees();

            employeeListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)employeeListGrid.Columns[0]).Binding = new Binding("id_employee");
            ((DataGridTextColumn)employeeListGrid.Columns[1]).Binding = new Binding("name");
            ((DataGridTextColumn)employeeListGrid.Columns[2]).Binding = new Binding("lname");
            ((DataGridTextColumn)employeeListGrid.Columns[3]).Binding = new Binding("sex");
            ((DataGridTextColumn)employeeListGrid.Columns[4]).Binding = new Binding("birth_date");
            ((DataGridTextColumn)employeeListGrid.Columns[5]).Binding = new Binding("city");
            ((DataGridTextColumn)employeeListGrid.Columns[6]).Binding = new Binding("country");
            ((DataGridTextColumn)employeeListGrid.Columns[7]).Binding = new Binding("telephone");
            ((DataGridTextColumn)employeeListGrid.Columns[8]).Binding = new Binding("CIN");
            ((DataGridTextColumn)employeeListGrid.Columns[9]).Binding = new Binding("status");
            ((DataGridTextColumn)employeeListGrid.Columns[10]).Binding = new Binding("nbr_kids");
            ((DataGridTextColumn)employeeListGrid.Columns[11]).Binding = new Binding("CNSS");
            ((DataGridTextColumn)employeeListGrid.Columns[12]).Binding = new Binding("departement");
            ((DataGridTextColumn)employeeListGrid.Columns[13]).Binding = new Binding("job_title");
            ((DataGridTextColumn)employeeListGrid.Columns[14]).Binding = new Binding("base_salary");
            ((DataGridTextColumn)employeeListGrid.Columns[15]).Binding = new Binding("starting_date");
            ((DataGridTextColumn)employeeListGrid.Columns[15]).Binding = new Binding("ending_date");

        }

        private void AjouterEmployee_Click(object sender, RoutedEventArgs e)
        {
            new addEmployeeWindow().Show();
        }

        //delete btn event
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            classes.employee employeeObj = new classes.employee();
            employeeObj.deleteEmployee(int.Parse(classes.GlobalVariable.dataRowView[0].ToString()));

            //update dataGrid after deletion            
            showEmployeeList();
            // add action to history log
            string par = "supprimer employée";
            string nom = classes.GlobalVariable.username;
            DateTime dateAction = DateTime.Today;
            classes.client clientObj1 = new classes.client();
            clientObj1.ajouterHistorique(nom, par, dateAction);
        }

        // edit btn event
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            // opening the modify page
            new modifyEmployeeWindow().Show();
        }

        // used for filtering
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            classes.employee employeeObj = new classes.employee();
            DataTable data = employeeObj.searchEmployee(searchBar.Text);
            employeeListGrid.ItemsSource = data.DefaultView;
            
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
            showEmployeeList();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // stopping the timer
            this.dispatcherTimer.Stop();
        }
        #endregion
    }
}
