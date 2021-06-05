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
    /// Interaction logic for addChargeWindow.xaml
    /// </summary>
    public partial class addChargeWindow : Window
    {
        public addChargeWindow()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            string type = typeField.Text;
            DateTime dateCharge = DateTime.Parse(dateChargeField.SelectedDate.Value.Date.ToShortDateString());
            int price = int.Parse(priceField.Text);

            classes.charge chargeObj = new classes.charge(type, dateCharge, price);
            string result = chargeObj.addCharge();
            MessageBox.Show(result);
        }
    }
}
