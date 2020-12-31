using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    public class Notification
    {

        //Var
        public string description;
        public DateTime date_notification;

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public Notification() 
        {

        }
        public void addNotification( int IDarticle) 
        {
            string query1 = "INSERT INTO notification (description , date_notification , id_article) " + "VALUES (@descrip, @date, @id)";
            SqlCommand com = new SqlCommand(query1, con);

            // params
            com.Parameters.AddWithValue("@descrip", this.description);
            com.Parameters.AddWithValue("@date", this.date_notification);
            com.Parameters.AddWithValue("@id", IDarticle);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }

    }
}
