using System.Data.SqlClient;
using System.Data;
using System;

namespace hotel_management_front.classes
{
    public class employee
    {

        //vars 
        public string firstName;
        public string lastName;
        public string sex;
        public DateTime birthDate;
        public string city;
        public string country;
        public int phoneNumber;
        public int CIN;
        public string status;
        public int kidsNbr;
        public int CNSS;
        public string department;
        public string jobTitle;
        public int baseSalary;
        public DateTime startDate;
        public DateTime endDate;


        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        //empty constructor 
        public employee()
        {
        }

        //Constructor
        public employee(string fname, string lname, string sex, DateTime birth_date, string city, string country, int phone, int CIN, string status, 
                        int kidsNbr, int CNSS, string department, string jobTitle, int baseSalary, DateTime startDate, DateTime endDate)
        {
            this.firstName = fname;
            this.lastName = lname;
            this.sex = sex;
            this.birthDate = birth_date;
            this.city = city;
            this.country = country;
            this.phoneNumber = phone;
            this.CIN = CIN;
            this.status = status;
            this.kidsNbr = kidsNbr;
            this.CNSS = CNSS;
            this.department = department;
            this.jobTitle = jobTitle;
            this.baseSalary = baseSalary;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public string addEmployee()
        {
            // checking if an employee exists
            string query = "SELECT * FROM employee WHERE name=@name AND lname=@pass";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@name", firstName);
            ada.SelectCommand.Parameters.AddWithValue("@pass", lastName);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                return "Employee already exists";
            }
            else
            {
                string query1 = "INSERT INTO employee (name, lname, sex, birth_date, city, country, telephone, CIN, status, nbr_kids, CNSS, departement, job_title, base_salary, starting_date, ending_date) " +
                    "VALUES (@fname, @lname, @sex, @birthDate, @city, @country, @phone, @CIN, @status, @nbrKids, @CNSS, @departement, @jobTitle, @baseSalary, @startingDate, @endingDate)";
                
                SqlCommand com = new SqlCommand(query1, con);

                // params
                com.Parameters.AddWithValue("@fname", this.firstName);
                com.Parameters.AddWithValue("@lname", this.lastName);
                com.Parameters.AddWithValue("@sex", this.sex);
                com.Parameters.AddWithValue("@birthDate", this.birthDate);
                com.Parameters.AddWithValue("@city", this.city);
                com.Parameters.AddWithValue("@country", this.country);
                com.Parameters.AddWithValue("@phone", this.phoneNumber);
                com.Parameters.AddWithValue("@CIN", this.CIN);
                com.Parameters.AddWithValue("@status", this.status);
                com.Parameters.AddWithValue("@nbrKids", this.kidsNbr);
                com.Parameters.AddWithValue("@CNSS", this.CNSS);
                com.Parameters.AddWithValue("@departement", this.department);
                com.Parameters.AddWithValue("@jobTitle", this.jobTitle);
                com.Parameters.AddWithValue("@baseSalary", this.baseSalary);
                com.Parameters.AddWithValue("@startingDate", this.startDate);
                com.Parameters.AddWithValue("@endingDate", this.endDate);



                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                return "Employee added successfuly";
                
            }
        }

        // function that takes an employee ID and return all its information as a datatable
        public DataTable getEmployee(int employeeID)
        {
            // checking if an employee exists
            string query = "SELECT * FROM employee WHERE id_employee=@id";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@id", employeeID);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }

        public void modiftyEmployee(int employeeID)
        {
            string query = "UPDATE employee SET name=@fname, lname=@lname, sex=@sex, birth_date=@birthDate, city=@city, country=@country," +
                "telephone=@phone, CIN=@CIN, status=@status, nbr_kids=@nbrKids, CNSS=@CNSS, departement=@departement, job_title=@jobTitle, base_salary=@baseSalary, starting_date=@startingDate, ending_date=@endingDate WHERE id_employee=@ID";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@fname", this.firstName);
            com.Parameters.AddWithValue("@lname", this.lastName);
            com.Parameters.AddWithValue("@sex", this.sex);
            com.Parameters.AddWithValue("@birthDate", this.birthDate);
            com.Parameters.AddWithValue("@city", this.city);
            com.Parameters.AddWithValue("@country", this.country);
            com.Parameters.AddWithValue("@phone", this.phoneNumber);
            com.Parameters.AddWithValue("@CIN", this.CIN);
            com.Parameters.AddWithValue("@status", this.status);
            com.Parameters.AddWithValue("@nbrKids", this.kidsNbr);
            com.Parameters.AddWithValue("@CNSS", this.CNSS);
            com.Parameters.AddWithValue("@departement", this.department);
            com.Parameters.AddWithValue("@jobTitle", this.jobTitle);
            com.Parameters.AddWithValue("@baseSalary", this.baseSalary);
            com.Parameters.AddWithValue("@startingDate", this.startDate);
            com.Parameters.AddWithValue("@endingDate", this.endDate); 
            com.Parameters.AddWithValue("@ID", employeeID);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
