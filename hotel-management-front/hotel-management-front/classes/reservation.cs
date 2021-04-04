using System.Data.SqlClient;
using System.Data;
using System;

namespace hotel_management_front.classes
{
    class reservation
    {

        //vars 
        string Client_fullname;
        string roomName;
        DateTime checkin;
        DateTime checkout;
        int nbrDays;
        int totalAmount;
        string payementStatus;
        int verse;
        DateTime confirmDate;

        // empty constructor
        public reservation()
        {
        }

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        //filled constructor 
        public reservation(string fullname, string roomname, DateTime checkin, DateTime checkout, int nbrOfDays, int totalAmount, string payStatus, int versement, DateTime confirmation_date)
        {
            this.Client_fullname = fullname;
            this.roomName = roomname;
            this.checkin = checkin;
            this.checkout = checkout;
            this.nbrDays = nbrOfDays;
            this.totalAmount = totalAmount;
            this.payementStatus = payStatus;
            this.verse = versement;
            this.confirmDate = confirmation_date;
        }


        // add new reservation
        public string AddReservation()
        {
            // getting room ID 
            string query = "SELECT id_room FROM room WHERE name=@name";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            ada.SelectCommand.Parameters.AddWithValue("@name", this.roomName);
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            int roomID = int.Parse(dtbl.Rows[0]["id_room"].ToString());


            //// separating name and last name
            string[] fullname = this.Client_fullname.Split(' ');

            // getting client id 
            string query1 = "SELECT id_client FROM client WHERE name=@name AND lname=@lname";
            SqlDataAdapter ada1 = new SqlDataAdapter(query1, con);
            ada1.SelectCommand.Parameters.AddWithValue("@name", fullname[0]);
            ada1.SelectCommand.Parameters.AddWithValue("@lname", fullname[1]);
            DataTable dtbl1 = new DataTable();
            ada1.Fill(dtbl1);
            int clientID = int.Parse(dtbl1.Rows[0]["id_client"].ToString());


            // checking if the entered reservation exists already 
            string query2 = "SELECT * FROM reservation WHERE id_client=@clientID AND id_room=@roomID AND check_in=@checkin AND check_out=@checkout";
            SqlDataAdapter ada2 = new SqlDataAdapter(query2, con);
            ada2.SelectCommand.Parameters.AddWithValue("@clientID", clientID);
            ada2.SelectCommand.Parameters.AddWithValue("@roomID", roomID);
            ada2.SelectCommand.Parameters.AddWithValue("@checkin", this.checkin);
            ada2.SelectCommand.Parameters.AddWithValue("@checkout", this.checkout);
            DataTable dtbl2 = new DataTable();
            ada2.Fill(dtbl2);
            //user already exists 
            if (dtbl2.Rows.Count == 1)
            {
                return "Reservation already exists";
            }
            else
            {
                string query3 = "INSERT INTO reservation (id_client, id_room, check_in, check_out, nbr_days, total_amount, payement_status, versement, confirmation_date)" +
                            "VALUES (@clientID, @roomID, @checkin, @checkout, @nbrDays, @totalamount, @payementStatus, @versement, @confirmDate)";

                SqlCommand com = new SqlCommand(query3, con);

                // params
                com.Parameters.AddWithValue("@clientID", clientID);
                com.Parameters.AddWithValue("@roomID", roomID);
                com.Parameters.AddWithValue("@checkin", this.checkin);
                com.Parameters.AddWithValue("@checkout", this.checkout);
                com.Parameters.AddWithValue("@nbrDays", this.nbrDays);
                com.Parameters.AddWithValue("@totalamount", this.totalAmount);
                com.Parameters.AddWithValue("@payementStatus", this.payementStatus);
                com.Parameters.AddWithValue("@versement", this.verse);
                com.Parameters.AddWithValue("@confirmDate", this.confirmDate);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                // updating the room status in rooms table

                string query4 = "UPDATE room SET status='Reservee' WHERE id_room=@roomID";
                // params
                SqlCommand com2 = new SqlCommand(query4, con);
                com2.Parameters.AddWithValue("@roomID", roomID);

                con.Open();
                com2.ExecuteNonQuery();
                con.Close();
                return "Reservation added successfuly";
            }

        }

        // function that returns all the reservations as a datatable
        public DataTable showAllReservations()
        {
            string query = "SELECT client.name, client.lname, room.name AS rname, room.type, reservation.check_in, reservation.check_out, reservation.total_amount, reservation.payement_status, reservation.versement FROM reservation" +
                " INNER JOIN client ON reservation.id_client = client.id_client" +
                " INNER JOIN room ON reservation.id_room = room.id_room ";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }


        // used for the planning grid (takes a room name, and returns its info
        public DataTable showReservationByRoomName(string roomName)
        {
            string query = "SELECT client.name, client.lname, room.name AS rname, room.type, reservation.check_in, reservation.check_out, reservation.nbr_days,  reservation.total_amount, reservation.payement_status, reservation.versement FROM reservation " +               
                " INNER JOIN client ON reservation.id_client = client.id_client" +
                " INNER JOIN room ON reservation.id_room = room.id_room " +
                "WHERE room.name = @rname";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            ada.SelectCommand.Parameters.AddWithValue("@rname", roomName);
            
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            return dtbl;
        }


        // validate a new reservation ( moving to sejour )
        public string validateReservation(string clientName, string clientLname, string roomName, DateTime checkin, DateTime checkout, int total_amount, string payementStatus)
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
            string query2 = "SELECT * FROM sejour WHERE id_client=@clientID AND id_room=@roomID AND check_in=@checkin AND check_out=@checkout";
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
                return "Reservation already validated";
            }
            else
            {
                // inserting into the sejour table
                string query3 = "INSERT INTO sejour (id_client, id_room, check_in, check_out, total_amount, payement_status , nbr_days, isValidated)" +
                                " VALUES (@clientID, @roomID, @checkin, @checkout, @totalAmount, @payementStatus , @Nbdays, 'False')";
                //number of days
                DateTime start = checkin.Date;
                DateTime end = checkout.Date;
                var nbrDays = ((end - start).TotalDays + 1);
                SqlCommand com = new SqlCommand(query3, con);

                // params
                com.Parameters.AddWithValue("@clientID", clientID);
                com.Parameters.AddWithValue("@roomID", roomID);
                com.Parameters.AddWithValue("@checkin", checkin);
                com.Parameters.AddWithValue("@checkout", checkout);
                com.Parameters.AddWithValue("@totalAmount", total_amount);
                com.Parameters.AddWithValue("@payementStatus", payementStatus);
                com.Parameters.AddWithValue("@Nbdays", nbrDays);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                //removing from the reservation table
                string query4 = "DELETE FROM reservation WHERE id_client=@clientID AND id_room=@roomID AND check_in=@checkin AND check_out=@checkout";
                SqlCommand com1 = new SqlCommand(query4, con);
                com1.Parameters.AddWithValue("@clientID", clientID);
                com1.Parameters.AddWithValue("@roomID", roomID);
                com1.Parameters.AddWithValue("@checkin", checkin);
                com1.Parameters.AddWithValue("@checkout", checkout);

                con.Open();
                com1.ExecuteNonQuery();
                con.Close();

                return "reservation validated";
            }
        }
    
    }
}
