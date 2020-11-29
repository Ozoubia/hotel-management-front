using hotel_management_front.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Interaction logic for planiningTabUserControl.xaml
    /// </summary>
    public partial class planiningTabUserControl : UserControl
    {

        int colsNbr;
        int rowsNbr;
        DataTable roomsData;

        public planiningTabUserControl()
        {
            InitializeComponent();
            // init months and year fields
            initializeFields();

            // getting the rooms 
            room roomObj = new room();
            roomsData = roomObj.showAllRooms();


            // number of columns and rows
            rowsNbr = int.Parse(roomsData.Rows.Count.ToString());
            getMnthNbrDays();

            initializePlaningGrid(rowsNbr, colsNbr, roomsData);
            
        }

        // getting the number of days of month 
        private void getMnthNbrDays()
        {
            int year = int.Parse(yearField.Text);
            int month = int.Parse(monthField.Text);
            int nbrDays = DateTime.DaysInMonth(year, month);
            colsNbr = nbrDays + 1;
            
        }

        // filling the grid system
        private void initializePlaningGrid(int numberOfRows, int numberOfCols, DataTable rooms)
        {
            planingGrid.Rows = numberOfRows;
            planingGrid.Columns = numberOfCols;

            // number of grid rows (title included)
            int index = ((numberOfRows * numberOfCols) - 1) + numberOfCols;
            int roomIndex = 0;

            // reser index points to the date, that's why it starts with 1
            int reserIndex = 1;

            // store the current row room name
            string CurrentRoomName = "";
            for (int i = 0; i < index; i++)
            {
                
                if (i == 0)
                {
                    // dates grid
                    Rectangle rectG = new Rectangle();
                    rectG.Fill = Brushes.White;
                    rectG.Name = "rect" + i.ToString();
                    rectG.Width = 100;
                    rectG.Height = 50;
                    planingGrid.Children.Add(rectG);
                }

                if (i < numberOfCols - 1)
                {
                    // dates grid
                    string dateText = (i + 1).ToString() + "/" + monthField.Text;
                    TextBlock dateTextBlock = new TextBlock();
                    dateTextBlock.Text = dateText;
                    dateTextBlock.FontSize = 20;
                    dateTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    dateTextBlock.VerticalAlignment = VerticalAlignment.Center;
                    planingGrid.Children.Add(dateTextBlock);
                }
                else if ((i + 1) % numberOfCols == 0)
                {
                    TextBlock roomName = new TextBlock();
                    roomName.Text = rooms.Rows[roomIndex]["name"].ToString();
                    roomName.FontSize = 18;
                    roomName.HorizontalAlignment = HorizontalAlignment.Center;
                    roomName.VerticalAlignment = VerticalAlignment.Center;

                    planingGrid.Children.Add(roomName);
                    roomIndex = roomIndex + 1;
                    CurrentRoomName = roomName.Text;
                }
                else
                {
                    if (reserIndex == numberOfCols)
                    {
                        reserIndex = 1;
                    }

                    // grid values
                    Button Butt = new Button();                    
                    Butt.Name = "butt" + i.ToString();
                    Butt.Height = 100;
                    Butt.Width = 100;
                    Butt.Content = reserIndex;

                    // getting reservation infos
                    reservation reserObj = new reservation();
                    DataTable result = reserObj.showReservationByRoomName(CurrentRoomName);

                    // if there are reservations
                    if (result.Rows.Count > 0)
                    {
                        // if the room has multiple reservations in a month, loop through them
                        for (int j = 0; j < result.Rows.Count; j++)
                        {
                            DateTime checkIn = DateTime.Parse(result.Rows[j]["check_in"].ToString());
                            //DateTime checkOut = DateTime.Parse(result.Rows[j]["check_out"].ToString());
                            int nbrDays = int.Parse(result.Rows[j]["nbr_days"].ToString());



                            // used to show each reservation in its correct month and year
                            if ((checkIn.Year == int.Parse(yearField.Text)) && (checkIn.Month == int.Parse(monthField.Text)))
                            {
                                // used to color the interval between checkin and checkout
                                if (reserIndex >= checkIn.Day && reserIndex < (checkIn.Day + nbrDays))
                                {
                                    //getting the reservation name
                                    string name = result.Rows[j]["name"].ToString();
                                    string lname = result.Rows[j]["lname"].ToString();
                                    Butt.Content = name + " " + lname;
                                    Butt.Background = Brushes.LightBlue;
                                }
                            }

                            
                        }



                    }

                    // incremente
                    reserIndex += 1;


                    // adding the buttons
                    planingGrid.Children.Add(Butt);
                    Butt.Click += new RoutedEventHandler(button_click);

                    
                }

                void button_click(object sender, RoutedEventArgs e)
                {
                    Button B = (Button)sender;

                    MessageBox.Show(B.Name);
                }


                
            }
        }

        //init the month and year fields
        private void initializeFields()
        {
            monthField.Text = DateTime.Now.Month.ToString();
            yearField.Text = DateTime.Now.Year.ToString();
        }

        //previous month button
        private void leftArrowBtn_Click(object sender, RoutedEventArgs e)
        {      
            // getting current fields values 
            int month = int.Parse(monthField.Text);
            int year = int.Parse(yearField.Text);

            // month decrease
            DateTime currentMonth = new DateTime(year, month, 1);
            int previousMonthNum = currentMonth.AddMonths(-1).Month;
            DateTime previousMonth = new DateTime(year, previousMonthNum, 1);
            monthField.Text = previousMonth.Month.ToString();

            // only decremente the year when its january
            if (month == 1)
            {
                //year increase
                DateTime currentYear = new DateTime(year, 1, 1);
                int previousYearNum = currentYear.AddMonths(-1).Year;
                DateTime previousYear = new DateTime(previousYearNum, 1, 1);
                yearField.Text = previousYear.Year.ToString();
            }
           


            //refreshing the grid
            getMnthNbrDays();
            planingGrid.Children.Clear();
            initializePlaningGrid(rowsNbr, colsNbr, roomsData);

            
        }

        // next month button
        private void rightArrowBtn_Click(object sender, RoutedEventArgs e)
        {
            // getting current fields values 
            int month = int.Parse(monthField.Text);
            int year = int.Parse(yearField.Text);
            DateTime currentMonth = new DateTime(year, month, 1);

            int nextMonthNum = currentMonth.AddMonths(+1).Month;
            DateTime nextMonth = new DateTime(year, nextMonthNum, 1);
            monthField.Text = nextMonth.Month.ToString();

            // only incremente the year when its december
            if (month == 12)
            {
                //year increase
                DateTime currentYear = new DateTime(year, 12, 31);
                int nextYearNum = currentYear.AddMonths(+1).Year;
                DateTime nextYear = new DateTime(nextYearNum, 1, 1);
                yearField.Text = nextYear.Year.ToString();
            }

            //refreshing the grid
            getMnthNbrDays();
            planingGrid.Children.Clear();
            initializePlaningGrid(rowsNbr, colsNbr, roomsData);
        }
    }
}
