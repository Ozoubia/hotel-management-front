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
    /// Interaction logic for addClientWindow.xaml
    /// </summary>
    public partial class addClientWindow : Window
    {
        public addClientWindow()
        {
            InitializeComponent();
        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ajouterClientBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nomField.Text;
            string lname = PrenomField.Text;
            string sex = sexField.Text;
            DateTime birthDate = DateTime.Parse(dateNaissanceField.SelectedDate.Value.Date.ToShortDateString());
            string city = villeField.Text;
            string country = paysField.Text;
            int phoneNumber = int.Parse(telephoneField.Text);
            int CIN = int.Parse(CINField.Text);
            string status = statusField.Text;
            DateTime startDate = DateTime.Parse(dateDebutField.SelectedDate.Value.Date.ToShortDateString());
            DateTime endDate = DateTime.Parse(dateDepartField.SelectedDate.Value.Date.ToShortDateString());

            classes.client clientObj = new classes.client(name, lname, sex, birthDate, city, country, phoneNumber, status, CIN, startDate, endDate);
            string result = clientObj.addClient();
            MessageBox.Show(result);

            // updating the client grid

        }
    }
}
