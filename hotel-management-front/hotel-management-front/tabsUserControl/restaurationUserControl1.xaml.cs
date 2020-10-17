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
    /// Logique d'interaction pour restaurationUserControl1.xaml
    /// </summary>
    public partial class restaurationUserControl1 : UserControl
    {
        public restaurationUserControl1()
        {
            InitializeComponent();
            showProduitList();
        }
        //function to fill the Product list
        public void showProduitList()
        {
            classes.Produit produitObj = new classes.Produit();
            DataTable data = produitObj.showAllProduct();

            ProduitListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)ProduitListGrid.Columns[0]).Binding = new Binding("Id_Produit");
            ((DataGridTextColumn)ProduitListGrid.Columns[1]).Binding = new Binding("Nom_Produit");
            ((DataGridTextColumn)ProduitListGrid.Columns[2]).Binding = new Binding("Quantite_Produit");
            ((DataGridTextColumn)ProduitListGrid.Columns[3]).Binding = new Binding("Prix_Produit");
            ((DataGridTextColumn)ProduitListGrid.Columns[4]).Binding = new Binding("Nom_Fournisseur");
            ((DataGridTextColumn)ProduitListGrid.Columns[5]).Binding = new Binding("Categorie");
            ((DataGridTextColumn)ProduitListGrid.Columns[6]).Binding = new Binding("Date_livraison");
        }


        private void AjouterProduit_Click(object sender, RoutedEventArgs e)
        {
            new addProductWindow().Show();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            classes.Produit produitObj = new classes.Produit();
            DataTable data  = produitObj.searchProduct(searchBar.Text);
            ProduitListGrid.ItemsSource = data.DefaultView;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            // opening the modify page
            new modifyProductWindow().Show();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            classes.Produit produitObj = new classes.Produit();
            produitObj.deleteProduct(int.Parse(classes.GlobalVariable.dataRowView[0].ToString()));
        }
    }
}
