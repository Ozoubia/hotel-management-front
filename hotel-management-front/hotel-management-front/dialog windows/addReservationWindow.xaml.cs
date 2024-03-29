﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for addReservationWindow.xaml
    /// </summary>
    public partial class addReservationWindow : Window
    {
        public DataTable data;
        public int roomPrice;
        public addReservationWindow()
        {
            InitializeComponent();
            fillClientCombo();
        }

        // function to fill the client bombo box
        public void fillClientCombo()
        {
            classes.client clientObj = new classes.client();
            DataTable data = clientObj.showAllClients();
            int data_length = data.Rows.Count;

            // looping through the client list
            for (int i = 0; i < data_length; i++)
            {
                string name = data.Rows[i]["name"].ToString();
                string lname = data.Rows[i]["lname"].ToString();
                string full_name = name + " " + lname;
                clientComboBox.Items.Add(full_name);
            }

        }

        // function to fill the client bombo box
        public void fillRoomCombo(DateTime dateArrive, DateTime dateDepart)
        {
            classes.room roomObj = new classes.room();
            DataTable data = roomObj.showAllAvailableRooms(dateArrive, dateDepart);
            int data_length = data.Rows.Count;

            // looping through the client list
            for (int i = 0; i < data_length; i++)
            {
                roomComboBox.Items.Add(data.Rows[i]["name"].ToString());
            }

        }

        private void addNewClientBtn_Click(object sender, RoutedEventArgs e)
        {
            new addClientWindow().Show();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // confirming the reservation , inserting into the reservation table
        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            string clientFullName = clientComboBox.Text;
            string roomName = roomComboBox.Text;
            DateTime startDate = DateTime.Parse(dateArriveeField.SelectedDate.Value.Date.ToShortDateString());
            DateTime endDate = DateTime.Parse(dateDepartField.SelectedDate.Value.Date.ToShortDateString());
            int totalAmount = int.Parse(montalTotalField.Text);
            string payementStatus = payementStatusComboBox.Text;
            int versement = int.Parse(versementField.Text);
            // confirmation date
            int nbrDayBeforeConfirm = int.Parse(confirmationDate.Text);
            DateTime confirmDate = endDate.AddDays(-nbrDayBeforeConfirm);

            //number of days
            DateTime start = startDate.Date;
            DateTime end = endDate.Date;
            var nbrDays = ((end - start).TotalDays + 1);

            classes.reservation reservObj = new classes.reservation(clientFullName, roomName, startDate, endDate, int.Parse(nbrDays.ToString()), totalAmount, payementStatus, versement, confirmDate);

            string result = reservObj.AddReservation();
            MessageBox.Show(result);
            // add action to history log
            string par = "Ajouter Reservation ";
            string nom = classes.GlobalVariable.username;
            DateTime dateAction = DateTime.Today;
            classes.client clientObj1 = new classes.client();
            clientObj1.ajouterHistorique(nom, par, dateAction);
        }

        // function to the change the montant total when room is changed
        private void roomComboBox_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                // getting room price
                classes.room roomObj = new classes.room();
                data = roomObj.showRoomPrice(roomComboBox.Text);
                roomPrice = int.Parse(data.Rows[0]["base_price"].ToString());

                // effecting room price to the montant total var if neither date is selected
                if (dateArriveeField.SelectedDate == null && dateDepartField.SelectedDate == null)
                {
                    montalTotalField.Text = data.Rows[0]["base_price"].ToString();
                }
                else
                {
                    // calculating the difference and calculating the montant total when dates are selected
                    DateTime start = dateArriveeField.SelectedDate.Value.Date;
                    DateTime end = dateDepartField.SelectedDate.Value.Date;
                    var nbrDays = (end - start).TotalDays;
                    montalTotalField.Text = ((nbrDays + 1) * roomPrice).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Selectionner une chambre");
            }
            

        }

        // calculating the new montant total when the arrive date is selected
        private void dateArriveeField_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // if the other date if not empty we calculate it
            if (dateDepartField.SelectedDate != null)
            {
                DateTime start = dateArriveeField.SelectedDate.Value.Date;
                DateTime end = dateDepartField.SelectedDate.Value.Date;
                var nbrDays = (end - start).TotalDays;
                montalTotalField.Text = ((nbrDays + 1) * roomPrice).ToString();

                //update room combobox
                roomComboBox.Items.Clear();
                fillRoomCombo(start, end);
            }
        }

        // calculating the new montant total when the depart date is selected
        private void dateDepartField_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // if the other date if not empty we calculate it
            if (dateArriveeField.SelectedDate != null)
            {
                DateTime start = dateArriveeField.SelectedDate.Value.Date;
                DateTime end = dateDepartField.SelectedDate.Value.Date;
                var nbrDays = (end - start).TotalDays;
                montalTotalField.Text = ((nbrDays + 1) * roomPrice).ToString();

                //update room combobox
                roomComboBox.Items.Clear();
                fillRoomCombo(start, end);
            }
        }

        // showing or hidding the versement field
        private void payementStatusComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (payementStatusComboBox.Text == "versee")
            {
                versementField.Visibility = Visibility.Visible;

            }else if (payementStatusComboBox.Text == "payee")
            {
                versementField.Visibility = Visibility.Hidden;
            }
        }

        private void clientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
