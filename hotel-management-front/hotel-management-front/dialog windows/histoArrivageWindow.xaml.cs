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
using System.Windows.Shapes;

namespace hotel_management_front.dialog_windows
{
    /// <summary>
    /// Logique d'interaction pour histoArrivageWindow.xaml
    /// </summary>
    public partial class histoArrivageWindow : Window
    {
        public histoArrivageWindow(DateTime dateArrivage)
        {
            DateTime time = dateArrivage;
            InitializeComponent();
            showhistoArrivageList(time);

        }

        public void showhistoArrivageList(DateTime date)
        {
            classes.HistoArrivage histoArrivageObj = new classes.HistoArrivage();
            DataTable tab = histoArrivageObj.showAllhistoArrivageBydate(date);



            histoArrivageListGrid.ItemsSource = tab.DefaultView;
            ((DataGridTextColumn)histoArrivageListGrid.Columns[0]).Binding = new Binding("nom_fournisseur");
            ((DataGridTextColumn)histoArrivageListGrid.Columns[1]).Binding = new Binding("prenom_founisseur");
            ((DataGridTextColumn)histoArrivageListGrid.Columns[2]).Binding = new Binding("prixTotal");
            ((DataGridTextColumn)histoArrivageListGrid.Columns[3]).Binding = new Binding("payee");
            ((DataGridTextColumn)histoArrivageListGrid.Columns[4]).Binding = new Binding("rest_payee");



        }
    }
}
