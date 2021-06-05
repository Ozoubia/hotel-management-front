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
    /// Interaction logic for TrasactionWindow.xaml
    /// </summary>
    public partial class TrasactionWindow : Window
    {
        public string transFrom;
        public string transTo;
        public TrasactionWindow(string transactionFrom, string transactionTo)
        {
            InitializeComponent();
            this.transFrom = transactionFrom;
            this.transTo = transactionTo;

            fillInfo();
        }

        private void fillInfo()
        {
            TransFromField.Text = this.transFrom;
            TransToField.Text = this.transTo;
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.caisse caisseObj = new classes.caisse();
            int somme = int.Parse(SommeField.Text);
            // banc to personnel
            if (this.transFrom == "Banque" && this.transTo == "Personnel")
            {
                caisseObj.transaction("caisseBan", "caissePer", somme);
            }

            if (this.transFrom == "Personnel" && this.transTo == "Banque")
            {
                caisseObj.transaction("caissePer", "caisseBan", somme);
            }

            if (this.transFrom == "Personnel" && this.transTo == "Hotel")
            {
                caisseObj.transaction("caissePer", "caisseHot", somme);
            }

            if (this.transFrom == "Hotel" && this.transTo == "Personnel")
            {
                caisseObj.transaction("caisseHot", "caissePer", somme);
            }
        }
    }
}
