using System.Data.SqlClient;
using System.Data;

namespace hotel_management_front.classes
{
    public class user
    {
        //vars 
        public string username;
        public string password;

        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public user(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool login()
        {            
            string query = "SELECT * FROM users WHERE username=@name AND password=@pass";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", username);
            ada.SelectCommand.Parameters.AddWithValue("@pass", password);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
