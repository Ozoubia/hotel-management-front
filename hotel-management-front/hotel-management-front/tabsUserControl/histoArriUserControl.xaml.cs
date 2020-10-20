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
    /// Interaction logic for histoArriUserControl.xaml
    /// </summary>
    public partial class histoArriUserControl : UserControl
    {
        public histoArriUserControl()
        {
            InitializeComponent();
            showHistoriqueList();
        }


        //function to fill the historique list
        public void showHistoriqueList()
        {
            classes.histoArrivee histoObj = new classes.histoArrivee();
            DataTable data = histoObj.showHistoArriveeList();

            historiqueListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)historiqueListGrid.Columns[0]).Binding = new Binding("name");
            ((DataGridTextColumn)historiqueListGrid.Columns[1]).Binding = new Binding("lname");
            ((DataGridTextColumn)historiqueListGrid.Columns[2]).Binding = new Binding("rname");
            ((DataGridTextColumn)historiqueListGrid.Columns[3]).Binding = new Binding("type");
            ((DataGridTextColumn)historiqueListGrid.Columns[4]).Binding = new Binding("check_in");
            ((DataGridTextColumn)historiqueListGrid.Columns[5]).Binding = new Binding("check_out");
            ((DataGridTextColumn)historiqueListGrid.Columns[6]).Binding = new Binding("total_amount");
            ((DataGridTextColumn)historiqueListGrid.Columns[7]).Binding = new Binding("payement_status");


        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
