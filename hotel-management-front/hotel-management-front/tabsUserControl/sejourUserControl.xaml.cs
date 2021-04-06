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
using System.Windows.Threading;

namespace hotel_management_front.tabsUserControl
{
    /// <summary>
    /// Interaction logic for sejourUserControl.xaml
    /// </summary>
    public partial class sejourUserControl : UserControl
    {

        // timer used for refresh
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

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
            ////alimenter petit dejeun avec chambre qui consomer dans le table de HistoriqueArticleChambre quand cliquez option sejour
            DateTime time = date;
            int j = 1;
            int x = 0;
            for (int i = 0; i < nbr; i++)
            {
                if (i == 0)
                {
                    classes.HistoriqueArticleChambreClass obj2 = new classes.HistoriqueArticleChambreClass(rommName, time, type, IDsejour, 0, designationList[x]);
                    string mag = obj2.addHistorique();
                    classes.DatailSejour objSejour = new classes.DatailSejour(IDsejour , time , false);
                   string m = objSejour.addDatialSejour();
                    MessageBox.Show(m);
                }

                if (j < nbjour && i > 0)
                {

                    // MessageBox.Show(mag +" "+ time.ToString());
                    time = time.AddDays(1);
                    j += 1;
                    classes.HistoriqueArticleChambreClass obj2 = new classes.HistoriqueArticleChambreClass(rommName, time, type, IDsejour, 0, designationList[x]);
                    string mag = obj2.addHistorique();
                    classes.DatailSejour objSejour = new classes.DatailSejour(IDsejour, time, false);
                    objSejour.addDatialSejour();
                    continue;
                }

                if (j == nbjour)
                {
                    x++;
                    classes.HistoriqueArticleChambreClass obj = new classes.HistoriqueArticleChambreClass(rommName, date, type, IDsejour, 0, designationList[x]);
                    string mag1 = obj.addHistorique();
                    classes.DatailSejour objSejour = new classes.DatailSejour(IDsejour, date, false);
                    objSejour.addDatialSejour();
                    time = date.Date;
                    j = 1;
                    continue;
                }


            }
            ////alimenter Consommables Chambre avec chambre qui consomer dans le table de historiqueConsommablesChambre quand cliquez option sejour
            classes.prototypeConsommable Obj = new classes.prototypeConsommable();
            DataTable dataConsomable = new DataTable();
            dataConsomable = Obj.showAllprototypeByType(type);
            int nbConsomable = data1.Rows.Count;
            int nbrTotal = nbConsomable * nbjour;
            DateTime date1 = DateTime.Parse(classes.GlobalVariable.dataRowView[5].ToString());
            DateTime time1 = date1;

            List<string> designationList1 = new List<string>();
            for (int i = 0; i < nb; i++)
            {
                designationList1.Add(dataConsomable.Rows[i]["designation"].ToString());
            }
            int k = 1;
            int x1 = 0;
            for (int i = 0; i < nbrTotal; i++)
            {
                if (i == 0)
                {
                    classes.historiqueConsommablesChambre obj2 = new classes.historiqueConsommablesChambre(rommName, time1, type, IDsejour, 0, designationList1[x1]);
                    string mag = obj2.addHistoriqueConsomablesChambre();
                }

                if (k < nbjour && i > 0)
                {


                    time1 = time1.AddDays(1);
                    k += 1;
                    classes.historiqueConsommablesChambre obj2 = new classes.historiqueConsommablesChambre(rommName, time1, type, IDsejour, 0, designationList1[x1]);
                    string mag = obj2.addHistoriqueConsomablesChambre();
                    continue;
                }

                if (k == nbjour)
                {
                    x1++;
                    classes.historiqueConsommablesChambre obj = new classes.historiqueConsommablesChambre(rommName, date, type, IDsejour, 0, designationList1[x1]);
                    string mag1 = obj.addHistoriqueConsomablesChambre();
                    time1 = date1.Date;
                    k = 1;
                    continue;
                }
            }

            
            


            new ContientSejourWindow(type, date, rommName, IDsejour).Show();
            }

          

            private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
            {

            }

        #region update grid
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            this.dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            showSejourList();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // stopping the timer
            this.dispatcherTimer.Stop();
        }
        #endregion

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
  


