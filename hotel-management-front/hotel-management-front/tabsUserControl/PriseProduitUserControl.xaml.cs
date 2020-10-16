using hotel_management_front.dialog_windows;
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

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Logique d'interaction pour PriseProduitUserControl.xaml
    /// </summary>
    public partial class PriseProduitUserControl : UserControl
    {
        public PriseProduitUserControl()
        {
            InitializeComponent();
        }

        private void AjouterPrise_Click(object sender, RoutedEventArgs e)
        {
            new addTakingWindow().Show();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
