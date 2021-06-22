using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
   public class Arrivage
    {
        DateTime dateArrivage;
        int prixTotal;
        int payee;
        int restPayee;
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public Arrivage()
        {

        }
        public  Arrivage( int prixTot , int pay , int restPay)

        {
            this.prixTotal = prixTot;
            this.payee = pay;
            this.restPayee = restPay;
        }
        public void addarrivage( DateTime date ,int prixTotall)
        {
            // checking if an employee exists
            string query = "SELECT * FROM arrivage WHERE date_arrivage=@date ";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@date", date);
      

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                string query1 = "select  SUM(prix_achat * quantity) as somme from article where date_arrivage=@date";
                con.Open();
                SqlDataAdapter ada1 = new SqlDataAdapter(query1, con);
                //query parameters 
                ada1.SelectCommand.Parameters.AddWithValue("@date", date);
                DataTable data = new DataTable();
                ada1.Fill(data);
                con.Close();
                int sommmeTotal = int.Parse(data.Rows[0]["somme"].ToString());

                string query2 = "UPDATE arrivage SET prixTotal=@prix WHERE date_arrivage=@date";
                SqlCommand com = new SqlCommand(query2, con);

                // params
                com.Parameters.AddWithValue("@prix", sommmeTotal);
                com.Parameters.AddWithValue("@date",date );
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            else 
            {
                // inseting into the arrivage
                string query6 = "INSERT INTO arrivage ( date_arrivage, prixTotal , payee, Rest_payee ) VALUES (@date, @prixTot, @pay ,@restPay)";
                SqlCommand com2 = new SqlCommand(query6, con);
                // params
                com2.Parameters.AddWithValue("@date", date);
                com2.Parameters.AddWithValue("@prixTot", prixTotall);
                com2.Parameters.AddWithValue("@pay", 0);
                com2.Parameters.AddWithValue("@restPay", 0);
                con.Open();
                com2.ExecuteNonQuery();
                con.Close();
            }
            

          
        }

        //sommer le prix total de arrivage par le groupement de date
        public DataTable groupByDate(DateTime dateArriv) 
        {
            string query = "select  date_arrivage , SUM(prix_achat*quantity) as somme from article where date_arrivage =@date GROUP BY date_arrivage";
            con.Open();
            SqlDataAdapter ada1 = new SqlDataAdapter(query, con);
            //query parameters 
            ada1.SelectCommand.Parameters.AddWithValue("@date", dateArriv);
            DataTable data = new DataTable();
            ada1.Fill(data);
            con.Close();
            
            return data;
        }
        public DataTable showAllArrivage()
        {
            string query = "SELECT * FROM arrivage";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        public int  groupByFournisseur(int  idFournisseur , DateTime dateArriv) 
        {
            string query = "select   SUM(prix_achat*quantity) as somme from article where id_fournisseur=@ID AND date_arrivage =@date GROUP BY id_fournisseur";
            con.Open();
            SqlDataAdapter ada1 = new SqlDataAdapter(query, con);
            //query parameters 
            ada1.SelectCommand.Parameters.AddWithValue("@ID", idFournisseur);
            ada1.SelectCommand.Parameters.AddWithValue("@date", dateArriv);
            DataTable data = new DataTable();
            ada1.Fill(data);
            con.Close();
            int som = int.Parse(data.Rows[0]["somme"].ToString());
            return som;

        }


        public int recupererIdFourniseur(string nom , string prenom)
        {
            // getting client id 
            string query1 = "SELECT id_fournisseur FROM fournisseur WHERE name=@name AND lname=@lname";
            SqlDataAdapter ada1 = new SqlDataAdapter(query1, con);
            ada1.SelectCommand.Parameters.AddWithValue("@name", nom);
            ada1.SelectCommand.Parameters.AddWithValue("@lname", prenom);
            DataTable dtbl1 = new DataTable();
            ada1.Fill(dtbl1);
            int idFournisseur = int.Parse(dtbl1.Rows[0]["id_fournisseur"].ToString());
            return idFournisseur;
        }
    }



   
}
