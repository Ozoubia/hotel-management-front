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
        public HistoriqueArticleWindow(string reference1 ,string designationDej)
        {
            InitializeComponent();
            showHistoriqueArticleList(reference1);
            showHistoriquePetitDejeunChambreList( designationDej);
            //////showprixMoyen(designationDej);
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
        public void showHistoriquePetitDejeunChambreList(string designationDejeun) 
        {
            classes.HistoriqueArticleChambreClass Obj =new  classes.HistoriqueArticleChambreClass();
            DataTable data = Obj.showAllhistoriqueChambreBydesignation(designationDejeun);
            HistoArticleChambreGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)HistoArticleChambreGrid.Columns[0]).Binding = new Binding("id_sejour");
            ((DataGridTextColumn)HistoArticleChambreGrid.Columns[1]).Binding = new Binding("date_sejour");
            ((DataGridTextColumn)HistoArticleChambreGrid.Columns[2]).Binding = new Binding("Nom_chambre");
            ((DataGridTextColumn)HistoArticleChambreGrid.Columns[3]).Binding = new Binding("type");
            ((DataGridTextColumn)HistoArticleChambreGrid.Columns[4]).Binding = new Binding("designation");
            ((DataGridTextColumn)HistoArticleChambreGrid.Columns[5]).Binding = new Binding("quantity");
        }
        //public void showprixMoyen(string disignation) 
        //{
        //    classes.article obj = new classes.article();
        //    double d = obj.calculePrixReel(disignation);
        //    prixAchetFild.Text = d.ToString();
        //}


        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
