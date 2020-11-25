using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
  public  class stats
    {
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public stats() 
        {
        }
        public DataTable countProduct(string localisation)
        {
            string query = "select count (*) AS ct from article  WHERE localisation=@local ";

            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@local", localisation);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
    }
}
