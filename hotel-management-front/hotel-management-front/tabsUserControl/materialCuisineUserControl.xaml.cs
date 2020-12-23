using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.SqlClient;
using hotel_management_front.classes;
using System.Data;
using System;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour materialCuisineUserControl.xaml
    /// </summary>
    public partial class materialCuisineUserControl : UserControl
    {
        //VAR 
        string mater;
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public materialCuisineUserControl(string material)
        {
            InitializeComponent();
            materialTxt.Text = material;
         
        }
      
        string modiftyQuantity() { 
        
            classes.Cuisine cuisineObj = new classes.Cuisine();
            DataTable IDcuisin = cuisineObj.showIDcuisine(materialTxt.Text);
            int IDcuisine = int.Parse(IDcuisin.Rows[0]["ID_cuisine"].ToString());
            int quantity = int.Parse(materialInfo.Text);
            string query1 = "SELECT quantity_cuisine FROM cuisine WHERE ID_cuisine=@id";
            SqlDataAdapter ada = new SqlDataAdapter(query1, con);
            ada.SelectCommand.Parameters.AddWithValue("@id", IDcuisine);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            int qun = (int)dtbl.Rows[0]["quantity_cuisine"];
            int result = qun + quantity;
            // query
            string query = "UPDATE cuisine SET quantity_cuisine=@quant WHERE ID_cuisine=@id";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@quant", result);
            com.Parameters.AddWithValue("@id", IDcuisine);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            return "1";

        }
        string modiftyQuantityArticle()
        {
            classes.article articleObj = new classes.article();
            DataTable IDarticle = articleObj.showIDArticle(materialTxt.Text);
            int IDarticl = int.Parse(IDarticle.Rows[0]["id_article"].ToString());
            int quantityArticle = int.Parse(materialInfo.Text);
           
            int quantity = int.Parse(materialInfo.Text);
            string query3 = "SELECT quantity_utilisee FROM article WHERE id_article=@id";
            SqlDataAdapter ada1 = new SqlDataAdapter(query3, con);
            ada1.SelectCommand.Parameters.AddWithValue("@id", IDarticl);

            // command result 
            DataTable dtb2 = new DataTable();
            ada1.Fill(dtb2);
            int qun1 = (int)dtb2.Rows[0]["quantity_utilisee"];
            int result2 = qun1 + quantityArticle;
            // query
            string query = "UPDATE article SET quantity_utilisee=@quant WHERE id_article=@id";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@quant", result2);
            com.Parameters.AddWithValue("@id", IDarticl);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            
            string query1 = "SELECT quantity FROM article WHERE id_article=@id";
            SqlDataAdapter ada = new SqlDataAdapter(query1, con);
            ada.SelectCommand.Parameters.AddWithValue("@id", IDarticl);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            int qun = (int)dtbl.Rows[0]["quantity"];
            int result = qun - quantityArticle;

            string query2 = "UPDATE article SET quantity=@resul WHERE id_article=@id";
              SqlCommand comm = new SqlCommand(query2, con);

            //params
            comm.Parameters.AddWithValue("@resul", result);
            comm.Parameters.AddWithValue("@id", IDarticl);

            con.Open();
            comm.ExecuteNonQuery();
            con.Close();
            return "2";
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


        private void Ajoutebtn_Click(object sender, RoutedEventArgs e)
        {
            classes.article articleObj = new classes.article();
            DataTable IDarticle = articleObj.showIDArticle(materialTxt.Text);
            int IDarticl = int.Parse(IDarticle.Rows[0]["id_article"].ToString());
            string query1 = "SELECT quantity FROM article WHERE id_article=@id";
            SqlDataAdapter ada = new SqlDataAdapter(query1, con);
            ada.SelectCommand.Parameters.AddWithValue("@id", IDarticl);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
          
            int qun = (int)dtbl.Rows[0]["quantity"];
            
            int quantityArticl = int.Parse(materialInfo.Text);
            if (qun < quantityArticl)
            {
                MessageBox.Show("quantité n'est pas suffisant ");
               

            }
            else
            {

              string rslt = modiftyQuantity();
              MessageBox.Show(rslt);
              string rslt1 = modiftyQuantityArticle();
              MessageBox.Show(rslt1);
                //ajouter dans l'historique
                string par = "modifier quantité dans cuisine ";
                string nom = classes.GlobalVariable.username;
                DateTime dateAction = DateTime.Today;
                classes.client clientObj1 = new classes.client();
                clientObj1.ajouterHistorique(nom, par, dateAction);
                
            }   
           }
        }
        
        
    }

