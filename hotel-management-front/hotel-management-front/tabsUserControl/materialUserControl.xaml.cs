using hotel_management_front.dialog_windows;
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
    /// Logique d'interaction pour materialUserControl.xaml
    /// </summary>
    public partial class materialUserControl : UserControl
    {
        public materialUserControl()
        {
            InitializeComponent();
            showMaterialList();
        }
        public void showMaterialList()
        {
            classes.Material materialObj = new classes.Material();
            DataTable Data = materialObj.showAllMaterial();
            MaterialListGrid.ItemsSource = Data.DefaultView;
            ((DataGridTextColumn)MaterialListGrid.Columns[0]).Binding = new Binding("Id_Material");
            ((DataGridTextColumn)MaterialListGrid.Columns[1]).Binding = new Binding("Nom_Material");
            ((DataGridTextColumn)MaterialListGrid.Columns[2]).Binding = new Binding("Quantite_Material");
            ((DataGridTextColumn)MaterialListGrid.Columns[3]).Binding = new Binding("prix_Material");
            ((DataGridTextColumn)MaterialListGrid.Columns[4]).Binding = new Binding("Nom_fournisseur");
            ((DataGridTextColumn)MaterialListGrid.Columns[5]).Binding = new Binding("Date_Achat");
            ((DataGridTextColumn)MaterialListGrid.Columns[6]).Binding = new Binding("date_Utilisation");
            ((DataGridTextColumn)MaterialListGrid.Columns[7]).Binding = new Binding("etat_Material");
            ((DataGridTextColumn)MaterialListGrid.Columns[8]).Binding = new Binding("Description");
        }
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            classes.Material materialObj = new classes.Material();
            DataTable date = materialObj.searchMaterial(searchBar.Text);
            MaterialListGrid.ItemsSource = date.DefaultView;

        }

        private void AjouterMaterial_Click(object sender, RoutedEventArgs e)
        {
            new addMaterialWindow().Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            // opening the modify page
            new modifyMaterialWindow().Show();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            classes.Material materialObj = new classes.Material();
            materialObj.deleteMaterial(int.Parse(classes.GlobalVariable.dataRowView[0].ToString()));
        }

    }
}
