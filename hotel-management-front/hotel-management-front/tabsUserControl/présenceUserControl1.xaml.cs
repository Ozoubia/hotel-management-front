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
using hotel_management_front.classes;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour présenceUserControl1.xaml
    /// </summary>
    public partial class présenceUserControl1 : UserControl
    {
        public présenceUserControl1()
        {
            

            InitializeComponent();
            todayDateField.SelectedDate = DateTime.Today;
            showEmployeePresenceList();

            TimeSpan startHour;
            TimeSpan endHour;
        }
        SqlConnection con = new SqlConnection(classes.GlobalVariable.databasePath);

        // to fill the data presence grid
        public void showEmployeePresenceList()
        {
            presence presenceObj = new presence();
            DataTable data = presenceObj.showAllEmployees1();

            presenceListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)presenceListGrid.Columns[0]).Binding = new Binding("name");
            ((DataGridTextColumn)presenceListGrid.Columns[1]).Binding = new Binding("lname");
            ((DataGridTextColumn)presenceListGrid.Columns[2]).Binding = new Binding("departement");
           con.Close();
        }
        private void searchBar1_TextChanged(object sender, TextChangedEventArgs e)
        {
            presence pesenceObj = new presence();
            DataTable data = pesenceObj.searchEmployee(searchBar1.Text);
            presenceListGrid.ItemsSource = data.DefaultView;
            con.Close();
        }

        private void ValiderBtn_Click(object sender, RoutedEventArgs e)
        {
            //// saving the index of the row in the datarowview var
            //GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            //// getting fields content
            //string name = GlobalVariable.dataRowView[0].ToString();
            //string lname = GlobalVariable.dataRowView[1].ToString();
            //DateTime date = DateTime.Parse(todayDateField.SelectedDate.Value.Date.ToShortDateString());
            

            //presence presenceObj = new presence(name, lname, date, );

            //string result = presenceObj.addPresence();
            //MessageBox.Show(result);
        }

        
    }
}
