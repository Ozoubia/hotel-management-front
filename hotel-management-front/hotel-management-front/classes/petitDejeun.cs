using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    public class petitDejeun
    {
        //VAR 
        int quantity_petitDejeun;
        string designation_PetitD;
        string reference_PetitD;
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public petitDejeun()
        {

        }

        public petitDejeun(int quantity_petitD, string designation_P, string reference_P)
        {
            this.quantity_petitDejeun = quantity_petitD;
            this.designation_PetitD = designation_P;
            this.reference_PetitD = reference_P;
        }
        public void addPetitDejeun()
        {
            {
                // checking if an employee exists
                string query = "SELECT * FROM petitDejeun WHERE reference_PetitD=@reference_P";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                //query parameters 
                ada.SelectCommand.Parameters.AddWithValue("@reference_P", this.reference_PetitD);

                // command result 
                DataTable dtbl = new DataTable();
                ada.Fill(dtbl);
                //user already exists 
                if (dtbl.Rows.Count < 1)
                {
                    // inseting into the general stock
                    string query2 = "INSERT INTO petitDejeun (quantity_petitDejeun ,designation_PetitD ,reference_PetitD ) " +
                        "VALUES ( 0,@designation, @reference)";

                    SqlCommand com = new SqlCommand(query2, con);

                    // params
                    com.Parameters.AddWithValue("@quantity", this.quantity_petitDejeun);
                    com.Parameters.AddWithValue("@designation", this.designation_PetitD);
                    com.Parameters.AddWithValue("@reference", this.reference_PetitD);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }



            }

        }
        public DataTable showAllpetitDejeun()
        {
            string query = "SELECT * FROM petitDejeun";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        public List<string> schowAlldesignation()
        {
            List<string> designationList = new List<string>();
            string query = "SELECT designation_PetitD FROM petitDejeun";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);

            // number of permissions found
            int nbrRows = int.Parse(data.Rows.Count.ToString());
            // filling the permissions list
            for (int i = 0; i < nbrRows; i++)
            {
                string permission = data.Rows[i]["designation_PetitD"].ToString();
                designationList.Add(permission);
            }

            return designationList;
        }
        //fonction afficher les designation qui existent dans le table petitDejeun" il n'existe pas de le table prototype
        public List<string> showDejeun()
        {
            List<string> designationList = new List<string>();
            string query = "(Select designation_PetitD from petitDejeun) Except (Select designation from prototype)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            // number of permissions found
            int nbrRows = int.Parse(data.Rows.Count.ToString());
            // filling the permissions list
            for (int i = 0; i < nbrRows; i++)
            {
                string permission = data.Rows[i]["designation_PetitD"].ToString();
                designationList.Add(permission);
            }

            return designationList;
        }
        public void dpetitDejeun(string Designation)

        {
            string query = "SELECT * FROM petitDejeun WHERE designation_PetitD=@Designation";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@Designation", Designation);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                string query1 = "DELETE FROM petitDejeun WHERE designation_PetitD =@Designation";
                SqlCommand cmd = new SqlCommand(query1, con);

                cmd.Parameters.AddWithValue("@Designation", Designation);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

           
        }
        public DataTable showDesignation()
        {
            string query = "SELECT designation_PetitD FROM petitDejeun";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

    }
}
