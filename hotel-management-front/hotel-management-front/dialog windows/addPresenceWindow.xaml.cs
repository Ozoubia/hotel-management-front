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
    /// Logique d'interaction pour addPresenceWindow.xaml
    /// </summary>
    public partial class addPresenceWindow : Window
    {
        public addPresenceWindow()
        {
            InitializeComponent();
        }

        private void confirmerBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime detePresence = DateTime.Parse(todayDateField.SelectedDate.Value.Date.ToShortDateString());
           // DateTime start_hour =  DateTime.Parse()
        }

        private void annulerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
