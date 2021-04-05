using hotel_management_front.tabsUserControl;
using hotel_management_front.toolboxUserControl;
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
using System.Windows.Threading;

namespace hotel_management_front
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        // timer used for refresh
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public DashBoard(string nom)
        {

            InitializeComponent();
            gridMenu.Children.Clear();

            utilisateur.Text = nom;
            gridMenu.Children.Add(new tabBoardUserControl());
            int count = 50;
            compteur.Badge = count;
            for (int i = 0; i < count; i++)
            {
                gridNotification.Children.Add(new notificationUserControl(" notification "));
            }

            //updateSejIsValid();
        }

        public void updateSejIsValid()
        {
            var date = DateTime.Now;
            if (date.Hour == 1)
            {
                classes.sejour sejObj = new classes.sejour();
                sejObj.resetIsValidated();
            }

        }

        

        #region menu button
        private void dashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new tabBoardUserControl());

      

        }

        private void hotelBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new hotelUserControl());
        }

        private void stockBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new StockUserControl());
        }

        private void personnelBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new PersonnelUserControl());
        }

        private void parametresBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new parametresUserControl());
        }
        private void caisseBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new caisseUserControl());
        }

        private void chargeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fournisseurBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new fournisseurUserControl());
        }
        #endregion
        
        #region tab settup
        private void tabControlDragable_Loaded(object sender, RoutedEventArgs e)
        {
            classes.GlobalVariable.tbControl = (sender as TabControl);
          
        }





        #endregion

        private void déconnecter_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
            
        }

        // used for timer (it doesn't work yet )
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test"); 
            //this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //this.dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            //this.dispatcherTimer.Start();
        }

        //private void dispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    updateSejIsValid();
        //    MessageBox.Show("test");
        //}
    }
    }

