using hotel_management_front.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour ConfirmationPetitDejeunerUserControl.xaml
    /// </summary>
    public partial class ConfirmationPetitDejeunerUserControl : UserControl
    {
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        //VAR 
        DateTime time1;
        string nameRoom;
        int idsejour;
        public ConfirmationPetitDejeunerUserControl(string NomDejeun ,int quantite ,DateTime time , string nameR  ,int  idsej)
        {
          
            InitializeComponent();
            petitdejeunTxt.Text = NomDejeun;
            materialInfo.Text = quantite.ToString();
            this.time1 = time;
            this.nameRoom = nameR;
            this.idsejour = idsej;
        }

        private void confirmerBtn_Click(object sender, RoutedEventArgs e)
        {
             // int  s =int.Parse( materialInfo.Text);
             //string Nom = petitdejeunTxt.Text;
             //classes.article articleObj = new classes.article();
             // articleObj.modiftyquantity(Nom, s);



            DateTime date = DateTime.Today;
             string designatio = petitdejeunTxt.Text;
             int quna = int.Parse(materialInfo.Text);
            MessageBox.Show(idsejour.ToString());
            classes.HistoriqueArticleChambreClass  Obj = new classes.HistoriqueArticleChambreClass();
            string s1 = Obj.remplirQuantity(quna ,this.idsejour, date, designatio);
            MessageBox.Show(s1);







        }

        private void AnnulerBtn_Click(object sender, RoutedEventArgs e)
        {
             
        }
    }
}
