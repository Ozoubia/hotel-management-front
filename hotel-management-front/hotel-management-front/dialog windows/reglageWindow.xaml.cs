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
    /// Logique d'interaction pour reglageWindow.xaml
    /// </summary>
    public partial class reglageWindow : Window
    {


        public reglageWindow()
        {
            InitializeComponent();
            showTypeList();
            fillTypeChambreCombo();
            //showRightTopGrid();

        }


        public void showTypeList()
        {
            classes.typeChambre typeChambreObj = new classes.typeChambre();
            DataTable data = typeChambreObj.showAllTypes();
            TypeListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)TypeListGrid.Columns[0]).Binding = new Binding("typeChambre");
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ajouterTypeChambreBtn_Click(object sender, RoutedEventArgs e)
        {
            string type = typeChambreField.Text;
            classes.typeChambre typeChambreObj = new classes.typeChambre(type);
            string result = typeChambreObj.addTypeChambre();
            MessageBox.Show(result);
        }
        /// Petit Dejeun 

        public void fillTypeChambreCombo()
        {

            classes.typeChambre typeChambreObj = new classes.typeChambre();
            DataTable data = typeChambreObj.showAllTypes();
            int data_length = data.Rows.Count;

            // looping through the client list
            for (int i = 0; i < data_length; i++)
            {
                string type = data.Rows[i]["typeChambre"].ToString();
                typeComboBox.Items.Add(type);
            }

        }
        private void showRightTopGrid()
        {
            topGrid.Children.Clear();

            classes.petitDejeun petitDejeunObj = new classes.petitDejeun();
            DataTable data = petitDejeunObj.showAllpetitDejeun();

            int nbrEqui = data.Rows.Count;
            for (int i = 0; i < nbrEqui; i++)
            {
                string mater = data.Rows[i]["designation_PetitD"].ToString();

                topGrid.Children.Add(new PetitDejeunUserControl(mater, 0, false));

            }

        }

        private void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //initialiser la valeur global chambretype par ComboBox
            classes.GlobalVariable.chambreType = typeComboBox.SelectedItem.ToString();

            //
            classes.prototype prototypeObj = new classes.prototype();
            DataTable data = prototypeObj.showAllprototypeByType(classes.GlobalVariable.chambreType);
            int nbrEqui = data.Rows.Count;
            if (nbrEqui == 0)
            {
                topGrid.Children.Clear();
                showRightTopGrid();
            }
            else
            {
                topGrid.Children.Clear();

                for (int i = 0; i < nbrEqui; i++)

                {
                    string mater = data.Rows[i]["designation"].ToString();
                    int quantite = int.Parse(data.Rows[i]["quantity_petitDejeun"].ToString());
                    bool checkedd = bool.Parse(data.Rows[i]["checked"].ToString());
                    topGrid.Children.Add(new PetitDejeunUserControl(mater, quantite, checkedd));

                }

                classes.petitDejeun petitDejeunObj = new classes.petitDejeun();

                List<string> designitionDejuenLIst = petitDejeunObj.showDejeun();

                int nbr = designitionDejuenLIst.Count;
                MessageBox.Show(nbr.ToString());
                for (int i = 0; i < nbr; i++)
                {
                    string dejeun = designitionDejuenLIst[i];
                    topGrid.Children.Add(new PetitDejeunUserControl(dejeun, 0, false));

                }

            }
        }
    }
}
