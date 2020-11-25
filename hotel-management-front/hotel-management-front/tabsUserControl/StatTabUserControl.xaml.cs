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
    /// Interaction logic for StatTabUserControl.xaml
    /// </summary>
    public partial class StatTabUserControl : UserControl
    {
        public StatTabUserControl()
        {
            InitializeComponent();
            classes.stats statsObj = new classes.stats();
            
            DataTable data = statsObj.countProduct("Cuisine");
            int cunt = (int)data.Rows[0]["ct"];
            produitsCuisine.Text = cunt.ToString();
            DataTable data1 = statsObj.countProduct("Material");
            int cunt1 = (int)data1.Rows[0]["ct"];
            materiel.Text = cunt1.ToString();
            DataTable data2 = statsObj.countProduct("Generale");
            int cunt2 = (int)data2.Rows[0]["ct"];
            produitsGeneral.Text = cunt2.ToString();
        }
    }
}
