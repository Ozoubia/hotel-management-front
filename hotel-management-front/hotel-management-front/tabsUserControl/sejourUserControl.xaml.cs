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
    /// Interaction logic for sejourUserControl.xaml
    /// </summary>
    public partial class sejourUserControl : UserControl
    {
        


        public sejourUserControl()
        {
            InitializeComponent();
            showSejourList();
        }

        //function to fill the sejour list
        public void showSejourList()
        {

            classes.sejour sejourObj = new classes.sejour();
            DataTable data = sejourObj.showSejourList();

            sejourListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)sejourListGrid.Columns[0]).Binding = new Binding("id_sejour");
            ((DataGridTextColumn)sejourListGrid.Columns[1]).Binding = new Binding("name");
            ((DataGridTextColumn)sejourListGrid.Columns[2]).Binding = new Binding("lname");
            ((DataGridTextColumn)sejourListGrid.Columns[3]).Binding = new Binding("rname");
            ((DataGridTextColumn)sejourListGrid.Columns[4]).Binding = new Binding("type");
            ((DataGridTextColumn)sejourListGrid.Columns[5]).Binding = new Binding("check_in");
            ((DataGridTextColumn)sejourListGrid.Columns[6]).Binding = new Binding("check_out");
            ((DataGridTextColumn)sejourListGrid.Columns[7]).Binding = new Binding("total_amount");
            ((DataGridTextColumn)sejourListGrid.Columns[8]).Binding = new Binding("payement_status");
            ((DataGridTextColumn)sejourListGrid.Columns[9]).Binding = new Binding("nbr_days");

        }

        private void terminateBtn_Click(object sender, RoutedEventArgs e)
        {
            // saving the index of the row in the datarowview var
            //   classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            //classes.sejour sejourObj = new classes.sejour();

            // string name = classes.GlobalVariable.dataRowView[0].ToString();
            // string lname = classes.GlobalVariable.dataRowView[1].ToString();
            // string roomName = classes.GlobalVariable.dataRowView[2].ToString();
            // DateTime checkin = DateTime.Parse(classes.GlobalVariable.dataRowView[4].ToString());
            // DateTime checkout = DateTime.Parse(classes.GlobalVariable.dataRowView[5].ToString());
            //int totalAmount = int.Parse(classes.GlobalVariable.dataRowView[6].ToString());
            //string payementStatus = classes.GlobalVariable.dataRowView[7].ToString();

            //            sejourObj.terminateReservation(name, lname, roomName, checkin, checkout, totalAmount, payementStatus);

            //update dataGrid after deletion            
            //          showSejourList();
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;

            string type = classes.GlobalVariable.dataRowView[3].ToString();
            DateTime date = DateTime.Parse(classes.GlobalVariable.dataRowView[5].ToString());
            string rommName = classes.GlobalVariable.dataRowView[2].ToString();
            string v = classes.GlobalVariable.dataRowView[4].ToString();
            int IDsejour = int.Parse(v);

            //récupérer le nombre de lignes il existe dans le table prototype
            classes.prototype prototypeObj = new classes.prototype();
            DataTable data1 = new DataTable();
            data1 = prototypeObj.showAllprototypeByType(type);
            int nb = data1.Rows.Count;
            MessageBox.Show(nb.ToString());
            //récupérer le nombre des jour 
            int nbjour = int.Parse(classes.GlobalVariable.dataRowView[9].ToString());
            int nbr = nb * nbjour;
            MessageBox.Show("nb jour", nbjour.ToString());

            List<string> designationList = new List<string>();
            for (int i = 0; i < nb; i++)
            {
                designationList.Add(data1.Rows[i]["designation"].ToString());
            }

            DateTime time = date;
            int j = 1;
            int x = 0;
            for (int i = 0; i < nbr; i++)
            {
                if (i == 0)
                {
                    classes.HistoriqueArticleChambreClass obj2 = new classes.HistoriqueArticleChambreClass(rommName, time, type, IDsejour, 0, designationList[x]);
                    string mag = obj2.addHistorique();
                }

                if (j < nbjour && i> 0 )
                {
                    
                   // MessageBox.Show(mag +" "+ time.ToString());
                    time = time.AddDays(1);
                    j += 1;
                     classes.HistoriqueArticleChambreClass obj2 = new classes.HistoriqueArticleChambreClass(rommName, time, type, IDsejour, 0, designationList[x]);
                    string mag = obj2.addHistorique();
                    continue;
                }

                if (j == nbjour)
                {
                    x++;
                    classes.HistoriqueArticleChambreClass obj = new classes.HistoriqueArticleChambreClass(rommName, date, type, IDsejour, 0, designationList[x]);
                    string mag1 = obj.addHistorique();
                    time = date.Date;
                    j = 1;
                    continue;
                }


            }

          
            new ContientSejourWindow(type, date, rommName , IDsejour).Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
  
}

