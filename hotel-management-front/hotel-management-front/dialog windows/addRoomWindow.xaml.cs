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
    /// Interaction logic for addRoomWindow.xaml
    /// </summary>
    public partial class addRoomWindow : Window
    {
        public addRoomWindow()
        {
            InitializeComponent();
        }

        private void ajouterRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nomField.Text;
            string type = typeField.Text;
            int price = int.Parse(prixField.Text);
            string status = statusField.Text;
            bool isCleaned;
            if (isCleanedField.Text == "Oui")
            {
                isCleaned = true;
            }
            else
            {
                isCleaned = false;
            }
             

            classes.room roomOjb = new classes.room(name, type, price, status, isCleaned);
            string result = roomOjb.addRoom();
            MessageBox.Show(result);
        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
