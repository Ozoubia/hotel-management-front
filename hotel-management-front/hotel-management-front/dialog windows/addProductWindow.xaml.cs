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
using System.Windows.Shapes;

namespace hotel_management_front.dialog_windows
{
    /// <summary>
    /// Logique d'interaction pour addProductWindow.xaml
    /// </summary>
    public partial class addProductWindow : Window
    {
        public addProductWindow()
        {
            InitializeComponent();
        }

        private void ajouterProduitBtn_Click(object sender, RoutedEventArgs e)
        {
            string nomProduit = nomProduitField.Text;
            int quantite = int.Parse(quantiteField.Text);
            int prix = int.Parse(prixProduitField.Text);
            string nomFour = nomFournisseurField.Text;
            string categori = CategorieField.Text;
            DateTime dateLivr = DateTime.Parse(datelivraisonField.SelectedDate.Value.Date.ToShortDateString());
            classes.Produit produitObj = new classes.Produit(nomProduit, quantite, prix, nomFour, categori, dateLivr);
            string result = produitObj.addProduct();
            MessageBox.Show(result);
        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
