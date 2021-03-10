﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    class HistoriqueArticleChambreClass
    {
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);


        //VAR

        string nomchambre;
        DateTime date;
        string type;
        int IDsejour;
       

        public HistoriqueArticleChambreClass()
        {
        }
        public HistoriqueArticleChambreClass(string nomchamb, DateTime dateSej,  string typeChambre  , int idSej)
        {
            this.nomchambre = nomchamb;
            this.date = dateSej;
            this.type = typeChambre;
            this.IDsejour = idSej;

        }
        public string addHistorique()
        {
            // checking if an employee exists
          // string query = "SELECT * FROM HistoriqueArticleChambre WHERE Nom_chambre=@name AND date_sejour=@time";
            //SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            //ada.SelectCommand.Parameters.AddWithValue("@name", this.nomchambre);
            //ada.SelectCommand.Parameters.AddWithValue("@time", this.date);

            // command result 
            //DataTable dtbl = new DataTable();
            //ada.Fill(dtbl);
            //user already exists 
            //if (dtbl.Rows.Count == 1)
            //{
              //  return "Employee already exists";
            //}
           // else { 
                string query1 = "INSERT INTO HistoriqueArticleChambre (Nom_chambre, date_sejour, type ,id_sejour ) " +
                   "VALUES (@NomChambre, @Date, @Type ,@idSejour )";

            SqlCommand com = new SqlCommand(query1, con);

            // params
            com.Parameters.AddWithValue("@NomChambre", this.nomchambre);
            com.Parameters.AddWithValue("@Date", this.date);
            com.Parameters.AddWithValue("@Type", this.type);
           
            com.Parameters.AddWithValue("@idSejour", this.IDsejour);


                con.Open();
            com.ExecuteNonQuery();
            con.Close();
        //}
            return "Add";
        }
        public DataTable showAllhistoriqueChambre()
        {
            string query = "SELECT * FROM HistoriqueArticleChambre";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        public DataTable showIDsejour(DateTime date1, string nomChambre)
        {
            string query = "SELECT id_sejour FROM HistoriqueArticleChambre WHERE Nom_chambre=@nom AND date_sejour=@date";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@nom", nomChambre);
            ada.SelectCommand.Parameters.AddWithValue("@date", DateTime.Parse(date1.ToString()));
            // command result 
            DataTable data = new DataTable();
            ada.Fill(data);
            return data;

        }
        public DataTable showID(DateTime date1, string nomChambre)
        {
            string query = "SELECT ID_historiqueArticleChambre FROM HistoriqueArticleChambre WHERE Nom_chambre=@nom AND date_sejour=@date";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@nom", nomChambre);
            ada.SelectCommand.Parameters.AddWithValue("@date", DateTime.Parse(date1.ToString()));
            // command result 
            DataTable data = new DataTable();
            ada.Fill(data);
            return data;

        }
        public void remplirQuantity(int Idsejour , int Idhistorique ,int quant , string designationA) 
        {
            string query1 = "UPDATE HistoriqueArticleChambre SET quantity=@Quant , designation=@designationArticel WHERE id_sejour=@ID  ";

            SqlCommand com1 = new SqlCommand(query1, con);

            // params
            com1.Parameters.AddWithValue("@Quant", quant);
            com1.Parameters.AddWithValue("@designationArticel", designationA);
            com1.Parameters.AddWithValue("@ID", Idsejour);


            string query = "UPDATE HistoriqueArticleChambre SET quantity=@Quant , designation=@designationArticel WHERE id_sejour=@ID and ID_historiqueArticleChambre !=@idH ";
           
            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@Quant", quant);
            com.Parameters.AddWithValue("@designationArticel", designationA);
            com.Parameters.AddWithValue("@ID", Idsejour);
            com.Parameters.AddWithValue("@idH ", Idhistorique);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    } 
}
