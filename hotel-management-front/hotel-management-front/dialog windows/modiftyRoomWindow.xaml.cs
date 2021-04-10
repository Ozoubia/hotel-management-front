using Microsoft.Win32;
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
    /// Logique d'interaction pour modiftyRoomWindow.xaml
    /// </summary>
    public partial class modiftyRoomWindow : Window
    {
        
        int roomId;
        public modiftyRoomWindow(int ID)
        {
             roomId = ID;
            InitializeComponent();
            getPreviousDate();
        }

        public string imgPath;
        //getting clicked room data
        private void getPreviousDate()
        {
            // employee object
            classes.room roomObj = new classes.room();

            // getting the index of the row 
            int rowIndex = int.Parse(classes.GlobalVariable.dataRowView[0].ToString());

            // getting the employee information of the clicked index
            DataTable result = roomObj.getRoomInfo(rowIndex);

            // assigning the variable to the fields
            nomField.Text = result.Rows[0]["name"].ToString();
            typeComboBox1.Text = result.Rows[0]["type"].ToString();
            prixField.Text = result.Rows[0]["base_price"].ToString();
            string works = result.Rows[0]["works"].ToString();
            if (works == "True")
            {
                isWorkingField.Text = "Oui";
            }
            else
            {
                isWorkingField.Text = "Non";
            }
        }

        private void modifierBtn_Click(object sender, RoutedEventArgs e)
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
            System.IO.File.Copy(this.imgPath, dest_path);

            classes.room roomOjb = new classes.room(name, type, price, isWorking, dest_path);
            string result = roomOjb.modiftyRoom(roomId);
            MessageBox.Show(result);

            // adding room etat lieu 
            if (result == "Room modifty successfuly")
            {
                classes.ELRoom elroomObj = new classes.ELRoom();
                elroomObj.addRoomIDELRoom(name);
            }
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
                    this.imgPath = rawPath.Substring(8);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez selectionner une image");
            }
        }
    }
}
