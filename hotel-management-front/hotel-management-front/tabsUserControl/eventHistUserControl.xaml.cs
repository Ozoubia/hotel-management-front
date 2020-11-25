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
    /// Interaction logic for eventHistUserControl.xaml
    /// </summary>
    public partial class eventHistUserControl : UserControl
    {
        public eventHistUserControl()
        {
            InitializeComponent();
            showHistoriqueList();
        }
        public void showHistoriqueList()
        {
            classes.client clientObj = new classes.client();
            DataTable data = clientObj.showAllHistorique();
            HistoriqueListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)HistoriqueListGrid.Columns[0]).Binding = new Binding("type_action");
            ((DataGridTextColumn)HistoriqueListGrid.Columns[1]).Binding = new Binding("nom_utilisateur");
            ((DataGridTextColumn)HistoriqueListGrid.Columns[2]).Binding = new Binding("date_action");
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            classes.client clientObj1 = new classes.client();
            DataTable data = clientObj1.searchHistorique(searchBar.Text);
            HistoriqueListGrid.ItemsSource = data.DefaultView ;
        }
    }
}
