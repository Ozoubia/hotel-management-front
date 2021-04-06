using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

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

        public user() { }

        // adding a new user 
        public string addUser()
        {
            //checking if a user exists

            string query = "SELECT * FROM users WHERE username=@name";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", this.username);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                return "User already exists";
            }
            else
            {
                string query1 = "INSERT INTO users (username, password, isActive) VALUES (@name, @pass, @state)";
                SqlCommand com = new SqlCommand(query1, con);
                com.Parameters.AddWithValue("@name", this.username);
                com.Parameters.AddWithValue("@pass", this.password);
                com.Parameters.AddWithValue("@state", true);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return "user added";
            }
        }

        // user login
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

        // function to get the permission for the loggedin user with the specific role ( exp : admin can add client ...)
        public List<string> GetUserPermissions()
        {
            List<string> permissionList = new List<string>();

            string userRole = getUserRole();

            string query = "SELECT actions.description FROM actions " +
                            "INNER JOIN roles_actions " +
                            "ON roles_actions.id_action = actions.id_action " +
                            "INNER JOIN roles " +
                            "ON roles.id_role = roles_actions.id_role " +
                            "WHERE roles.description =@roleDescription";


            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@roleDescription", userRole);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            // number of permissions found
            int nbrRows = int.Parse(dtbl.Rows.Count.ToString());
            // filling the permissions list
            
            for (int i = 0; i < nbrRows; i++)
            {
                string permission = dtbl.Rows[i]["description"].ToString();
                permissionList.Add(permission);
            }

            return permissionList;
        }

        // function to get the role for the logged in user ( exp : admin, recceptionist ...)
        public string getUserRole()
        {
            string query = "SELECT roles.description FROM roles " +
                "INNER JOIN users_roles " +
                "ON users_roles.id_role = roles.id_role " +
                "INNER JOIN users " +
                "ON users.id_user = users_roles.id_user " +
                "WHERE users.username = @user";


            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@user", this.username);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            // if user has a role
            int permNbr = int.Parse(dtbl.Rows.Count.ToString());
            if (permNbr == 1)
            {
                string role = dtbl.Rows[0]["description"].ToString();
                return role;
            }
            else
            {
                return "User doesn't have a role, contact administrator";
            }



            

            
        }

        #region used for permissions display in the settings
        // Same as the getUserRole but, with user name as parameters, instead of contructor variable.
        public string getUserRoleByName(string user)
        {
            string query = "SELECT roles.description FROM roles " +
                "INNER JOIN users_roles " +
                "ON users_roles.id_role = roles.id_role " +
                "INNER JOIN users " +
                "ON users.id_user = users_roles.id_user " +
                "WHERE users.username = @user";


            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@user", user);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            // if user has a role
            int permNbr = int.Parse(dtbl.Rows.Count.ToString());
            if (permNbr == 1)
            {
                string role = dtbl.Rows[0]["description"].ToString();
                return role;
            }
            else
            {
                return "User doesn't have a role, contact administrator";
            }

        }

        // function to get the permission for the loggedin user with the specific role ( exp : admin can add client ...)
        public List<string> GetUserPermissionsByRole(string userRole)
        {
            List<string> permissionList = new List<string>();

            string query = "SELECT actions.description FROM actions " +
                            "INNER JOIN roles_actions " +
                            "ON roles_actions.id_action = actions.id_action " +
                            "INNER JOIN roles " +
                            "ON roles.id_role = roles_actions.id_role " +
                            "WHERE roles.description =@roleDescription";


            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@roleDescription", userRole);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            // number of permissions found
            int nbrRows = int.Parse(dtbl.Rows.Count.ToString());
            // filling the permissions list

            for (int i = 0; i < nbrRows; i++)
            {
                string permission = dtbl.Rows[i]["description"].ToString();
                permissionList.Add(permission);
            }

            return permissionList;
        }

         #endregion

        // function that returns all users
        public DataTable showAllUsers()
        {
            string query = "SELECT * FROM users";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        // used for the modify function - it takes a user ID and returns its info
        public DataTable getUser(int userID)
        {
            // checking if an employee exists
            string query = "SELECT * FROM users WHERE id_user=@id";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@id", userID);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }

        // used to modify the user info
        public void modiftyUser(int userID, bool state)
        {
            string query = "UPDATE users SET username=@username, password=@password, isActive=@state WHERE id_user=@ID";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@ID", userID);
            com.Parameters.AddWithValue("@username", this.username);
            com.Parameters.AddWithValue("@password", this.password);
            com.Parameters.AddWithValue("@state", state);


            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //function that deletes a user by an ID
        public void deleteUser(string username)
        {
            string query = "DELETE FROM users WHERE username=@username";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@username", username);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        #region permissions
        //getting all the existing permissions
        public DataTable getAllPermissions()
        {
            string query = "SELECT description FROM actions";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        //get permission id by name
        public int getPermissionIDbyName(string name)
        {
            // checking if an employee exists
            string query = "SELECT id_action FROM actions WHERE description=@desc";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@desc", name);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            int perID = int.Parse(dtbl.Rows[0]["id_action"].ToString());

            return perID;
        }

     
        #endregion
    }
}
