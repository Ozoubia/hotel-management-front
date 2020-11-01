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
    /// Interaction logic for nouvelleArrivageWindow.xaml
    /// </summary>
    public partial class nouvelleArrivageWindow : Window
    {
        public nouvelleArrivageWindow()
        {
            InitializeComponent();
            fillfournisseurCombo();
            dateArrivageField.Text = DateTime.Now.Date.ToString();

        }

        // function to fill the client bombo box
        public void fillfournisseurCombo()
        {
            classes.fournisseur fournisseurObj = new classes.fournisseur();
            DataTable data = fournisseurObj.showAllFournisseurs();
            int data_length = data.Rows.Count;

            // looping through the client list
            for (int i = 0; i < data_length; i++)
            {
                string name = data.Rows[i]["name"].ToString();
                string lname = data.Rows[i]["lname"].ToString();
                string full_name = name + " " + lname;
                fournisseurComboBox.Items.Add(full_name);
            }

        }

        private void ajouterClientBtn_Click(object sender, RoutedEventArgs e)
        {
            string reference = referenceField.Text;
            string designation = designationField.Text;
            string famille = familleField.Text;
            int quantity = int.Parse(quantityField.Text);
            int stockAlert = int.Parse(stockAlertField.Text);
            DateTime dateExpi = DateTime.Parse(dateExpirField.SelectedDate.Value.Date.ToShortDateString());
            string fournisseurName = fournisseurComboBox.Text;
            int prixAchat = int.Parse(prixAchatField.Text);
            int prixVente = int.Parse(prixVenteField.Text);     
            string localisation = localisationField.Text;
            DateTime dateArrivage = DateTime.Parse(dateArrivageField.SelectedDate.Value.Date.ToShortDateString()); ;

            classes.article articleObj = new classes.article(reference, designation, famille, quantity, stockAlert, dateExpi, fournisseurName, prixAchat,
                                            prixVente, localisation, dateArrivage);

            string result = articleObj.addArticle();
            MessageBox.Show(result);
        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
