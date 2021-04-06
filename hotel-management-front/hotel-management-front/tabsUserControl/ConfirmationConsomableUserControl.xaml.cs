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
    /// Logique d'interaction pour ConfirmationConsomableUserControl.xaml
    /// </summary>
    public partial class ConfirmationConsomableUserControl : UserControl
    {
        //VAR 
        DateTime time1;
        string nameRoom;
        int idsejour;
        public double prixMoy;
        public ConfirmationConsomableUserControl(string NomDejeun, int quantite, DateTime time, string nameR, int idsej)
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
            int  s =int.Parse( materialInfo.Text);
            string Nom = petitdejeunTxt.Text;
            
            classes.article articleObj = new classes.article();
            articleObj.modiftyquantity(Nom, s);

             DateTime date = DateTime.Today;
            string designatio = petitdejeunTxt.Text;
            int quna = int.Parse(materialInfo.Text);
            MessageBox.Show(idsejour.ToString());
            classes.historiqueConsommablesChambre Obj = new classes.historiqueConsommablesChambre();
            string s1 = Obj.remplirQuantity(quna, this.idsejour, date, designatio);
            MessageBox.Show(s1);
            //calculer prix total 
            classes.consommablesChambre obj = new classes.consommablesChambre();
            
            DataTable table = obj.SelcetPrixMoyen(Nom);
            double prix = double.Parse(table.Rows[0]["prix_moyen"].ToString());
            prixMoy = prix * quna;
            classes.GlobalVariable.prixTotal = classes.GlobalVariable.prixTotal + prixMoy;
            MessageBox.Show(classes.GlobalVariable.prixTotal.ToString());

        }


    }
}
