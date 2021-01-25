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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using hotel_management_front.classes;
using System.Data;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Interaction logic for materialRoomUserControl.xaml
    /// </summary>
    public partial class materialRoomUserControl : UserControl
    {
        int roomID;
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public materialRoomUserControl(string material, int id_room)
        {
            InitializeComponent();
            materialTxt.Text = material;
            this.roomID = id_room;


            load_button_colors(material, id_room);
        }

        // loading the buttons information for each room and material item
        private void load_button_colors(string mat, int idRoom)
        {
            // get value for specific room and material
            ELRoom elObj = new ELRoom();

            DataTable result = elObj.getColorValue(mat, idRoom);
            int colorValue = int.Parse(result.Rows[0][mat].ToString());


            if (colorValue == 0)
            {
                btn.Background = Brushes.Blue;
            }
            else if (colorValue == 1)
            {

                btn.Background = Brushes.Green;
            }
            else if (colorValue == 2)
            {
                btn.Background = Brushes.Red;
            }

        }

        // when clicking on the button 
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (((SolidColorBrush)btn.Background).Color == Colors.Blue)
            {
                // changing the color
                btn.Background = Brushes.Green;
                materialInfo.Visibility = Visibility.Visible;

                // changing the color value
                ELRoom elroomObj = new ELRoom();
                elroomObj.changeColorValue(materialTxt.Text, roomID, 1);

            }
            else if (((SolidColorBrush)btn.Background).Color == Colors.Green)
            {
                // changing the color
                btn.Background = Brushes.Red;
                materialInfo.Visibility = Visibility.Visible;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(materialInfo, "Description");

                // changing the color value
                ELRoom elroomObj = new ELRoom();
                elroomObj.changeColorValue(materialTxt.Text, roomID, 2);
            }
            else if (((SolidColorBrush)btn.Background).Color == Colors.Red)
            {
                // changing the color
                btn.Background = Brushes.Blue;
                materialInfo.Visibility = Visibility.Hidden;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(materialInfo, "Quantitee");

                // changing the color value
                ELRoom elroomObj = new ELRoom();
                elroomObj.changeColorValue(materialTxt.Text, roomID, 0);
            }
        }
    }
}
