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

namespace hotel_management_front
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            
            InitializeComponent();
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new tabBoardUserControl());
           
        }
              
       
        
        #region menu button
        private void dashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            gridMenu.Children.Clear();
            gridMenu.Children.Add(new tabBoardUserControl());

            string nom = classes.GlobalVariable.username;
            utilisateur.Text = nom;

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
            this.Close();

            

        }
        

    }
    }

