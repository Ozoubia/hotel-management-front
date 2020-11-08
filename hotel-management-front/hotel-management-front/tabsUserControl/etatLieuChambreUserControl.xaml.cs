using hotel_management_front.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for etatLieuChambreUserControl.xaml
    /// </summary>
    public partial class etatLieuChambreUserControl : UserControl
    {
        public int roomID;
        public string design;
        
        
        

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public etatLieuChambreUserControl()
        {
            InitializeComponent();

            // left grid -------------------------------------------
            //fill the grid with the rooms buttons
            classes.room roomObj = new classes.room();
            DataTable result = roomObj.showAllRooms();

            int nbrRooms = result.Rows.Count;

            // for each room
            for (int i = 0; i < nbrRooms; i++)
            {
                Button newBtn = new Button();
                string button_content = result.Rows[i]["name"].ToString();
                newBtn.Content = button_content;
                newBtn.Width = 100;
                newBtn.Height = 60;
                newBtn.Name = button_content;
                newBtn.Margin = new Thickness(10, 10, 10, 10);
                newBtn.Click += new RoutedEventHandler(button_click);

                mainGrid.Children.Add(newBtn);
            }

            void button_click(object sender, RoutedEventArgs e)
            {
                Button B = (Button)sender;

                // getting the id of the clicked room
                room roomObj2 = new room();
                DataTable result2 = roomObj2.showRoomIDByName(B.Name);

                roomID = int.Parse(result2.Rows[0]["id_room"].ToString());

                // showing right grid
                rightGrid.Children.Clear();
                showRightGrid();
            }

        }

        // method that display the right grid of materials
        void showRightGrid()
        {

            // show the material user controls 
            article articleObj = new article();
            DataTable articles = articleObj.FilterByLocalisation("Material");
            int nbrMat = articles.Rows.Count;

            // storing the designation items in a list to be used later for init
            List<string> materialList = new List<string>();

            // below code is used for 
            ELRoom ELroomObj = new ELRoom();
            DataTable result = ELroomObj.showRoomInELRoom(roomID);

            // testing if the room exists in etat de lieu 
            if (result.Rows.Count != 1)
            {

                // for each room
                for (int i = 0; i < nbrMat; i++)
                {
                    design = articles.Rows[i]["designation"].ToString();              
                    rightGrid.Children.Add(new materialRoomUserControl(design, roomID, 0));
                    materialList.Add(design);
                }

                init_material_vars(materialList);
            }
            else
            {
                // storing the designation items in a list to be used later for init
                List<string> materialList1 = new List<string>();
                // for each room
                for (int i = 0; i < nbrMat; i++)
                {
                    design = articles.Rows[i]["designation"].ToString();
                    
                    materialList1.Add(design);
                }


                // for each material, get its value
                for (int i = 0; i < nbrMat; i++)
                {
                    int value = int.Parse(result.Rows[0][materialList1[i]].ToString());
                    rightGrid.Children.Add(new materialRoomUserControl(design, roomID, 1));

                }
            }

        }

        // used to initialize the etat lieu material attributes with 0 and the id room attr with the current room
        public void init_material_vars(List<string> materialList)
        {

            // checking if a room is init in etat de lieu table
            string query = "SELECT * FROM etat_lieu_room WHERE id_room=@id_room";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@id_room", roomID);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //room id already exists 
            if (dtbl.Rows.Count == 0)
            {
                // because the query changes depending on the material element we need to create it dynamically 
                string query_attr = "";
                string query_vals = "";

                // creating the query for all material attributes
                for (int i = 0; i < materialList.Count; i++)
                {
                    query_attr += ", " + materialList[i];
                    query_vals += ", 0";
                }

                string query1 = "INSERT INTO etat_lieu_room (id_room " + query_attr + " ) VALUES (@id_room " + query_vals + " )";
                SqlCommand com = new SqlCommand(query1, con);

                // params
                com.Parameters.AddWithValue("@id_room", roomID);

                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            

            
        }

    }
}
