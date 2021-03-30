using hotel_management_front.classes;
using hotel_management_front.dialog_windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour reservationUserControl.xaml
    /// </summary>
    public partial class reservationUserControl : UserControl
    {
        public reservationUserControl()
        {
            InitializeComponent();
            showReservationsList();
        }

        //function to fill the reservation list
        public void showReservationsList()
        {
            classes.reservation reservObj = new classes.reservation();
            DataTable data = reservObj.showAllReservations();

            reservationListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)reservationListGrid.Columns[0]).Binding = new Binding("name");
            ((DataGridTextColumn)reservationListGrid.Columns[1]).Binding = new Binding("lname");
            ((DataGridTextColumn)reservationListGrid.Columns[2]).Binding = new Binding("rname");
            ((DataGridTextColumn)reservationListGrid.Columns[3]).Binding = new Binding("type");
            ((DataGridTextColumn)reservationListGrid.Columns[4]).Binding = new Binding("check_in");
            ((DataGridTextColumn)reservationListGrid.Columns[5]).Binding = new Binding("check_out");
            ((DataGridTextColumn)reservationListGrid.Columns[6]).Binding = new Binding("total_amount");
            ((DataGridTextColumn)reservationListGrid.Columns[7]).Binding = new Binding("payement_status");
            ((DataGridTextColumn)reservationListGrid.Columns[8]).Binding = new Binding("versement");


        }

        private void addReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            new addReservationWindow().Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void validateBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            classes.reservation reservObj = new classes.reservation();

            string name = classes.GlobalVariable.dataRowView[0].ToString();
            string lname = classes.GlobalVariable.dataRowView[1].ToString();
            string roomName = classes.GlobalVariable.dataRowView[2].ToString();
            DateTime checkin = DateTime.Parse(classes.GlobalVariable.dataRowView[4].ToString());
            DateTime checkout = DateTime.Parse(classes.GlobalVariable.dataRowView[5].ToString());
            int totalAmount = int.Parse(classes.GlobalVariable.dataRowView[6].ToString());
            string payementStatus = classes.GlobalVariable.dataRowView[7].ToString();

            reservObj.validateReservation(name, lname, roomName, checkin, checkout, totalAmount, payementStatus);

            //update dataGrid after deletion            
            showReservationsList();
            // Se déplacer involontairement à Séjour
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Sejour",
            };


            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            sejourUserControl UC1 = new sejourUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }
}
