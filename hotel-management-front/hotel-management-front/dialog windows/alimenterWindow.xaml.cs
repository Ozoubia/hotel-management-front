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
    /// Interaction logic for alimenterWindow.xaml
    /// </summary>
    public partial class alimenterWindow : Window
    {

        public string caisseName; 
        public alimenterWindow(string name)
        {
            InitializeComponent();
            caisseFieldName.Text = name;
            this.caisseName = name;
        }

        private void confirmerBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.caisse caisseObj = new classes.caisse();
            int som = int.Parse(SommeField.Text);
            if (this.caisseName == "Banque")
            {
                caisseObj.alimenter("CaisseBan", som);
                MessageBox.Show("successful");
            }
            else if (this.caisseName == "Personnel")
            {
                caisseObj.alimenter("CaissePer", som);
                MessageBox.Show("successful");
            }
            else if (this.caisseName == "Hotel")
            {
                caisseObj.alimenter("CaisseHot", som);
                MessageBox.Show("successful");
            }

            
        }
    }
}
