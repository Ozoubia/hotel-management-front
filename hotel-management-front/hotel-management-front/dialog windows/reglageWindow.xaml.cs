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
            fillTypeChambreCombo1();
          



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
                
                for (int i = 0; i < nbr; i++)
                {
                    string dejeun = designitionDejuenLIst[i];
                    topGrid.Children.Add(new PetitDejeunUserControl(dejeun, 0, false));

                }

            }
        }
        //consommables chambre
        public void fillTypeChambreCombo1()
        {

            classes.typeChambre typeChambreObj = new classes.typeChambre();
            DataTable data = typeChambreObj.showAllTypes();
            int data_length = data.Rows.Count;

            // looping through the client list
            for (int i = 0; i < data_length; i++)
            {
                string type = data.Rows[i]["typeChambre"].ToString();
                typeComboBox1.Items.Add(type);
            }

        }
        private void showConsommableGrid()
        {
            ConsommableGrid.Children.Clear();

            classes.consommablesChambre Obj = new classes.consommablesChambre();
            DataTable data = Obj.showAllconsommablesChambre();

            int nbrEqui = data.Rows.Count;
            for (int i = 0; i < nbrEqui; i++)
            {
                string mater = data.Rows[i]["designation_consommable"].ToString();

                ConsommableGrid.Children.Add(new consommableChambreUserControl(mater, 0, false));

            }

        }
        private void typeComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //initialiser la valeur global chambretype par ComboBox
                 classes.GlobalVariable.chambreType1 = typeComboBox1.SelectedItem.ToString();

                    //
                    classes.prototypeConsommable prototypeObj = new classes.prototypeConsommable();
                    DataTable data = prototypeObj.showAllprototypeByType(classes.GlobalVariable.chambreType1);
                    int nbrEqui = data.Rows.Count;

               // MessageBox.Show()
                   if (nbrEqui == 0)
                    {
                        ConsommableGrid.Children.Clear();
                        showConsommableGrid();
                    }
                   else
                    {
                        ConsommableGrid.Children.Clear();

                        for (int i = 0; i < nbrEqui; i++)

                        {
                            string mater = data.Rows[i]["designation"].ToString();
                            int quantite = int.Parse(data.Rows[i]["quantity_consomable"].ToString());
                            bool checkedd = bool.Parse(data.Rows[i]["checked"].ToString());
                            ConsommableGrid.Children.Add(new consommableChambreUserControl(mater, quantite, checkedd));

                        }

                        classes.consommablesChambre Obj = new classes.consommablesChambre();

                        List<string> designitionDejuenLIst = Obj.showConsomable();

                        int nbr = designitionDejuenLIst.Count;
                        for (int i = 0; i < nbr; i++)
                       {
                            string consomable = designitionDejuenLIst[i];
                            ConsommableGrid.Children.Add(new consommableChambreUserControl(consomable, 0, false));

                        }

                    }
                }
        }
        
    }
