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
using System.Data;
using System;
using hotel_management_front.classes;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour modifierMatérielCuisineUserControl.xaml
    /// </summary>
    public partial class modifierMatérielCuisineUserControl : UserControl
    {
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public modifierMatérielCuisineUserControl(string material )
        {
            InitializeComponent();
            materialTxt.Text = material;

        }

        private void Modifierbtn_Click(object sender, RoutedEventArgs e)
        {
            classes.Cuisine cuisineObj = new Cuisine();
            DataTable IDarticle = cuisineObj.showIDcuisine(materialTxt.Text);
            int IDcuisine = int.Parse(IDarticle.Rows[0]["ID_cuisine"].ToString());
            int quantity = int.Parse(materialInfo.Text);
            string query1 = "SELECT quantity_cuisine FROM cuisine WHERE ID_cuisine=@id";
            SqlDataAdapter ada = new SqlDataAdapter(query1, con);
            ada.SelectCommand.Parameters.AddWithValue("@id", IDcuisine);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            int qun = (int)dtbl.Rows[0]["quantity_cuisine"];
            int result = qun - quantity;
            // query
            string query = "UPDATE cuisine SET quantity_cuisine=@quant WHERE ID_cuisine=@id";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@quant", result);
            com.Parameters.AddWithValue("@id", IDcuisine);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (((SolidColorBrush)btn.Background).Color == Colors.Blue)
            {
                btn.Background = Brushes.Green;
                materialInfo.Visibility = Visibility.Visible;

            }
            else if (((SolidColorBrush)btn.Background).Color == Colors.Green)
            {
                btn.Background = Brushes.Blue;
                materialInfo.Visibility = Visibility.Hidden;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(materialInfo, "Quantitee");
            }
        }
    }
}
