using System.Data.SqlClient;
using System.Data;
using System;


namespace hotel_management_front.classes
{
    class room
    {

        //vars 
        string room_name;
        string type;
        int base_price;
        string status;
        bool isCleaned;

        //empty constructor
        public room() { }

        //constructor 
        public room(string name, string type, int price, string status, bool isCleaned)
        {
            this.room_name = name;
            this.type = type;
            this.base_price = price;
            this.status = status;
            this.isCleaned = isCleaned;
        }

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public string addRoom()
        {
            // checking if an employee exists
            string query = "SELECT * FROM room WHERE name=@name";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", this.room_name);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                return "Room already exists";
            }
            else
            {
                string query1 = "INSERT INTO room (name, type, base_price, status, isCleaned) " +
                    "VALUES (@name, @type, @price, @status, @isCleaned)";

                SqlCommand com = new SqlCommand(query1, con);

                // params
                com.Parameters.AddWithValue("@name", this.room_name);
                com.Parameters.AddWithValue("@type", this.type);
                com.Parameters.AddWithValue("@price", this.base_price);
                com.Parameters.AddWithValue("@status", this.status);
                com.Parameters.AddWithValue("@isCleaned", this.isCleaned);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                return "Room added successfuly";
            }

        }

        // function that returns all the rooms as a datatable
        public DataTable showAllRooms()
        {
            string query = "SELECT * FROM room";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        // function that returns all the available rooms as a datatable
        public DataTable showAllAvailableRooms()
        {
            string query = "SELECT * FROM room WHERE status='libre'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        // used for the reservation price calculating

        public DataTable showRoomPrice(string roomName)
        {
            // checking if an employee exists
            string query = "SELECT base_price FROM room WHERE name=@name";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", roomName);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
    }
}
