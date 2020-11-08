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

    }
}
