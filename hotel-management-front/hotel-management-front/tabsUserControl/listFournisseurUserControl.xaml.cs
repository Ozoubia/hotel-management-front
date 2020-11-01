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
    /// Interaction logic for listFournisseurUserControl.xaml
    /// </summary>
    public partial class listFournisseurUserControl : UserControl
    {
        public listFournisseurUserControl()
        {
            InitializeComponent();
            showFourniList();
        }

        //function to fill the employee list
        public void showFourniList()
        {
            classes.fournisseur fourniObj = new classes.fournisseur();
            DataTable data = fourniObj.showAllFournisseurs();

            fourniListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)fourniListGrid.Columns[0]).Binding = new Binding("name");
            ((DataGridTextColumn)fourniListGrid.Columns[1]).Binding = new Binding("lname");
            ((DataGridTextColumn)fourniListGrid.Columns[2]).Binding = new Binding("adress");
            ((DataGridTextColumn)fourniListGrid.Columns[3]).Binding = new Binding("country");
            ((DataGridTextColumn)fourniListGrid.Columns[4]).Binding = new Binding("city");
            ((DataGridTextColumn)fourniListGrid.Columns[5]).Binding = new Binding("telephone");
            ((DataGridTextColumn)fourniListGrid.Columns[6]).Binding = new Binding("email");
            ((DataGridTextColumn)fourniListGrid.Columns[7]).Binding = new Binding("credit");

        }

        private void addFournisseurBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddFournisseur().Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
