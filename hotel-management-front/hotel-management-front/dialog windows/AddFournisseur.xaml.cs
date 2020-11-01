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
    /// Interaction logic for AddFournisseur.xaml
    /// </summary>
    public partial class AddFournisseur : Window
    {
        public AddFournisseur()
        {
            InitializeComponent();
        }

        private void ajouterClientBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nomField.Text;
            string lname = PrenomField.Text;
            string address = addressField.Text;        
            string city = villeField.Text;
            string country = paysField.Text;
            int phoneNumber = int.Parse(telephoneField.Text);
            string email = emailField.Text;
            int credit = int.Parse(creditField.Text);

            classes.fournisseur fourniObj = new classes.fournisseur(name, lname, address, country, city, phoneNumber, email, credit);

            string result = fourniObj.AddFournisseur();
            MessageBox.Show(result);

        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
