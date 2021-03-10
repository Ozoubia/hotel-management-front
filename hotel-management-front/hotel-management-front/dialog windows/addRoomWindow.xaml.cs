using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
            fillTypeChambreCombo();
        }

        public string imgPath;
        public void fillTypeChambreCombo()
        {
            classes.typeChambre typeChambreObj = new classes.typeChambre();
            DataTable data = typeChambreObj.showAllTypes();
            int data_length = data.Rows.Count;

            // looping through the client list
            for (int i = 0; i < data_length; i++)
            {
                string type = data.Rows[i]["typeChambre"].ToString();
                typeComboBox1.Items.Add(type);
            }

        }

        private void ajouterRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nomField.Text;
            string type = typeComboBox1.Text;
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
            System.IO.File.Copy(imgPath, dest_path);

            classes.room roomOjb = new classes.room(name, type, price, isWorking, dest_path);
            string result = roomOjb.addRoom();
            MessageBox.Show(result);

            // adding room etat lieu 
            if (result == "Room added successfuly")
            {
                classes.ELRoom elroomObj = new classes.ELRoom();
                elroomObj.addRoomIDELRoom(name);
            }
            


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
