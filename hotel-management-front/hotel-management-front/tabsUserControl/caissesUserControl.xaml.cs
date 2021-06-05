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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Interaction logic for caissesUserControl.xaml
    /// </summary>
    public partial class caissesUserControl : UserControl
    {
        // timer used for refresh
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public caissesUserControl()
        {
            InitializeComponent();
            fillSomms();
        }

        private void fillSomms()
        {
            classes.caisse caisseObj = new classes.caisse();
            int bancSum = caisseObj.totalCaisseBan();
            int perSum = caisseObj.totalCaissePer();
            int hotSum = caisseObj.totalCaisseHot();

            banSommeField.Text = "DZ " + bancSum.ToString();
            perSommeField.Text = "DZ " + perSum.ToString();
            hotSommeField.Text = "DZ " + hotSum.ToString();
        }

        private void addBancBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        #region refresh fields
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            this.dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            fillSomms();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // stopping the timer
            this.dispatcherTimer.Stop();
        }
        #endregion
    }
}
