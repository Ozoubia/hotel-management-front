using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
   public class HistoArrivage
    {


        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        //VAR

        string nomFournisseur;
        string prenomFournisseur;
        int prixTotal;
        int payee;
        int restPayee;


        public HistoArrivage()
        {

        }

        public HistoArrivage( string nom , string prenom , int prixT , int pay , int restPay)
        {
            this.nomFournisseur = nom;
            this.prenomFournisseur = prenom;
            this.prixTotal = prixT;
            this.payee = pay;
            this.restPayee = restPay;
        }

        public void addhistoriqueArrivage( string nomF ,string  prenomF , int prixT , DateTime dateArrivage )
        {
            // checking if an employee exists
            string query = "SELECT * FROM histoArrivage WHERE nom_fournisseur=@nom AND prenom_founisseur=@prenom AND date_arrivage =@date";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@nom", nomF);
            ada.SelectCommand.Parameters.AddWithValue("@prenom", prenomF);
            ada.SelectCommand.Parameters.AddWithValue("@date", dateArrivage);
            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
               // getting client id
            string query1 = "SELECT id_fournisseur FROM fournisseur WHERE name=@name AND lname=@lname";
                SqlDataAdapter ada1 = new SqlDataAdapter(query1, con);
                ada1.SelectCommand.Parameters.AddWithValue("@name", nomF);
                ada1.SelectCommand.Parameters.AddWithValue("@lname", prenomF);
                DataTable dtbl1 = new DataTable();
                ada1.Fill(dtbl1);
                int idFournisseur = int.Parse(dtbl1.Rows[0]["id_fournisseur"].ToString());
                string query2 = "select  SUM(prix_achat * quantity) as somme from article where id_fournisseur= @id ";
                con.Open();
                SqlDataAdapter ada2 = new SqlDataAdapter(query2, con);
                //query parameters 
                ada2.SelectCommand.Parameters.AddWithValue("@id", idFournisseur);
                DataTable data = new DataTable();
                ada2.Fill(data);
                con.Close();
                int sommmeTotal = int.Parse(data.Rows[0]["somme"].ToString());

                string query3 = "UPDATE histoArrivage SET prixTotal=@prix WHERE nom_fournisseur=@nom AND prenom_founisseur=@prenom";
                SqlCommand com = new SqlCommand(query3, con);

                // params
                com.Parameters.AddWithValue("@prix", sommmeTotal);
                com.Parameters.AddWithValue("@nom", nomF);
                com.Parameters.AddWithValue("@prenom", prenomF);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                // inseting into the historique Article
                string query6 = "INSERT INTO histoArrivage ( nom_fournisseur ,prenom_founisseur ,prixTotal , payee ,rest_payee ,date_arrivage ) VALUES (@nom, @prenom, @prix ,@pay , @restpay , @date)";
                SqlCommand com2 = new SqlCommand(query6, con);
                // params
                com2.Parameters.AddWithValue("@nom", nomF);
                com2.Parameters.AddWithValue("@prenom", prenomF);
                com2.Parameters.AddWithValue("@prix", prixT);
                com2.Parameters.AddWithValue("@pay", 0);
                com2.Parameters.AddWithValue("@restpay", 0);
                com2.Parameters.AddWithValue("@date", dateArrivage );
                con.Open();
                com2.ExecuteNonQuery();
                con.Close();

            }

        }
        public DataTable groupByDateHisto(DateTime dateArriv)
        {
            string query = "select nom_fournisseur, prenom_founisseur , prixTotal , payee ,rest_payee, date_arrivage  from histoArrivage where date_arrivage =@date GROUP BY date_arrivage";
            con.Open();
            SqlDataAdapter ada1 = new SqlDataAdapter(query, con);
            //query parameters 
            ada1.SelectCommand.Parameters.AddWithValue("@date", dateArriv);
            DataTable data = new DataTable();
            ada1.Fill(data);
            con.Close();

            return data;
        }

        public DataTable showAllhistoArrivageBydate(DateTime dateArrivage)
        {
            string query = "SELECT * FROM histoArrivage  WHERE date_arrivage =@date  ";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@date", dateArrivage);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
    }
}
