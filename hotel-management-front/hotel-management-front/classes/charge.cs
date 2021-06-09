using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    class charge
    {
        //vars
        public string type;
        public DateTime date;
        public int price;

        //empty constructor
        public charge() { }

        //empty constructor
        public charge(string ctype, DateTime cdate, int cprice) 
        {
            this.type = ctype;
            this.date = cdate;
            this.price = cprice;
        }

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public string addCharge()
        {
            // inseting into the historique Article
            string query6 = "INSERT INTO charge ( date, type, price ) VALUES (@date, @type, @price)" ;
            SqlCommand com2 = new SqlCommand(query6, con);
            // params
            com2.Parameters.AddWithValue("@date", this.date);
            com2.Parameters.AddWithValue("@type", this.type);
            com2.Parameters.AddWithValue("@price", this.price);

            con.Open();
            com2.ExecuteNonQuery();
            con.Close();

            return "Charge inserted successfully";
        }

        public DataTable showAllCharges()
        {
            // checking if an employee exists
            string query = "SELECT type, date, price FROM charge ";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
        public void diminuerCaisse(int somme)
        {
            
            string query1 = "INSERT INTO caisseHot (somme , date) VALUES (@somme, @date)";


            SqlCommand com = new SqlCommand(query1, con);

            // params
            com.Parameters.AddWithValue("@somme", somme * -1);
            com.Parameters.AddWithValue("@date", DateTime.Today);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }


}
