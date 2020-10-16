using hotel_management_front.dialog_windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Logique d'interaction pour stockSecoursUserControl.xaml
    /// </summary>
    public partial class stockSecoursUserControl : UserControl
    {
        public stockSecoursUserControl()
        {
            InitializeComponent();
            showMaterialsList();
        }
            
            public void showMaterialsList() { 
            classes.Secour secourObj = new classes.Secour();
            DataTable Data = secourObj.showAllMsecour();
            MaterialSListGrid.ItemsSource = Data.DefaultView;
            ((DataGridTextColumn)MaterialSListGrid.Columns[0]).Binding = new Binding("Id_Msecour");
            ((DataGridTextColumn)MaterialSListGrid.Columns[1]).Binding = new Binding("Nom_Msecour");
            ((DataGridTextColumn)MaterialSListGrid.Columns[2]).Binding = new Binding("Quantite_Msecour");
            ((DataGridTextColumn)MaterialSListGrid.Columns[3]).Binding = new Binding("prix_Msecour");
            ((DataGridTextColumn)MaterialSListGrid.Columns[4]).Binding = new Binding("Nom_fournisseur");
            ((DataGridTextColumn)MaterialSListGrid.Columns[5]).Binding = new Binding("Date_Achat");
            ((DataGridTextColumn)MaterialSListGrid.Columns[6]).Binding = new Binding("Emplacement_reserve");
            ((DataGridTextColumn)MaterialSListGrid.Columns[7]).Binding = new Binding("Etat_MaterailS");
            ((DataGridTextColumn)MaterialSListGrid.Columns[8]).Binding = new Binding("Description");
        }
        

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            classes.Secour secouObj = new classes.Secour();
            DataTable data = secouObj.searchMsecour(searchBar.Text);
            MaterialSListGrid.ItemsSource = data.DefaultView;
        }

        private void AjouterMaterial_Click(object sender, RoutedEventArgs e)
        {
            new addemergencyEquipmentWindow().Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            // opening the modify page
            new modifyEmergencyEquipmentWindow().Show();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            classes.Secour secouObj = new classes.Secour();
            secouObj.deleteMsecour(int.Parse(classes.GlobalVariable.dataRowView[0].ToString()));
        }
    }
}
