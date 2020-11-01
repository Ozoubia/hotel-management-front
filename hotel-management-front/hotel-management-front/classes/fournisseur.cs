using System.Data.SqlClient;
using System.Data;
using System;

namespace hotel_management_front.classes
{
    class fournisseur
    {

        // vars
        string name;
        string lname;
        string adress;
        string country;
        string city;
        int phone;
        string email;
        int credit;


        // empty constructor 
        public fournisseur() { }
        
        // filled constructor
        public fournisseur(string fname, string flname, string faddress, string fcountry, string fcity, int fphone, string femail, int fcredit)
        {
            this.name = fname;
            this.lname = flname;
            this.adress = faddress;
            this.country = fcountry;
            this.city = fcity;
            this.phone = fphone;
            this.email = femail;
            this.credit = fcredit;

        }

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public String AddFournisseur()
        {
            // checking if an employee exists
            string query = "SELECT * FROM fournisseur WHERE name=@name AND lname=@lname";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", this.name);
            ada.SelectCommand.Parameters.AddWithValue("@lname", this.lname);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                return "Fournisseur already exists";
            }
            else
            {
                string query1 = "INSERT INTO fournisseur (name, lname, adress, country, city, telephone, email, credit) " +
                    "VALUES (@fname, @lname, @adress, @country, @city, @telephone, @email, @credit)";

                SqlCommand com = new SqlCommand(query1, con);

                // params
                com.Parameters.AddWithValue("@fname", this.name);
                com.Parameters.AddWithValue("@lname", this.lname);
                com.Parameters.AddWithValue("@adress", this.adress);
                com.Parameters.AddWithValue("@country", this.country);
                com.Parameters.AddWithValue("@city", this.city);
                com.Parameters.AddWithValue("@telephone", this.phone);
                com.Parameters.AddWithValue("@email", this.email);
                com.Parameters.AddWithValue("@credit", this.credit);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                return "fournisseur added successfuly";
            }
        }

        // function that returns all the fournisseurs as a datatable
        public DataTable showAllFournisseurs()
        {
            string query = "SELECT * FROM fournisseur";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        
    }  
}
