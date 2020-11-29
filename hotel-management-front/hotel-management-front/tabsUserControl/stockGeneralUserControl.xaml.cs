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
    /// Interaction logic for stockGeneralUserControl.xaml
    /// </summary>
    public partial class stockGeneralUserControl : UserControl
    {
        public stockGeneralUserControl()
        {
            InitializeComponent();
            showArticleList();
        }

        //function to fill the employee list
        public void showArticleList()
        {
            classes.article articleObj = new classes.article();
            DataTable data = articleObj.showAllArticles();

            articleListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)articleListGrid.Columns[0]).Binding = new Binding("reference");
            ((DataGridTextColumn)articleListGrid.Columns[1]).Binding = new Binding("designation");
            ((DataGridTextColumn)articleListGrid.Columns[2]).Binding = new Binding("famille");
            ((DataGridTextColumn)articleListGrid.Columns[3]).Binding = new Binding("quantity");
            ((DataGridTextColumn)articleListGrid.Columns[4]).Binding = new Binding("stock_alert");
            ((DataGridTextColumn)articleListGrid.Columns[5]).Binding = new Binding("quantity_utilisee");
            ((DataGridTextColumn)articleListGrid.Columns[6]).Binding = new Binding("name");
            ((DataGridTextColumn)articleListGrid.Columns[7]).Binding = new Binding("lname");
            ((DataGridTextColumn)articleListGrid.Columns[8]).Binding = new Binding("date_expiration");
            ((DataGridTextColumn)articleListGrid.Columns[9]).Binding = new Binding("prix_achat");
            ((DataGridTextColumn)articleListGrid.Columns[10]).Binding = new Binding("prix_vente");
            ((DataGridTextColumn)articleListGrid.Columns[11]).Binding = new Binding("localisation");
            ((DataGridTextColumn)articleListGrid.Columns[12]).Binding = new Binding("date_arrivage");


        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            classes.Cuisine cuisineObj = new classes.Cuisine();
            classes.article articleObj = new classes.article();
            string reference = classes.GlobalVariable.dataRowView[0].ToString();
            cuisineObj.deleteCuisine(reference);
            articleObj.deleteActicle(reference);
            showArticleList();
            // add action to history log
            string par = "supprimer  le produit de la cuisine";
            string nom = classes.GlobalVariable.username;
            DateTime dateAction = DateTime.Today;
            classes.client clientObj1 = new classes.client();
            clientObj1.ajouterHistorique(nom, par, dateAction);

            string par1 = "supprimer  le produit de le stock général ";
            string nom1 = classes.GlobalVariable.username;
            DateTime dateAction1 = DateTime.Today;
            classes.client clientObj2 = new classes.client();
            clientObj1.ajouterHistorique(nom1, par1, dateAction1);



        }
    }
}
