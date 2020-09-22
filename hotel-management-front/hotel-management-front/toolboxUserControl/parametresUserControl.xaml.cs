using hotel_management_front.classes;
using hotel_management_front.tabsUserControl;
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

namespace hotel_management_front.toolboxUserControl
{
    /// <summary>
    /// Interaction logic for parametresUserControl.xaml
    /// </summary>
    public partial class parametresUserControl : UserControl
    {
        public parametresUserControl()
        {
            InitializeComponent();
        }

        private void utilisateur_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Utilisateur",
            };

            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            utilisateurUserControl UC1 = new utilisateurUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        private void sauvgarde_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Sauvgarde",
            };


            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            sauvgardeUserControl UC1 = new sauvgardeUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        private void restauration_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Restauration",
            };


            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            reservationUserControl UC1 = new reservationUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }

        private void aide_Click(object sender, RoutedEventArgs e)
        {
            Grid tabGrid = new Grid();

            TabItem newTabItem = new TabItem
            {
                Header = "Aide",
            };


            GlobalVariable.tbControl.Items.Add(newTabItem);
            newTabItem.Content = tabGrid;
            tabGrid.Children.Clear();
            aideUserControl UC1 = new aideUserControl();
            tabGrid.Children.Add(UC1);
            newTabItem.IsSelected = true;
        }
    }
}
