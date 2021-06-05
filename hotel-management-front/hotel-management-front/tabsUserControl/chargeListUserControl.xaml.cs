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
using System.Windows.Threading;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Interaction logic for chargeListUserControl.xaml
    /// </summary>
    public partial class chargeListUserControl : UserControl
    {

        // timer used for refresh
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public chargeListUserControl()
        {
            InitializeComponent();
            showChargeList();
        }


        //function to fill the employee list
        public void showChargeList()
        {
            classes.charge chargeObj = new classes.charge();
            DataTable data = chargeObj.showAllCharges();

            chargeGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)chargeGrid.Columns[0]).Binding = new Binding("type");
            ((DataGridTextColumn)chargeGrid.Columns[1]).Binding = new Binding("date");
            ((DataGridTextColumn)chargeGrid.Columns[2]).Binding = new Binding("price");

        }

        private void addChargeBtn_Click(object sender, RoutedEventArgs e)
        {
            new addChargeWindow().Show();
        }

        #region timer grid refresh part

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            this.dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            showChargeList();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // stopping the timer
            this.dispatcherTimer.Stop();
        }
        #endregion
    }
}
