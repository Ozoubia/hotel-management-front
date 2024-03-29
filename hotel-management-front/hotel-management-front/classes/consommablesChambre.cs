﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{

    class consommablesChambre
    {
        //VAR
        int quantityConsommable;
        string designationConsommable;
        string referenceConsommable;
        double prixMoyen;
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public consommablesChambre()
        {
        }
        public consommablesChambre(int quantite, string designation, string reference ,double prix)
        {
            this.quantityConsommable = quantite;
            this.designationConsommable = designation;
            this.referenceConsommable = reference;
            this.prixMoyen = prix;
        }
        public void addconsommablesChambre()
        {
            {
                // checking if an employee exists
                string query = "SELECT * FROM consommablesChambre WHERE reference_consommable=@reference_C";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                //query parameters 
                ada.SelectCommand.Parameters.AddWithValue("@reference_C", this.referenceConsommable);

                // command result 
                DataTable dtbl = new DataTable();
                ada.Fill(dtbl);
                //user already exists 
                if (dtbl.Rows.Count < 1)
                {
                    // inseting into the general stock
                    string query2 = "INSERT INTO consommablesChambre (quantity_consommable ,designation_consommable ,reference_consommable ,prix_moyen ) " +
                        "VALUES ( 0,@designation, @reference ,@prix)";

                    SqlCommand com = new SqlCommand(query2, con);

                    // params
                    com.Parameters.AddWithValue("@quantity", this.quantityConsommable);
                    com.Parameters.AddWithValue("@designation", this.designationConsommable);
                    com.Parameters.AddWithValue("@reference", this.referenceConsommable);
                    com.Parameters.AddWithValue("@prix", this.prixMoyen);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }



            }


        }
        public DataTable showAllconsommablesChambre()
        {
            string query = "SELECT * FROM consommablesChambre";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        public void supprimerConsommablesChambre(string Designation)

        {
            string query = "SELECT * FROM consommablesChambre WHERE designation_consommable=@Designation";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@Designation", Designation);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                string query1 = "DELETE FROM consommablesChambre WHERE designation_consommable =@Designation";
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.Parameters.AddWithValue("@Designation", Designation);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }


        }
        public List<string> showConsomable()
        {
            List<string> designationList = new List<string>();
            string query = "(Select designation_consommable from consommablesChambre) Except (Select designation from prototypeConsommable)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            // number of permissions found
            int nbrRows = int.Parse(data.Rows.Count.ToString());
            // filling the permissions list
            for (int i = 0; i < nbrRows; i++)
            {
                string permission = data.Rows[i]["designation_consommable"].ToString();
                designationList.Add(permission);
            }

            return designationList;
        }
        public void modiftyPrixMoyen(string Designa, double quant)
        {
            string query = "UPDATE consommablesChambre SET prix_moyen=@prix WHERE designation_consommable=@Designa";
            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@prix", quant);
            com.Parameters.AddWithValue("@Designa", Designa);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataTable SelcetPrixMoyen(string disignation)
        {
            string query = "SELECT prix_moyen FROM consommablesChambre WHERE designation_consommable=@Designa";

            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@Designa", disignation);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
    }
}
