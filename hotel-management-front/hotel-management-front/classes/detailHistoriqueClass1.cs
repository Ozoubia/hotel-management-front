using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    class detailHistoriqueClass1
    {
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        //VAR
        int quantite;
        string desination;
        public detailHistoriqueClass1()
        {
        }
        public detailHistoriqueClass1(int qun, string design)
        {
            this.quantite = qun;
            this.desination = design;

        }
        public string adddetail()
        {
            // checking if an employee exists
            string query = "SELECT * FROM detailHisto WHERE designation=@desig ";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@desig", this.desination);


            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                return "detail already exists";
            }
            else
            {
                string query1 = "INSERT INTO detailHisto (quantity, designation ) " +
                    "VALUES (@quantite, @designat)";

                SqlCommand com = new SqlCommand(query1, con);

                // params
                com.Parameters.AddWithValue("@quantite", this.quantite);
                com.Parameters.AddWithValue("@designat", this.desination);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            return "add";
        }
    }
}
