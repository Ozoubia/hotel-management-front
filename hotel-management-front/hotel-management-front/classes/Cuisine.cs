using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace hotel_management_front.classes
{
    public class Cuisine
    {
        //Var 
        int quantity_cuisine;
        string designation_C;
        string reference_C;
        int stock_alert_C;
        int prix_achat_C;
        int prix_vente_C;
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public Cuisine() { }

        public Cuisine(int quantity, string design, string referenc, int stockAlert, int prixAchat, int prixVante)
        {
            this.quantity_cuisine = quantity;
            this.designation_C = design;
            this.reference_C = referenc;
            this.stock_alert_C = stockAlert;
            this.prix_achat_C = prixAchat;
            this.prix_vente_C = prixVante;
        }
        public DataTable showIDcuisine(string desig)
        {
            // checking if an employee exists
            string query = "SELECT ID_cuisine FROM cuisine WHERE designation_C=@Desig";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@Desig", desig);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }

        public void addCuisine()
        {
            {
                // checking if an employee exists
                string query = "SELECT * FROM cuisine WHERE reference_C=@reference";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                //query parameters 
                ada.SelectCommand.Parameters.AddWithValue("@reference", this.reference_C);

                // command result 
                DataTable dtbl = new DataTable();
                ada.Fill(dtbl);
                //user already exists 
                if (dtbl.Rows.Count < 1)
                {
                    // inseting into the general stock
                    string query2 = "INSERT INTO cuisine (quantity_cuisine, designation_C, stock_alert_C, prix_achat_C, prix_vente_C, reference_C ) " +
                        "VALUES ( 0, @designation, @stockAlert, @prixAchat, @prixVente, @reference)";

                    SqlCommand com = new SqlCommand(query2, con);

                    // params
                    com.Parameters.AddWithValue("@designation", this.designation_C);
                    com.Parameters.AddWithValue("@stockAlert", this.stock_alert_C);
                    com.Parameters.AddWithValue("@prixAchat", this.prix_achat_C);
                    com.Parameters.AddWithValue("@prixVente", this.prix_vente_C);
                    com.Parameters.AddWithValue("@reference", this.reference_C);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public DataTable showAllArticleCuisine()
        {


            string query = "SELECT * FROM cuisine  WHERE quantity_cuisine > 0 ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            
            return data;
         

        }
        // function that takes an ArticleCuisine ID and deletes it
        public void deleteArticleCuisine(int cuisineID)
        {
            string query = "UPDATE cuisine SET quantity_cuisine=0 WHERE ID_cuisine=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            // params
            cmd.Parameters.AddWithValue("@id", cuisineID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteCuisine(string reference)
        {
            string query = "DELETE FROM cuisine WHERE reference_C=@referenc";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@referenc", reference);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
    }

   
