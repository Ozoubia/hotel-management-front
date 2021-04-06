using System.Data.SqlClient;
using System.Data;
using System;

namespace hotel_management_front.classes
{
    class sejour
    {

        public sejour()
        {

        }

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        // validate a new reservation ( moving to sejour )
        public string terminateReservation(string clientName, string clientLname, string roomName, DateTime checkin, DateTime checkout, int total_amount, string payementStatus)
        {

            // getting room ID 
            string query = "SELECT id_room FROM room WHERE name=@name";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            ada.SelectCommand.Parameters.AddWithValue("@name", roomName);
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            int roomID = int.Parse(dtbl.Rows[0]["id_room"].ToString());

            // getting client id 
            string query1 = "SELECT id_client FROM client WHERE name=@name AND lname=@lname";
            SqlDataAdapter ada1 = new SqlDataAdapter(query1, con);
            ada1.SelectCommand.Parameters.AddWithValue("@name", clientName);
            ada1.SelectCommand.Parameters.AddWithValue("@lname", clientLname);
            DataTable dtbl1 = new DataTable();
            ada1.Fill(dtbl1);
            int clientID = int.Parse(dtbl1.Rows[0]["id_client"].ToString());


            // checking if the entered reservation exists already 
            string query2 = "SELECT * FROM histoArrivee WHERE id_client=@clientID AND id_room=@roomID AND check_in=@checkin AND check_out=@checkout";
            SqlDataAdapter ada2 = new SqlDataAdapter(query2, con);
            ada2.SelectCommand.Parameters.AddWithValue("@clientID", clientID);
            ada2.SelectCommand.Parameters.AddWithValue("@roomID", roomID);
            ada2.SelectCommand.Parameters.AddWithValue("@checkin", checkin);
            ada2.SelectCommand.Parameters.AddWithValue("@checkout", checkout);
            DataTable dtbl2 = new DataTable();
            ada2.Fill(dtbl2);
            //user already exists 
            if (dtbl2.Rows.Count == 1)
            {
                return "Historique already exists";
            }
            else
            {
                // inserting into the sejour table
                string query3 = "INSERT INTO histoArrivee (id_client, id_room, check_in, check_out, total_amount, payement_status)" +
                                " VALUES (@clientID, @roomID, @checkin, @checkout, @totalAmount, @payementStatus)";

                SqlCommand com = new SqlCommand(query3, con);

                // params
                com.Parameters.AddWithValue("@clientID", clientID);
                com.Parameters.AddWithValue("@roomID", roomID);
                com.Parameters.AddWithValue("@checkin", checkin);
                com.Parameters.AddWithValue("@checkout", checkout);
                com.Parameters.AddWithValue("@totalAmount", total_amount);
                com.Parameters.AddWithValue("@payementStatus", payementStatus);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                //removing from the reservation table
                string query4 = "DELETE FROM sejour WHERE id_client=@clientID AND id_room=@roomID AND check_in=@checkin AND check_out=@checkout";
                SqlCommand com1 = new SqlCommand(query4, con);
                com1.Parameters.AddWithValue("@clientID", clientID);
                com1.Parameters.AddWithValue("@roomID", roomID);
                com1.Parameters.AddWithValue("@checkin", checkin);
                com1.Parameters.AddWithValue("@checkout", checkout);

                con.Open();
                com1.ExecuteNonQuery();
                con.Close();

                return "Historique added";
            }
        }


        // returing all sejour items in the table
        public DataTable showSejourList()
        {
            string query = "SELECT client.name, client.lname, room.name AS rname, room.type,sejour.id_sejour, sejour.check_in, sejour.check_out, sejour.total_amount, sejour.payement_status , sejour.nbr_days FROM sejour" +
                " INNER JOIN client ON sejour.id_client = client.id_client" +
                " INNER JOIN room ON sejour.id_room = room.id_room ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        //updating the isValidated variabe each day ( at 1 am ) 
        public void resetIsValidated()
        {
            // inserting into the sejour table
            string query3 = "UPDATE sejour SET isValidated='False'";

            SqlCommand com = new SqlCommand(query3, con);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
