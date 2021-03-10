using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    public class typeChambre
    {
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        //VAR
        public string typeChambr;
        public typeChambre()
        {
        }
        public typeChambre(string typeChamb)
        {
            this.typeChambr = typeChamb;
        }
        public string addTypeChambre()
        {
            // checking if an employee exists
            string query = "SELECT * FROM typeChambre WHERE typeChambre=@typeChamb ";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@typeChamb", this.typeChambr);


            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                return "Client already exists";
            }
            else
            {
                string query1 = "INSERT INTO typeChambre (typeChambre)" + "VALUES(@type)";

                SqlCommand com = new SqlCommand(query1, con);

                // params
                com.Parameters.AddWithValue("@type", this.typeChambr);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                return "typeChambre added successfuly";
            }

        }
        public DataTable showAllTypes()
        {
            string query = "SELECT * FROM typeChambre";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

    }
}