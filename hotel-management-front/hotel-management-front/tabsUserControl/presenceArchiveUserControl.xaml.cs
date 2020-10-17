using hotel_management_front.dialog_windows;
using System;
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

        

        //function to fill the employee list
        public void showArchiveEmployeeList()
        {
            classes.presence presenceObj = new classes.presence();
            DataTable data = presenceObj.showPresenceList();

            PresenceArchiveGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)PresenceArchiveGrid.Columns[0]).Binding = new Binding("date");
            ((DataGridTextColumn)PresenceArchiveGrid.Columns[1]).Binding = new Binding("name");
            ((DataGridTextColumn)PresenceArchiveGrid.Columns[2]).Binding = new Binding("lname");
            ((DataGridTextColumn)PresenceArchiveGrid.Columns[3]).Binding = new Binding("start_hour");
            ((DataGridTextColumn)PresenceArchiveGrid.Columns[4]).Binding = new Binding("end_hour");
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            DateTime date = DateTime.Parse(classes.GlobalVariable.dataRowView[0].ToString());
            string name = classes.GlobalVariable.dataRowView[1].ToString();
            string lname = classes.GlobalVariable.dataRowView[2].ToString();

            classes.presence presenceObj = new classes.presence();
            presenceObj.deletePresence(date, name, lname);


            //update dataGrid after deletion
            showArchiveEmployeeList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;


            // opening the modify page
            new modifyArchiveWindow().Show();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
