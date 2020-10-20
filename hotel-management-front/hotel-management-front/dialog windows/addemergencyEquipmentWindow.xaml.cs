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
    /// Logique d'interaction pour addemergencyEquipmentWindow.xaml
    /// </summary>
    public partial class addemergencyEquipmentWindow : Window
    {
        public addemergencyEquipmentWindow()
        {
            InitializeComponent();
        }

        private void ajouterMaterialtBtn_Click(object sender, RoutedEventArgs e)
        {
            string nomMsecour = nomMaterialField.Text;
            int quantiteMsecour = int.Parse(quantiteField.Text);
            int prixMsecour = int.Parse(prixMaterialField.Text);
            string nomFournisseur = nomFournisseurField.Text;
            //DateTime dateA = DateTime.Parse(dateAchatField.SelectedDate.Value.Date.ToShortDateString());
            DateTime dateAchat = DateTime.Parse(dateAchatField.SelectedDate.Value.Date.ToShortDateString());
            string etatMsecour = etattField.Text;
            string emplacement = EmplacementField.Text;
            string description = descriptionField.Text;
            classes.Secour secoursObj = new classes.Secour(nomMsecour, quantiteMsecour, prixMsecour, nomFournisseur, dateAchat, etatMsecour, emplacement, description);
            string result = secoursObj.addMsecour();
            MessageBox.Show(result);


        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
