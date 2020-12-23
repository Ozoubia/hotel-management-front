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
using System.Windows.Shapes;

namespace hotel_management_front.dialog_windows
{
    /// <summary>
    /// Logique d'interaction pour HistoriqueArticleWindow.xaml
    /// </summary>
    public partial class HistoriqueArticleWindow : Window
    {
        public HistoriqueArticleWindow(string reference1)
        {
            InitializeComponent();
            showHistoriqueArticleList(reference1);
        }
        public void showHistoriqueArticleList(string reference)
        {
            classes.article articleObj = new classes.article();
            DataTable data = articleObj.showAllHistoriqueArticle(reference);

            HistoArticleListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)HistoArticleListGrid.Columns[0]).Binding = new Binding("name");
            ((DataGridTextColumn)HistoArticleListGrid.Columns[1]).Binding = new Binding("lname");
            ((DataGridTextColumn)HistoArticleListGrid.Columns[2]).Binding = new Binding("referenceArticl");
            ((DataGridTextColumn)HistoArticleListGrid.Columns[3]).Binding = new Binding("designationArticl");
            ((DataGridTextColumn)HistoArticleListGrid.Columns[4]).Binding = new Binding("quantityArticl");
            ((DataGridTextColumn)HistoArticleListGrid.Columns[5]).Binding = new Binding("prix_achatArticl");
            ((DataGridTextColumn)HistoArticleListGrid.Columns[6]).Binding = new Binding("prix_venteArticl");
            ((DataGridTextColumn)HistoArticleListGrid.Columns[7]).Binding = new Binding("date_expirationArticl");
            ((DataGridTextColumn)HistoArticleListGrid.Columns[8]).Binding = new Binding("date_arrivageArticl");


        }


        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
