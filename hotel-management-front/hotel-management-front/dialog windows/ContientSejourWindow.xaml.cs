using hotel_management_front.tabsUserControl;
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
    /// Logique d'interaction pour ContientSejourWindow.xaml
    /// </summary>
    public partial class ContientSejourWindow : Window
    {
        string type;
        DateTime dateSej;
        string nameChambre;
        int idSejour;
       
        public ContientSejourWindow( string typeChambre , DateTime date , string nomchambre , int idSej)
        {
            this.type = typeChambre;
            this.dateSej = date;
            this.nameChambre = nomchambre ;
            this.idSejour = idSej;


            InitializeComponent();
            showSingleGrid();
        }

        private void showSingleGrid() 
        {
            classes.prototype prototypeObj = new classes.prototype();
            DataTable data = prototypeObj.showAllprototypeByType(this.type);
            int nbrEqui = data.Rows.Count;



            for (int i = 0; i < nbrEqui; i++)

            {
                string mater = data.Rows[i]["designation"].ToString();
                int quantite = int.Parse(data.Rows[i]["quantity_petitDejeun"].ToString());
         
                SingleGrid.Children.Add(new ConfirmationPetitDejeunerUserControl(mater , quantite , dateSej , nameChambre , this.idSejour));

            }
        }
    }
}
