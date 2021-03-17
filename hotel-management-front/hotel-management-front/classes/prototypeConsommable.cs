﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    class prototypeConsommable
    {

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        //VAR
        string designation;
        int quantity_Consommable;
        string type_Consommable;
        bool checke;
        public prototypeConsommable() 
        {
        }
        public prototypeConsommable(string designationD, int quantity, string typeDej, bool check)
        {
            this.designation = designationD;
            this.quantity_Consommable = quantity;
            this.type_Consommable = typeDej;
            this.checke = check;
        }
        public string addprototype()
        {
            // checking if an employee exists
            string query = "SELECT * FROM prototypeConsommable WHERE designation=@designationD AND type_consomable=@type";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@designationD", this.designation);
            ada.SelectCommand.Parameters.AddWithValue("@type", this.type_Consommable);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                return "Type already exists";
            }
            else
            {
                string query1 = "INSERT INTO prototypeConsommable (designation, quantity_consomable, type_consomable, checked) " +
                  "VALUES (@designationD, @quantity, @type, @check)";

                SqlCommand com = new SqlCommand(query1, con);

                // params
                com.Parameters.AddWithValue("@designationD", this.designation);
                com.Parameters.AddWithValue("@quantity", this.quantity_Consommable);
                com.Parameters.AddWithValue("@type", this.type_Consommable);
                com.Parameters.AddWithValue("@check", this.checke);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                return "prototype added successfuly";
            }
           
        }
        public DataTable showAllprototype()
        {
            string query = "SELECT * FROM prototypeConsommable";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        public List<string> showAllprototypeDesgnition()
        {
            List<string> designationList = new List<string>();
            string query = "SELECT designation FROM prototypeConsommable";
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
                string permission = data.Rows[i]["designation"].ToString();
                designationList.Add(permission);
            }

            return designationList;
        }
        public DataTable showAllprototypeByType(string typeD)
        {
            string query = "SELECT * FROM prototypeConsommable WHERE type_consomable=@type";

            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@type", typeD);

            // command result 
            DataTable data = new DataTable();
            ada.Fill(data);

            return data;
        }
    }
}
