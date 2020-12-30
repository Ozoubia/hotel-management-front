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
using System.Data;
using System.Data.SqlClient;
using hotel_management_front.classes;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Interaction logic for cuisineUserControl.xaml
    /// </summary>
    public partial class cuisineUserControl : UserControl
    {
        public string design;
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public cuisineUserControl()
        {
            InitializeComponent();



            showArticlCuisineList();


        }
        // right grid
        public void showArticlCuisineList()
        {
            classes.Cuisine cuisineObj1 = new classes.Cuisine();
            DataTable da = cuisineObj1.showAllArticleCuisine();
            CuisineListGrid.ItemsSource = da.DefaultView;
            ((DataGridTextColumn)CuisineListGrid.Columns[0]).Binding = new Binding("ID_cuisine");
            ((DataGridTextColumn)CuisineListGrid.Columns[1]).Binding = new Binding("reference_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[2]).Binding = new Binding("designation_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[3]).Binding = new Binding("quantity_cuisine");
            ((DataGridTextColumn)CuisineListGrid.Columns[4]).Binding = new Binding("stock_alert_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[5]).Binding = new Binding("prix_achat_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[6]).Binding = new Binding("prix_vente_C");
        }
        public void showArticlCuisineList0()
        {
            classes.Cuisine cuisineObj1 = new classes.Cuisine();
            DataTable da = cuisineObj1.showAllArticleCuisineNull();
            CuisineListGrid.ItemsSource = da.DefaultView;
            ((DataGridTextColumn)CuisineListGrid.Columns[0]).Binding = new Binding("ID_cuisine");
            ((DataGridTextColumn)CuisineListGrid.Columns[1]).Binding = new Binding("reference_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[2]).Binding = new Binding("designation_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[3]).Binding = new Binding("quantity_cuisine");
            ((DataGridTextColumn)CuisineListGrid.Columns[4]).Binding = new Binding("stock_alert_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[5]).Binding = new Binding("prix_achat_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[6]).Binding = new Binding("prix_vente_C");
        }
        public void showArticlCuisineListBytype(string typeC)
        {
            classes.Cuisine cuisineObj1 = new classes.Cuisine();
            DataTable dat = cuisineObj1.showAllArticleCuisineBytype(typeC);

            CuisineListGrid.ItemsSource = dat.DefaultView;
            ((DataGridTextColumn)CuisineListGrid.Columns[0]).Binding = new Binding("ID_cuisine");
            ((DataGridTextColumn)CuisineListGrid.Columns[1]).Binding = new Binding("reference_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[2]).Binding = new Binding("designation_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[3]).Binding = new Binding("quantity_cuisine");
            ((DataGridTextColumn)CuisineListGrid.Columns[4]).Binding = new Binding("stock_alert_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[5]).Binding = new Binding("prix_achat_C");
            ((DataGridTextColumn)CuisineListGrid.Columns[6]).Binding = new Binding("prix_vente_C");
        }
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

     

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            rightGrid.Children.Clear();
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string design = classes.GlobalVariable.dataRowView[2].ToString();
            rightGrid.Children.Add(new modifierMatérielCuisineUserControl(design));

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            classes.Cuisine cuisineObj = new classes.Cuisine();
            cuisineObj.deleteArticleCuisine(int.Parse(classes.GlobalVariable.dataRowView[0].ToString()));
            //recover quantity
            string reference = classes.GlobalVariable.dataRowView[6].ToString();
            int quantit = int.Parse(classes.GlobalVariable.dataRowView[1].ToString());
            string query = "SELECT quantity FROM article WHERE reference=@ref";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            ada.SelectCommand.Parameters.AddWithValue("@ref", reference);


            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            int qun = (int)dtbl.Rows[0]["quantity"];
            int result = qun + quantit;


            string query1 = "UPDATE article SET quantity=@quant , quantity_utilisee=0 WHERE reference=@ref";
            SqlCommand com = new SqlCommand(query1, con);

            //params
            com.Parameters.AddWithValue("@quant", result);
            com.Parameters.AddWithValue("@ref", reference);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            //update dataGrid after deletion  
            showArticlCuisineList();
            // add action to history log
            string par = "Récupérer le produit en stock ";
            string nom = classes.GlobalVariable.username;
            DateTime dateAction = DateTime.Today;
            classes.client clientObj1 = new classes.client();
            clientObj1.ajouterHistorique(nom, par, dateAction);

        }

        private void petitDéjeuner_Click(object sender, RoutedEventArgs e)
        {
            showArticlCuisineListBytype("petit Déjeuner");
            titreDeTable.Text = "petit Déjeuner";
        }

        private void équipementCuisine_Click(object sender, RoutedEventArgs e)
        {
            showArticlCuisineListBytype("équipement Cuisine");
            titreDeTable.Text = "équipement Cuisine";
        }

        private void chargeCuisine_Click(object sender, RoutedEventArgs e)
        {
            showArticlCuisineListBytype("charge Cuisine");
            titreDeTable.Text = "charge Cuisine";
        }

        private void StockVide_Click(object sender, RoutedEventArgs e)
        {
            showArticlCuisineList0();
            titreDeTable.Text = "Stock Vide";
        }

        private void AlimenterpetitDéjeuner_Click(object sender, RoutedEventArgs e)
        {
            rightGrid.Children.Clear();
            article articleObj = new article();
            DataTable articles = articleObj.FilterByLocalisation("petit Déjeuner");
            int nbrMat = articles.Rows.Count;
            classes.GlobalVariable.ContenuTable = "petit Déjeuner";
            for (int i = 0; i < nbrMat; i++)
            {
                design = articles.Rows[i]["designation"].ToString();
                rightGrid.Children.Add(new materialCuisineUserControl(design));

            }
        }

        private void AlimenteréquipementCuisine_Click(object sender, RoutedEventArgs e)
        {
            rightGrid.Children.Clear();
        
            Cuisine cuisineObj = new Cuisine();
            DataTable articles = cuisineObj.showAllArticleCuisineBytype1("équipement Cuisine ");
            int nbrMat = articles.Rows.Count;
            classes.GlobalVariable.ContenuTable = "équipementCuisine";
            for (int i = 0; i < nbrMat; i++)
            {
                design = articles.Rows[i]["designation_C"].ToString();
                rightGrid.Children.Add(new materialCuisineUserControl(design));

            }
        }

        private void AlimenterchargeCuisine_Click(object sender, RoutedEventArgs e)
        {
            rightGrid.Children.Clear();
            article articleObj = new article();
            DataTable articles = articleObj.FilterByLocalisation("charge Cuisine");
            int nbrMat = articles.Rows.Count;
            classes.GlobalVariable.ContenuTable = "chargeCuisine";
            for (int i = 0; i < nbrMat; i++)
            {
                design = articles.Rows[i]["designation"].ToString();
                rightGrid.Children.Add(new materialCuisineUserControl(design));

            }
        }
    }
      
}
