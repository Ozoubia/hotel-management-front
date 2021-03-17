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
    /// Logique d'interaction pour consommableChambreUserControl.xaml
    /// </summary>
    public partial class consommableChambreUserControl : UserControl
    {
        //VAR 
        bool isChecked = false;
        public consommableChambreUserControl(string material, int quntity, bool state)
        {
            InitializeComponent();
            consommableTxt.Text= material;
            materialInfo.Text = quntity.ToString();

            if (state)
            {
                chechBox1.IsChecked = true;
            }
            else
            {
                chechBox1.IsChecked = false;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string desinationD = consommableTxt.Text;
            int quantite = int.Parse(materialInfo.Text);
            bool chechedD = isChecked;

            string typeCh = classes.GlobalVariable.chambreType1;
            classes.prototypeConsommable prototypeObj = new classes.prototypeConsommable(desinationD, quantite, typeCh, chechedD);
            string result = prototypeObj.addprototype();
            MessageBox.Show(result);
        }

        private void chechBox1_Checked(object sender, RoutedEventArgs e)
        {
            isChecked = true;
            materialInfo.Visibility = Visibility.Visible;
        }

        private void chechBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            isChecked = false;
            materialInfo.Visibility = Visibility.Hidden;
        }
    }
}
