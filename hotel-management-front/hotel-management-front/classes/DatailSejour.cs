﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    class DatailSejour
    {
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);


        //VAR
        int idSejour;
        DateTime date;
        bool isValidated;
        public DatailSejour() 
        { 
        }
        public DatailSejour(int idSej , DateTime time , bool isVal)
        {
            this.idSejour = idSej;
            this.date = time;
            this.isValidated = isVal;

        }
        public string addDatialSejour() 

        {
            string query = "SELECT * FROM DatailSejour WHERE data_Sejour=@date AND id_Sejour=@ID  ";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@date", this.date);
            ada.SelectCommand.Parameters.AddWithValue("@ID", this.idSejour);


            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count < 1)
            
            
            {
                string query1 = "INSERT INTO DatailSejour (id_Sejour , data_Sejour , is_Validated) " +
                "VALUES (@id, @date, @isVal )";

                SqlCommand com = new SqlCommand(query1, con);

                // params
                com.Parameters.AddWithValue("@id", this.idSejour);
                com.Parameters.AddWithValue("@date", this.date);
                com.Parameters.AddWithValue("@isVal", this.isValidated);



                con.Open();
                com.ExecuteNonQuery();
                con.Close();
               
            }
            return "aaaaa";
        }
          public void modifierQuantite(int idSje , DateTime time)
        {
            string query1 = " UPDATE DatailSejour SET is_Validated = 'true'  WHERE id_sejour = @ID AND data_Sejour= @dateSejour ";
            SqlCommand com1 = new SqlCommand(query1, con);

            // params
            com1.Parameters.AddWithValue("@ID", idSje );
            com1.Parameters.AddWithValue("@dateSejour", time);



            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
        }
    }
}
