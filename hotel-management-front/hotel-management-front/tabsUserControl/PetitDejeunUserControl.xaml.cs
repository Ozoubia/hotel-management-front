using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour PetitDejeunUserControl.xaml
    /// </summary>
    public partial class PetitDejeunUserControl : UserControl
    {
        //VAR 
        bool isChecked = false;
        
        public PetitDejeunUserControl(string material , int quntity ,bool state)
        {

            InitializeComponent();
            petitdejeunTxt.Text = material;
            materialInfo.Text = quntity.ToString();
            

            if(state) 
            {
                chechBox1.IsChecked = true;
            }
            else 
            {
                chechBox1.IsChecked = false;
            }
           
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            string desinationD = petitdejeunTxt.Text;
            int quantite = int.Parse(materialInfo.Text);
            bool chechedD = isChecked;
            classes.petitDejeun obj = new classes.petitDejeun();
            DataTable data = new DataTable();
            data = obj.SelcetPrixMoyen(desinationD);
            double prix = double.Parse(data.Rows[0]["prix_moyen"].ToString());
            string typeCh = classes.GlobalVariable.chambreType;
            classes.prototype prototypeObj = new classes.prototype(desinationD, quantite, typeCh, chechedD , prix);
            string result = prototypeObj.addprototype();
            MessageBox.Show(result);
           

        }
    }
}
