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
    /// Logique d'interaction pour modifyEmergencyEquipmentWindow.xaml
    /// </summary>
    public partial class modifyEmergencyEquipmentWindow : Window
    {
        public modifyEmergencyEquipmentWindow()
        {
            InitializeComponent();
            classes.Secour secoursObj = new classes.Secour();

            // getting the index of the row 
            int rowIndex = int.Parse(classes.GlobalVariable.dataRowView[0].ToString());
            // getting the product information of the clicked index
          
            DataTable result = secoursObj.getMaterialS(rowIndex);
            nomMaterialField.Text = result.Rows[0]["Nom_Msecour"].ToString();
            quantiteField.Text = result.Rows[0]["Quantite_Msecour"].ToString();
            prixMaterialField.Text = result.Rows[0]["prix_Msecour"].ToString();
            nomFournisseurField.Text = result.Rows[0]["Nom_fournisseur"].ToString();
            EmplacementField.Text = result.Rows[0]["Emplacement_reserve"].ToString();
            etattField.Text = result.Rows[0]["Etat_MaterailS"].ToString();
            descriptionField.Text = result.Rows[0]["Description"].ToString();
            dateAchatField.SelectedDate = DateTime.Parse(result.Rows[0]["Date_Achat"].ToString());
        }


        private void modifierMaterialtBtn_Click(object sender, RoutedEventArgs e)
        {
            // getting the index of the row 
            int rowIndex = int.Parse(classes.GlobalVariable.dataRowView[0].ToString());
            // var fields assignings
            string nomMsecour = nomMaterialField.Text;
            int quantiteMsecour = int.Parse(quantiteField.Text);
            int prixMsecour = int.Parse(prixMaterialField.Text);
            string nomFournisseur = nomFournisseurField.Text;
            string emplacement = EmplacementField.Text;
            string description = descriptionField.Text;
            string etatMsecour = etattField.Text;
            DateTime dateAchat = DateTime.Parse(dateAchatField.SelectedDate.Value.Date.ToShortDateString());
            classes.Secour secourObj = new classes.Secour(nomMsecour,quantiteMsecour,nomFournisseur,emplacement,description,etatMsecour,dateAchat, prixMsecour);
            secourObj.modiftyMsecour(rowIndex);
            MessageBox.Show("Material secours  modifier");
        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
