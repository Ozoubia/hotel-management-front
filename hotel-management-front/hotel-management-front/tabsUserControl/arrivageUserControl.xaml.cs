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
    /// Interaction logic for arrivageUserControl.xaml
    /// </summary>
    public partial class arrivageUserControl : UserControl
    {
        public arrivageUserControl()
        {
            InitializeComponent();
            showArrivageList();


        }
        public void showArrivageList()
        {
            classes.Arrivage arrivageOBj = new classes.Arrivage();
            DataTable data = arrivageOBj.showAllArrivage();

            arrivageListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)arrivageListGrid.Columns[0]).Binding = new Binding("date_arrivage");
            ((DataGridTextColumn)arrivageListGrid.Columns[1]).Binding = new Binding("prixTotal");
            ((DataGridTextColumn)arrivageListGrid.Columns[2]).Binding = new Binding("payee");
            ((DataGridTextColumn)arrivageListGrid.Columns[3]).Binding = new Binding("Rest_payee");
         


        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void addArrivageBtn_Click(object sender, RoutedEventArgs e)
        {
            new nouvelleArrivageWindow().Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void historiqueBtn_Click(object sender, RoutedEventArgs e)
        {

            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            DateTime date = DateTime.Parse(classes.GlobalVariable.dataRowView[1].ToString());
             new histoArrivageWindow( date).Show();

        }
    }
}
