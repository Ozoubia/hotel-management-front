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
    /// Logique d'interaction pour modifyProductWindow.xaml
    /// </summary>
    public partial class modifyProductWindow : Window
    {
        public modifyProductWindow()
        {
            InitializeComponent();
            // Product object
            classes.Produit produitObj = new classes.Produit();

            // getting the index of the row 
            int rowIndex = int.Parse(classes.GlobalVariable.dataRowView[0].ToString());

            // getting the product information of the clicked index
            DataTable result = produitObj.getProduit(rowIndex);
            nomProduitField.Text = result.Rows[0]["Nom_Produit"].ToString();
            quantiteField.Text = result.Rows[0]["Quantite_Produit"].ToString();
            prixProduitField.Text = result.Rows[0]["Prix_Produit"].ToString();
            nomFournisseurField.Text = result.Rows[0]["Nom_Fournisseur"].ToString();
            CategorieField.Text = result.Rows[0]["Categorie"].ToString();
            datelivraisonField.SelectedDate = DateTime.Parse(result.Rows[0]["Date_livraison"].ToString());

        }

        private void modifierProduitBtn_Click(object sender, RoutedEventArgs e)
        {

            // getting the index of the row 
            int rowIndex = int.Parse(classes.GlobalVariable.dataRowView[0].ToString());
            // var fields assignings
            string nomProd = nomProduitField.Text;
            int quantite = int.Parse(quantiteField.Text);
            int prix = int.Parse(prixProduitField.Text);
            string nomFourr = nomFournisseurField.Text;
            string categorie = CategorieField.Text;
            DateTime detaLiv = DateTime.Parse(datelivraisonField.SelectedDate.Value.Date.ToShortDateString());

            classes.Produit produitObj = new classes.Produit(nomProd, quantite, prix, nomFourr, categorie, detaLiv);
            produitObj.modiftyPoduct(rowIndex);
            MessageBox.Show("Produit modifier");


        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
