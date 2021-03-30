using hotel_management_front.classes;
using hotel_management_front.dialog_windows;
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
    /// Interaction logic for stockGeneralUserControl.xaml
    /// </summary>
    public partial class stockGeneralUserControl : UserControl
    {
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public stockGeneralUserControl()
        {
            InitializeComponent();
            showArticleList();
        }

        //function to fill the employee list
        public void showArticleList()
        {
            classes.article articleObj = new classes.article();
            DataTable data = articleObj.showAllArticles1();

            articleListGrid.ItemsSource = data.DefaultView;

            ((DataGridTextColumn)articleListGrid.Columns[0]).Binding = new Binding("reference");
            ((DataGridTextColumn)articleListGrid.Columns[1]).Binding = new Binding("designation");
            ((DataGridTextColumn)articleListGrid.Columns[2]).Binding = new Binding("famille");
            ((DataGridTextColumn)articleListGrid.Columns[3]).Binding = new Binding("quantity");
            ((DataGridTextColumn)articleListGrid.Columns[4]).Binding = new Binding("stock_alert");
            ((DataGridTextColumn)articleListGrid.Columns[5]).Binding = new Binding("prix_achat");
            ((DataGridTextColumn)articleListGrid.Columns[6]).Binding = new Binding("prix_vente");
            ((DataGridTextColumn)articleListGrid.Columns[7]).Binding = new Binding("localisation");
            ((DataGridTextColumn)articleListGrid.Columns[8]).Binding = new Binding("type_consommable");
            ((DataGridTextColumn)articleListGrid.Columns[9]).Binding = new Binding("prix_moyen");

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            classes.article articleOBj = new classes.article();
            DataTable data1 = articleOBj.searchArticle(searchBar.Text);
            articleListGrid.ItemsSource = data1.DefaultView;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            classes.Cuisine cuisineObj = new classes.Cuisine();
            classes.article articleObj = new classes.article();
            string reference = classes.GlobalVariable.dataRowView[0].ToString();
            cuisineObj.deleteCuisine(reference);
            articleObj.deleteActicle(reference);
            showArticleList();
            // add action to history log
            string par = "supprimer  le produit de la cuisine";
            string nom = classes.GlobalVariable.username;
            DateTime dateAction = DateTime.Today;
            classes.client clientObj1 = new classes.client();
            clientObj1.ajouterHistorique(nom, par, dateAction);

            string par1 = "supprimer  le produit de le stock général ";
            string nom1 = classes.GlobalVariable.username;
            DateTime dateAction1 = DateTime.Today;
            classes.client clientObj2 = new classes.client();
            clientObj1.ajouterHistorique(nom1, par1, dateAction1);



        }

        private void petitDéjeuner_Click(object sender, RoutedEventArgs e)
        {
            //modefier le type de equipement 
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string reference = classes.GlobalVariable.dataRowView[0].ToString();

            string query = "UPDATE article SET type_consommable='petit Déjeuner' WHERE reference=@ref";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@ref", reference);


            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            //VAR
            // int quantity = (int)classes.GlobalVariable.dataRowView[3];
            //hadha tabl cuisin nbadlo ismo golna nkhadmo bih ay haja pj tathat fih ou ki tasra resarvation nahiw qun 0 bi 9ima khra 
            int quantity = 0;
          
            string designation = classes.GlobalVariable.dataRowView[1].ToString();
            string reference1 = classes.GlobalVariable.dataRowView[0].ToString();
            double prix= double.Parse(classes.GlobalVariable.dataRowView[9].ToString());

            //alimenter table de petitDejeun
            classes.petitDejeun petitDejeunOBj = new classes.petitDejeun( quantity, designation, reference1 , prix);
            petitDejeunOBj.addPetitDejeun();

            //supprimer Consommables Chambre dans le table de ConsommablesChambre quand cliquez option petitDejeun
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string designation1 = classes.GlobalVariable.dataRowView[1].ToString();
            classes.consommablesChambre Obj = new classes.consommablesChambre();
            Obj.supprimerConsommablesChambre(designation1);

            //supprimer Consommables Chambre dans le table de prototypeConsommable quand cliquez option petitDejeun
            classes.prototypeConsommable Obj1 = new classes.prototypeConsommable();
            Obj1.SupprimerConsomable(designation1);
        }



        private void consommableChambre_Click(object sender, RoutedEventArgs e)
        {
            //modefier le type de equipement 
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string reference = classes.GlobalVariable.dataRowView[0].ToString();

            string query = "UPDATE article SET type_consommable='consommables chambre' WHERE reference=@ref";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@ref", reference);


            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            //supprimer petit déjeuner dans le table de déjeuner quand cliquez option consommable chambre
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string designation = classes.GlobalVariable.dataRowView[1].ToString();
            classes.prototype Obj = new classes.prototype();
            Obj.SupprimerPetitDejeun(designation);

            //supprimer petit déjeuner dans le table de prototype quand cliquez option consommable chambre
            classes.petitDejeun petitDejeunObj = new classes.petitDejeun();
            petitDejeunObj.dpetitDejeun(designation);
            //alimenter le tableau consommable chambre
            int quantity = 0;
            string designation1 = classes.GlobalVariable.dataRowView[1].ToString();
            string reference1 = classes.GlobalVariable.dataRowView[0].ToString();
            double prix = double.Parse(classes.GlobalVariable.dataRowView[9].ToString());
            classes.consommablesChambre OBj = new classes.consommablesChambre(quantity, designation1, reference1, prix);
            OBj.addconsommablesChambre();
        }

       

        private void historiqueBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string reference = classes.GlobalVariable.dataRowView[0].ToString();
            string designationD = classes.GlobalVariable.dataRowView[1].ToString();
            new HistoriqueArticleWindow(reference , designationD).Show();
            classes.article article = new article();
          // double t = article.calculePrixReel(designationD);
          //  MessageBox.Show(t.ToString());
        }
    }
}