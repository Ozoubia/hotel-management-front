using Microsoft.Win32;
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

        public string imgPath;

        private void ajouterRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nomField.Text;
            string type = typeField.Text;
            int price = int.Parse(prixField.Text);
            bool isWorking;
            if (isWorkingField.Text == "Oui")
            {
                isWorking = true;
            }
            else
            {
                isWorking = false;
            }

            string dest_path = "images/" + name + ".jpg";
            //copying image to the image folders
            System.IO.File.Move(imgPath, dest_path);

            classes.room roomOjb = new classes.room(name, type, price, isWorking, dest_path);
            string result = roomOjb.addRoom();
            MessageBox.Show(result);
            // add action to history log
            string par = "Ajouter Chambre";
            string nom = classes.GlobalVariable.username;
            DateTime dateAction = DateTime.Today;
            classes.client clientObj1 = new classes.client();
            clientObj1.ajouterHistorique(nom, par, dateAction);
        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addRoomImg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Selectionner image";
                dialog.Filter = "Image files (*.png;*.jpeg,*.jpg)|*.png;*.jpeg;*.jpg";
                if (dialog.ShowDialog() == true)
                {
                    addStatus.Text = "image ajoutee";
                    string rawPath = new Uri(dialog.FileName, UriKind.Absolute).ToString();
                    imgPath = rawPath.Substring(8);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une image");
            }
        }
    }
}
