using System.Data.SqlClient;
using System.Data;
using System;

namespace hotel_management_front.classes
{
    class client
    {

        //vars 
        public string firstName;
        public string lastName;
        public string sex;
        public DateTime birthDate;
        public string city;
        public string country;
        public int phoneNumber;
        public string status;
        public int CIN;
        public DateTime arrival_date;
        public DateTime departure_date;

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        // empty constructor 
        public client()
        {

        }

        //constructor
        public client(string name, string lname, string sex, DateTime birthdate, string city, string country, 
                        int phone, string status, int CIN, DateTime arrivalDate, DateTime departureDate)
        {
            this.firstName = name;
            this.lastName = lname;
            this.sex = sex;
            this.birthDate = birthdate;
            this.city = city;
            this.country = country;
            this.phoneNumber = phone;
            this.status = status;
            this.CIN = CIN;
            this.arrival_date = arrivalDate;
            this.departure_date = departureDate;

        }


        public string addClient()
        {
            // checking if an employee exists
            string query = "SELECT * FROM client WHERE name=@name AND lname=@pass";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", this.firstName);
            ada.SelectCommand.Parameters.AddWithValue("@pass", this.lastName);

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
                string query1 = "INSERT INTO client (name, lname, sex, birth_date, city, country, phone, status, CIN, arrival_date, departure_date) " +
                    "VALUES (@fname, @lname, @sex, @birthDate, @city, @country, @phone, @status, @CIN, @arrival_date, @departure_date)";

                SqlCommand com = new SqlCommand(query1, con);

                // params
                com.Parameters.AddWithValue("@fname", this.firstName);
                com.Parameters.AddWithValue("@lname", this.lastName);
                com.Parameters.AddWithValue("@sex", this.sex);
                com.Parameters.AddWithValue("@birthDate", this.birthDate);
                com.Parameters.AddWithValue("@city", this.city);
                com.Parameters.AddWithValue("@country", this.country);
                com.Parameters.AddWithValue("@phone", this.phoneNumber);
                com.Parameters.AddWithValue("@status", this.status);
                com.Parameters.AddWithValue("@CIN", this.CIN);
                com.Parameters.AddWithValue("@arrival_date", this.arrival_date);
                com.Parameters.AddWithValue("@departure_date", this.departure_date);




                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                return "Client added successfuly";
            }

        }

        // function that returns all the clients as a datatable
        public DataTable showAllClients()
        {
            string query = "SELECT * FROM client";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        public DataTable showAllHistorique()
        {
            string query = "SELECT * FROM historique";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        public void ajouterHistorique(string NomUtilisat, string typeAction, DateTime date)
        {
            string query = "INSERT INTO historique (type_action ,nom_utilisateur ,date_action)" + "VALUES (@Nom, @type, @date)";
            SqlCommand com = new SqlCommand(query, con);
            // params
            com.Parameters.AddWithValue("@Nom", NomUtilisat);
            com.Parameters.AddWithValue("@type", typeAction);
            com.Parameters.AddWithValue("@date", date);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        //search history log
        public DataTable searchHistorique(string HistoriqueSearch)
        {
            string query = "SELECT * FROM historique WHERE type_action Like '%" + HistoriqueSearch + "%' OR nom_utilisateur LIKE'%" + HistoriqueSearch + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
    }
}
