using hotel_management_front.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Interaction logic for etatLieuChambreUserControl.xaml
    /// </summary>
    public partial class etatLieuChambreUserControl : UserControl
    {
       

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public etatLieuChambreUserControl()
        {
            InitializeComponent();

            // left grid -------------------------------------------
            //fill the grid with the rooms buttons
            room roomObj = new room();
            DataTable result = roomObj.showAllRooms();

            int nbrRooms = result.Rows.Count;

            // for each room
            for (int i = 0; i < nbrRooms; i++)
            {
                Button newBtn = new Button();
                string button_content = result.Rows[i]["name"].ToString();
                newBtn.Content = button_content;
                newBtn.Width = 100;
                newBtn.Height = 60;
                newBtn.Name = button_content;
                newBtn.Margin = new Thickness(10, 10, 10, 10);
                newBtn.Click += new RoutedEventHandler(button_click);

                mainGrid.Children.Add(newBtn);
            }

            // room button click
            void button_click(object sender, RoutedEventArgs e)
            {
                Button B = (Button)sender;
                string roomName = B.Name.ToString();

                emptyPreviousGrids();
                showRightTopGrid(roomName);

            }
        }

        private void showRightTopGrid(string roomName)
        {
            EquipementClass equipObj = new EquipementClass();
            DataTable equipements = equipObj.filterEquipByType("chambre");

            // number of equiprement
            int nbrEqui = equipements.Rows.Count;

            // list used to store the material / equipement names
            List<string> materialList = new List<string>();

            // getting room id from its name ( which we get from the click button)
            room roomObj = new room();
            DataTable result = roomObj.showRoomIDByName(roomName);
            int roomID = int.Parse(result.Rows[0]["id_room"].ToString());

            // filling the equipement items
            for (int i = 0; i < nbrEqui; i++)
            {
                string mater = equipements.Rows[i]["designation_E"].ToString();
                topGrid.Children.Add(new materialRoomUserControl(mater, roomID));
                materialList.Add(mater);
            }

        }

        private void emptyPreviousGrids()
        {
            topGrid.Children.Clear();
        }

    }
}
