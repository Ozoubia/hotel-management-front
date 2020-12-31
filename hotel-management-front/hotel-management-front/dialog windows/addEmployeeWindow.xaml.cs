using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour addEmployeeWindow.xaml
    /// </summary>
    public partial class addEmployeeWindow : Window
    {
        public addEmployeeWindow()
        {
            InitializeComponent();
        }

        
        private void ajouterEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nomField.Text;
            string lname = PrenomField.Text;
            string sex = sexField.Text;
            DateTime birthDate = DateTime.Parse(dateNaissanceField.SelectedDate.Value.Date.ToShortDateString());
            string city = vailleField.Text;
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

            string result = employeeObj.addEmployee();
            MessageBox.Show(result);
            // add action to history log
            string par = "Ajouter Employee";
            string nom = classes.GlobalVariable.username;
            DateTime dateAction = DateTime.Today;
            classes.client clientObj1 = new classes.client();
            clientObj1.ajouterHistorique(nom, par, dateAction);


        }

        

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}
