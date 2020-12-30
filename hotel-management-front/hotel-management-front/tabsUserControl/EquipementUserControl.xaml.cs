﻿using hotel_management_front.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour EquipementUserControl.xaml
    /// </summary>
    public partial class EquipementUserControl : UserControl
    {
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);
        public EquipementUserControl()
        {
            InitializeComponent();
            showEquipementList();
        }
        public void showEquipementList()
        {
            classes.EquipementClass equipementObj = new classes.EquipementClass();
            DataTable data = equipementObj.showAllequipement();
            equipementListGrid.ItemsSource = data.DefaultView;
            ((DataGridTextColumn)equipementListGrid.Columns[0]).Binding = new Binding("reference_E");
            ((DataGridTextColumn)equipementListGrid.Columns[1]).Binding = new Binding("designation_E");
            ((DataGridTextColumn)equipementListGrid.Columns[2]).Binding = new Binding("quantity_equipement");
            ((DataGridTextColumn)equipementListGrid.Columns[3]).Binding = new Binding("stock_alert_E");
            ((DataGridTextColumn)equipementListGrid.Columns[4]).Binding = new Binding("prix_achat_E");
            ((DataGridTextColumn)equipementListGrid.Columns[5]).Binding = new Binding("type_Equipement");


        }
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            classes.EquipementClass equipementClassObj = new EquipementClass();
            classes.Cuisine cuisineObj = new Cuisine();
    
            equipementClassObj.deleteEquipement(classes.GlobalVariable.dataRowView[1].ToString());
            cuisineObj.deleteCuisine(classes.GlobalVariable.dataRowView[1].ToString());
        }



        private void équipementChambrer_Click(object sender, RoutedEventArgs e)
        {
            //modefier le type de equipement 
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string reference = classes.GlobalVariable.dataRowView[1].ToString();
            string query = "UPDATE Equipement SET type_Equipement='chambre' WHERE reference_E=@ref";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@ref", reference);


            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            // checking if an employee exists
            string query1 = "SELECT * FROM cuisine WHERE reference_C=@reference";
            SqlDataAdapter ada = new SqlDataAdapter(query1, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@reference", reference);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count <= 1)
            {
                classes.Cuisine cuisineObj = new Cuisine();
               
                cuisineObj.deleteCuisine(reference);
            }
        }

        private void équipementCuisine_Click(object sender, RoutedEventArgs e)
        {
            //modefier le type de equipement 
            classes.GlobalVariable.dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string reference = classes.GlobalVariable.dataRowView[1].ToString();
            string query = "UPDATE Equipement SET type_Equipement='cuisine' WHERE reference_E=@ref";

            SqlCommand com = new SqlCommand(query, con);

            // params
            com.Parameters.AddWithValue("@ref", reference);


            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            //VAR
            int quantity = 0;
            string designation = classes.GlobalVariable.dataRowView[2].ToString();
            string reference1 = classes.GlobalVariable.dataRowView[1].ToString();
            int stockAlert = (int)classes.GlobalVariable.dataRowView[3];
            int prixAchat = (int)classes.GlobalVariable.dataRowView[4];
            int prixVente = 0;
            //s alimenter table de cuisine
            classes.Cuisine cuisineObj = new classes.Cuisine(quantity, designation, reference1, stockAlert, prixAchat, prixVente);
            cuisineObj.addCuisine1("équipement Cuisine");
          
        }
    }
}
