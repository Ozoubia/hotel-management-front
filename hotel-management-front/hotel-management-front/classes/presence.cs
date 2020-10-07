using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace hotel_management_front.classes
{
    class presence
    {

        string name;
        string lname;
        DateTime date;
        DateTime start_hour;
        DateTime end_hour;

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        //empty constructor 
        public presence()
        {
        }
        public presence(string name, string lname, DateTime date, DateTime stHour, DateTime endHour)
        {
            this.name = name;
            this.lname = lname;
            this.date = date;
            this.start_hour = stHour;
            this.end_hour = endHour;
        }
        // function that returns all the employees as a datatable
        public DataTable showAllEmployees1()
        {
            string query = "SELECT  name,lname,departement FROM employee";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        public string addPresence()
        {
            int idEmployee;

            //to get the employee id
            string query = "SELECT * FROM employee WHERE name=@name AND lname=@lname";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", this.name);
            ada.SelectCommand.Parameters.AddWithValue("@lname", this.lname);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            idEmployee = int.Parse(dtbl.Rows[0]["id_employee"].ToString());

            string query1 = "SELECT * FROM presence WHERE id_employee=@idemployee AND date=@date";
            SqlDataAdapter ada1 = new SqlDataAdapter(query1, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@date", this.date);
            ada.SelectCommand.Parameters.AddWithValue("@idemploye", idEmployee);


            // command result 
            DataTable dtb2 = new DataTable();
            ada.Fill(dtb2);
            //user already exists 
            if (dtb2.Rows.Count == 1)
            {
                return "Presence already exists";
            }
            else
            {
                string query2 = "INSERT INTO presence (id_employee , date  , start_hour , end_hour) " + "VALUES (@idemp , @date , @starhour , @endhour)";
                SqlCommand com = new SqlCommand(query2, con);

                //params             
                com.Parameters.AddWithValue("@idemp", idEmployee);
                com.Parameters.AddWithValue("@date", this.date);
                com.Parameters.AddWithValue("@starhour", this.start_hour);
                com.Parameters.AddWithValue("@endhour", this.end_hour);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                return "Presence inserted";
            }

            
        }
        public DataTable searchEmployee(string EmployeeSearch)
        {
            string query = "SELECT * FROM employee WHERE name Like '%" + EmployeeSearch + "%' OR lname LIKE'%" + EmployeeSearch + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        public DataTable showPresenceList()
        {
            string query = "SELECT presence.date, employee.name, employee.lname, presence.start_hour, presence.end_hour FROM presence INNER JOIN employee ON presence.id_employee = employee.id_employee";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            DataTable data = new DataTable();
            adapt.Fill(data);

            return data;
        }
    }
    
  }

    
