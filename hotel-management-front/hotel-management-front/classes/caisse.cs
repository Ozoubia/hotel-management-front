using System.Data.SqlClient;
using System.Data;
using System;

namespace hotel_management_front.classes
{
    class caisse
    {

        public caisse() { }

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        //aliment somme into the entered caisse
        public void alimenter(string caisseName, int somme)
        {
            string query1 = "INSERT INTO " + caisseName + " (somme, date) " +
                    "VALUES (@somme, @date)";

            SqlCommand com = new SqlCommand(query1, con);

            // params
            com.Parameters.AddWithValue("@somme", somme);
            com.Parameters.AddWithValue("@date", DateTime.Today);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        // to show caisses sommes
        public int totalCaisseBan()
        {
            string query = "select SUM(somme) as somme from caisseBan";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            con.Close();
            int somme = int.Parse(data.Rows[0]["somme"].ToString());
            return somme;
        }

        public int totalCaissePer()
        {
            string query = "select SUM(somme) as somme from caissePer";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            con.Close();
            int somme = int.Parse(data.Rows[0]["somme"].ToString());
            return somme;
        }

        public int totalCaisseHot()
        {
            string query = "select SUM(somme) as somme from caisseHot";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            con.Close();
            int somme = int.Parse(data.Rows[0]["somme"].ToString());
            return somme;
        }

        // transaction from caissse to another caisse
        public void transaction(string fromCaisse, string toCaisse, int somme)
        {   
            // from transaction
            string query1 = "INSERT INTO " + fromCaisse + " (somme, date) " +
                    "VALUES (@somme, @date)";

            SqlCommand com = new SqlCommand(query1, con);

            // params
            com.Parameters.AddWithValue("@somme", somme * -1);
            com.Parameters.AddWithValue("@date", DateTime.Today);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            // to transaction
            string query2 = "INSERT INTO " + toCaisse + " (somme, date) " +
                    "VALUES (@somme, @date)";

            SqlCommand com2 = new SqlCommand(query2, con);

            // params
            com2.Parameters.AddWithValue("@somme", somme);
            com2.Parameters.AddWithValue("@date", DateTime.Today);

            con.Open();
            com2.ExecuteNonQuery();
            con.Close();
        }
    }
}
