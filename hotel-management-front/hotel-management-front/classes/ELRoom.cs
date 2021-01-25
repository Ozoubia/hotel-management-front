using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Media.Animation;

namespace hotel_management_front.classes
{
    class ELRoom
    {
        //// vars
        //int roomID;


        public ELRoom() { }

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        // used to get the color value
        public DataTable getColorValue(string material, int roomID)
        {
            // checking if an employee exists
            string query = "SELECT " + material + " FROM etat_lieu_room WHERE id_room=@roomID";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@roomID", roomID);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }

        //used to change the color value aka: change the state of the button 
        public void changeColorValue(string material, int roomID, int value)
        {
            // query 
            string query = "UPDATE etat_lieu_room SET " + material + " =" + value + "WHERE id_room=@id_room";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@id_room", roomID);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        // used to init the roomID to 0 of a specific room
        public void addRoomIDELRoom(string roomName)
        {
            //getting room entered room ID 
            room roomObj = new room();
            DataTable result = roomObj.showRoomIDByName(roomName);
            int roomID = int.Parse(result.Rows[0]["id_room"].ToString());

            // add attribute to room
            string query = "INSERT INTO etat_lieu_room (id_room) VALUES (@roomID)";
            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@roomID", roomID);           

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        // used for the room etat lieu
        public DataTable showRoomInELRoom(int roomID)
        {
            // checking if an employee exists
            string query = "SELECT * FROM etat_lieu_room WHERE id_room=@id_room";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@id_room", roomID);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }

        // add attribute to etat de lieu room class
        public void addELAttribute(string designation)
        {
            // add attribute to room
            string query3 = "ALTER TABLE etat_lieu_room ADD " + designation + " INT NOT NULL DEFAULT(0)";
            SqlCommand com3 = new SqlCommand(query3, con);

            con.Open();
            com3.ExecuteNonQuery();
            con.Close();
        }

        //removing the attribute 
        public void removeELAttribute(string designation)
        {
            // add attribute to room
            string query3 = "ALTER TABLE etat_lieu_room DROP COLUMN " + designation;
            SqlCommand com3 = new SqlCommand(query3, con);

            con.Open();
            com3.ExecuteNonQuery();
            con.Close();
        }
    }
}
