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
    /// Logique d'interaction pour modiftyRoomWindow.xaml
    /// </summary>
    public partial class modiftyRoomWindow : Window
    {
        private string imgPath;
        int roomId;
        public modiftyRoomWindow(int ID)
        {
             roomId = ID;
            InitializeComponent();
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
            System.IO.File.Copy(imgPath, dest_path);

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

        }
    }
}
