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

        public materialRoomUserControl(string material, int id_room, int colorValue)
        {
            InitializeComponent();
            materialTxt.Text = material;
            this.roomID = id_room;
            
            load_button_colors(colorValue);
        }

        private void load_button_colors(int colorValue)
        {
            if (colorValue == 0)
            {
                btn.Background = Brushes.Blue;
                materialInfo.Visibility = Visibility.Hidden;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(materialInfo, "Quantitee");

            }
            else if (colorValue == 1)
            {
                btn.Background = Brushes.Green;
                materialInfo.Visibility = Visibility.Visible;
            }
            else
            {
                btn.Background = Brushes.Red;
                materialInfo.Visibility = Visibility.Visible;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(materialInfo, "Description");
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (((SolidColorBrush)btn.Background).Color == Colors.Blue)
            {
                btn.Background = Brushes.Green;
                materialInfo.Visibility = Visibility.Visible;

                // query
                string query = "UPDATE etat_lieu_room SET id_room=@id_room, " + materialTxt.Text + "=1" ;

                SqlCommand com = new SqlCommand(query, con);

                // params
                com.Parameters.AddWithValue("@id_room", this.roomID);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            else if (((SolidColorBrush)btn.Background).Color == Colors.Green)
            {
                btn.Background = Brushes.Red;
                materialInfo.Visibility = Visibility.Visible;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(materialInfo, "Description");

                // query
                string query = "UPDATE etat_lieu_room SET id_room=@id_room, " + materialTxt.Text + "=2";

                SqlCommand com = new SqlCommand(query, con);

                // params
                com.Parameters.AddWithValue("@id_room", this.roomID);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            else if (((SolidColorBrush)btn.Background).Color == Colors.Red)
            {
                btn.Background = Brushes.Blue;
                materialInfo.Visibility = Visibility.Hidden;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(materialInfo, "Quantitee");

                // query
                string query = "UPDATE etat_lieu_room SET id_room=@id_room, " + materialTxt.Text + "=0";

                SqlCommand com = new SqlCommand(query, con);

                // params
                com.Parameters.AddWithValue("@id_room", this.roomID);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
