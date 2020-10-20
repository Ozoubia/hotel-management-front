using System.Data.SqlClient;
using System.Data;
using System;


namespace hotel_management_front.classes
{
    class histoArrivee
    {
        public histoArrivee() { }

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        // returing all sejour items in the table
        public DataTable showHistoArriveeList()
        {
            string query = "SELECT client.name, client.lname, room.name AS rname, room.type, histoArrivee.check_in, histoArrivee.check_out, histoArrivee.total_amount, histoArrivee.payement_status FROM histoArrivee" +
                " INNER JOIN client ON histoArrivee.id_client = client.id_client" +
                " INNER JOIN room ON histoArrivee.id_room = room.id_room ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
    }
}
