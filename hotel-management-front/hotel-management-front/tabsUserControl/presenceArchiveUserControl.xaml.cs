using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Interaction logic for presenceArchiveUserControl.xaml
    /// </summary>
    public partial class presenceArchiveUserControl : UserControl
    {
        public presenceArchiveUserControl()
        {
            InitializeComponent();
            showArchiveEmployeeList();

        }

        SqlConnection con = new SqlConnection(classes.GlobalVariable.databasePath);

        //function to fill the employee list
        public void showArchiveEmployeeList()
        {
            classes.presence presenceObj = new classes.presence();
            DataTable data = presenceObj.showPresenceList();
            
            PresenceListGrid.ItemsSource = data.DefaultView;
            //((DataGridTextColumn)PresenceListGrid.Columns[0]).Binding = new Binding("date");
            //((DataGridTextColumn)PresenceListGrid.Columns[1]).Binding = new Binding("name");
            //((DataGridTextColumn)PresenceListGrid.Columns[3]).Binding = new Binding("lname");
            //((DataGridTextColumn)PresenceListGrid.Columns[4]).Binding = new Binding("start_hour");
            //((DataGridTextColumn)PresenceListGrid.Columns[5]).Binding = new Binding("end_hour");


            con.Close();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            //classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            //classes.employee employeeObj = new classes.employee();
            //employeeObj.deleteEmployee(int.Parse(classes.GlobalVariable.dataRowView[0].ToString()));

            ////update dataGrid after deletion            
            //showArchiveEmployeeList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
