using hotel_management_front.tabsUserControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace hotel_management_front.dialog_windows
{
    /// <summary>
    /// Logique d'interaction pour modifyEmployeeWindow.xaml
    /// </summary>
    public partial class modifyEmployeeWindow : Window
    {
        public modifyEmployeeWindow()
        {
            InitializeComponent();
            getPreviousInfo();
             

        }

        // to get the previous (clicked ) employee info
        private void getPreviousInfo()
        {
            // employee object
            classes.employee employeeObj = new classes.employee();

            // getting the index of the row 
            int rowIndex = int.Parse(classes.GlobalVariable.dataRowView[0].ToString());

            // getting the employee information of the clicked index
            DataTable result = employeeObj.getEmployee(rowIndex);

            // assigning the variable to the fields
            nomField.Text = result.Rows[0]["name"].ToString();
            PrenomField.Text = result.Rows[0]["lname"].ToString();
            sexField.Text = result.Rows[0]["sex"].ToString();
            dateNaissanceField.SelectedDate = DateTime.Parse(result.Rows[0]["birth_date"].ToString());
            villeField.Text = result.Rows[0]["city"].ToString();
            payField.Text = result.Rows[0]["sex"].ToString();
            telephoneField.Text = result.Rows[0]["telephone"].ToString();
            CINField.Text = result.Rows[0]["CIN"].ToString();
            statusField.Text = result.Rows[0]["status"].ToString();
            enfantsField.Text = result.Rows[0]["nbr_kids"].ToString();
            CNSSField.Text = result.Rows[0]["CNSS"].ToString();
            departementField.Text = result.Rows[0]["departement"].ToString();
            fonctionField.Text = result.Rows[0]["job_title"].ToString();
            salaireField.Text = result.Rows[0]["base_salary"].ToString();
            dateEntreeField.SelectedDate = DateTime.Parse(result.Rows[0]["starting_date"].ToString());
            dateSortieField.SelectedDate = DateTime.Parse(result.Rows[0]["ending_date"].ToString());
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmeBtn_Click(object sender, RoutedEventArgs e)
        {

            // getting the index of the row 
            int rowIndex = int.Parse(classes.GlobalVariable.dataRowView[0].ToString());

            // var fields assignings
            string name = nomField.Text;
            string lname = PrenomField.Text;
            string sex = sexField.Text;
            DateTime birthDate = DateTime.Parse(dateNaissanceField.SelectedDate.Value.Date.ToShortDateString());
            string city = villeField.Text;
            string country = payField.Text;
            int phoneNumber = int.Parse(telephoneField.Text);
            int CIN = int.Parse(CINField.Text);
            string status = statusField.Text;
            int NbrKids = int.Parse(enfantsField.Text);
            int CNSS = int.Parse(CNSSField.Text);
            string departement = departementField.Text;
            string jobTitle = fonctionField.Text;
            int baseSalary = int.Parse(salaireField.Text);
            DateTime startDate = DateTime.Parse(dateEntreeField.SelectedDate.Value.Date.ToShortDateString());
            DateTime endDate = DateTime.Parse(dateSortieField.SelectedDate.Value.Date.ToShortDateString());

            classes.employee employeeObj = new classes.employee(name, lname, sex, birthDate, city, country, phoneNumber, CIN, status, NbrKids, CNSS,
                                                                departement, jobTitle, baseSalary, startDate, endDate);

            employeeObj.modiftyEmployee(rowIndex);
            MessageBox.Show("Employee modifiee");

            // add action to history log
            string par = "Modifier Employee ";
            string nom = classes.GlobalVariable.username;
            DateTime dateAction = DateTime.Today;
            classes.client clientObj1 = new classes.client();
            clientObj1.ajouterHistorique(nom, par, dateAction);

           
           

        }
    }
}
