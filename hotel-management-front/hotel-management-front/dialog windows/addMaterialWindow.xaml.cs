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
    /// Logique d'interaction pour addMaterialWindow.xaml
    /// </summary>
    public partial class addMaterialWindow : Window
    {
        public addMaterialWindow()
        {
            InitializeComponent();
        }

        private void ajouterMaterialtBtn_Click(object sender, RoutedEventArgs e)
        {
            string nomMaterial = nomMaterialField.Text;
            int quantiteMaterial = int.Parse(quantiteField.Text);
            int prixMaterial = int.Parse(prixMaterialField.Text);
            string nomFournisseur = nomFournisseurField.Text;
            DateTime dateAchat = DateTime.Parse(dateAchatField.SelectedDate.Value.Date.ToShortDateString());
            DateTime dateUtilisation = DateTime.Parse(dateUtilisationField.SelectedDate.Value.Date.ToShortDateString());
            string etatMaterial = etattField.Text;
            string Description = descriptionField.Text;
            classes.Material materialObj = new classes.Material(nomMaterial, quantiteMaterial, prixMaterial, nomFournisseur, dateAchat, dateUtilisation, etatMaterial, Description);
            string result = materialObj.addMaterial();
            MessageBox.Show(result);

        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    }

