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
        int Id;
        int idEmployee;
        int idPresence;
        DateTime date;
        DateTime start_hour;
        DateTime end_hour;
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        //empty constructor 
        public presence()
        {
        }
        public presence(int idpes, DateTime date, DateTime stHour, DateTime endHour)
        {
            this.idPresence = idpes;
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
        public string addPresence(string nom , string prenom  , int employeeID)
        {
            //pour récupérer id 
            string query = "SELECT * FROM employee WHERE name=@nom AND lname=@prenom";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", nom);
            ada.SelectCommand.Parameters.AddWithValue("@pass", prenom);

            // command result 
           DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
             Id = int.Parse((string)dtbl.Rows[employeeID][idEmployee]);

            string query1 = "SELECT * FROM presence WHERE id_presence=@idpresence; AND id_employee=@idemployee";
            SqlDataAdapter ada1 = new SqlDataAdapter(query1, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@idPresence", idPresence);
            ada.SelectCommand.Parameters.AddWithValue("@idemploye", idEmployee);


            // command result 
            DataTable dtb2 = new DataTable();
            ada.Fill(dtb2);
            //user already exists 
            if (dtb2.Rows.Count == 1)
            {
                return "Employee already exists";
            }
            else
            {
               // string query2 = "INSERT INTO presence (id_presence , id_employee , date  , start_hour , end_hour) " + "VALUES (@idpres , @idemp , @date , @starhour , @endhour)";

            }
               // SqlCommand com = new SqlCommand(query2, con);

            // params
           // com.Parameters.AddWithValue("@idpres", this.idPresence);
           // com.Parameters.AddWithValue("@idemp", this.Id);
           // com.Parameters.AddWithValue("@date", this.date);
           // com.Parameters.AddWithValue("@starhour",this.start_hour);
           // com.Parameters.AddWithValue("@endhour",this.end_hour);
            
            return "";
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
    }
    
  }

    
