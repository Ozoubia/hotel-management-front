using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    public class EquipementClass
    {
        //Var 
        int quantity_Equipement;
        string designation_E;
        string reference_E;
        int stock_alert_E;
        int prix_achat_E;

        public EquipementClass()
        {
        }
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public EquipementClass(int quantity, string design, string referenc, int stockAlert, int prixAchat)
        {
            this.quantity_Equipement = quantity;
            this.designation_E = design;
            this.reference_E = referenc;
            this.stock_alert_E = stockAlert;
            this.prix_achat_E = prixAchat;

        }
        public String addequipement()
        {
            {
                // checking if an employee exists
                string query = "SELECT * FROM Equipement WHERE reference_E=@reference";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                //query parameters 
                ada.SelectCommand.Parameters.AddWithValue("@reference", this.reference_E);

                // command result 
                DataTable dtbl = new DataTable();
                ada.Fill(dtbl);
                //user already exists 
                if (dtbl.Rows.Count < 1)
                {
                    // inseting into the general stock
                    string query2 = "INSERT INTO Equipement (reference_E , designation_E, stock_alert_E,  prix_achat_E , quantity_equipement , type_Equipement) " +
                        "VALUES (@reference , @designation, @stockAlert, @prixAchat , @quantity , 'null')";

                    SqlCommand com = new SqlCommand(query2, con);

                    // params
                    com.Parameters.AddWithValue("@reference", this.reference_E);
                    com.Parameters.AddWithValue("@designation", this.designation_E);
                    com.Parameters.AddWithValue("@stockAlert", this.stock_alert_E);
                    com.Parameters.AddWithValue("@prixAchat", this.prix_achat_E);
                    com.Parameters.AddWithValue("@quantity", this.quantity_Equipement);
                  

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                
                }
            }
            return "equipment added successfuly";
        }
        public DataTable showAllequipement()
        {


            string query = "SELECT * FROM Equipement";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);

            return data;


        }
        public DataTable showIDEquipement(string desig)
        {
            // checking if an employee exists
            string query = "SELECT ID_Equipement FROM Equipement WHERE designation_E=@Desig";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@Desig", desig);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
        public void deleteEquipement(string reference)
        {
            string query = "DELETE FROM Equipement WHERE reference_E=@referenc";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@referenc", reference);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable showQuantite(string desig)
        {
            // checking if an employee exists
            string query = "SELECT quantity_equipement FROM Equipement WHERE designation_E=@Desig";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@Desig", desig);
             // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }


        // used for the room equipement alimentation
        public DataTable filterEquipByType(string equipType)
        {
            // checking if an employee exists
            string query = "SELECT * FROM Equipement WHERE type_Equipement=@type";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@type", equipType);


            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
    }
}
