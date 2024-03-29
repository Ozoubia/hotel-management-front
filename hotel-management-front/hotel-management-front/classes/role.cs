﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{

    class role
    {
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        //vars 
        public string description;

        //constructor
        public role(string description)
        {
            this.description = description;
        }

        //empty constructor
        public role() { }

        // add new role
        public string addRole()
        {
            //checking if a user exists

            string query = "SELECT * FROM roles WHERE description=@desc";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@desc", this.description);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //role already exists 
            if (dtbl.Rows.Count == 1)
            {
                return "Role already exists";
            }
            else
            {
                string query1 = "INSERT INTO roles (description) VALUES (@desc)";
                SqlCommand com = new SqlCommand(query1, con);
                com.Parameters.AddWithValue("@desc", this.description);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return "Role added";
            }
        }

        // function that returns all roles
        public DataTable showAllRoles()
        {
            string query = "SELECT * FROM roles";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        // getting the role by its name
        public DataTable getRoleIdByName(string name)
        {
            string query = "SELECT id_role from roles WHERE description=@desc";


            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@desc", name);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }

        // used to modify the role 
        public void modiftyRole(string description, string newDescription)
        {
            string query = "UPDATE roles SET description=@newDesc WHERE description=@desc";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@desc", description);
            com.Parameters.AddWithValue("@newDesc", newDescription);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        // used to delete the role 
        public void deleteRole(string description)
        {
            string query = "DELETE FROM roles WHERE description=@desc";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@desc", description);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //giving a role a permission
        public void giveRolePermission(int roleID, int perID)
        {
            string query = "INSERT INTO roles_actions(id_role, id_action) VALUES (@roleID, @permID)";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@roleID", roleID);
            com.Parameters.AddWithValue("@permID", perID);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void takeOffRolePermission(int roleID, int perID)
        {
            string query = "DELETE FROM roles_actions WHERE id_role=@roleID AND id_action=@permID";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@roleID", roleID);
            com.Parameters.AddWithValue("@permID", perID);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
