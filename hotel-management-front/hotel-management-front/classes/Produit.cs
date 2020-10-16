using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System;
using hotel_management_front.tabsUserControl;

namespace hotel_management_front.classes
{
    public class Produit
    {

        //vars 

        string nomProduit;
        int Quantite;
        int prixProduit;
        string nomFournisseur;
        string categorie;
        DateTime dateLivraison;

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        //Produit constructor 
        public Produit()
        {
        }


        public Produit(string NomProd, int Quant, int PrixP, string nomFour, string catego, DateTime dateLivr)
        {
            this.nomProduit = NomProd;
            this.Quantite = Quant;
            this.prixProduit = PrixP;
            this.nomFournisseur = nomFour;
            this.categorie = catego;
            this.dateLivraison = dateLivr;
        }
        public string addProduct()
        {



            string query = "INSERT INTO Produit (Nom_Produit , Quantite_Produit , Prix_Produit , Nom_Fournisseur , Categorie , Date_livraison) " + "VALUES (@nomProduit, @Quantite, @prixProduit, @nomFournisseur , @categorie , @dateLivraison)";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@nomProduit", this.nomProduit);
            com.Parameters.AddWithValue("@Quantite", this.Quantite);
            com.Parameters.AddWithValue("@prixProduit", this.prixProduit);
            com.Parameters.AddWithValue("@nomFournisseur", this.nomFournisseur);
            com.Parameters.AddWithValue("@categorie", this.categorie);
            com.Parameters.AddWithValue("@dateLivraison", this.dateLivraison);



            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            return "Product added successfuly";




        }
        // function that takes an poduct ID and return all its information as a datatable
        public DataTable getProduit(int produitID)
        {
            // checking if an product exists
            string query = "SELECT * FROM Produit WHERE Id_Produit=@id";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@id", produitID);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
        // function that takes an employee ID and modifier it
        public void modiftyPoduct(int produitID)
        {
            string query = "UPDATE Produit SET Nom_Produit=@nomProduit, Quantite_Produit=@Quantite, Prix_Produit=@prixProduit, Nom_Fournisseur=@nomFournisseur, Categorie=@categorie, Date_livraison=@dateLivraison" + " WHERE Id_Produit=@ID";

            SqlCommand com = new SqlCommand(query, con);

            // params

            com.Parameters.AddWithValue("@ID", produitID);
            com.Parameters.AddWithValue("@nomProduit", this.nomProduit);
            com.Parameters.AddWithValue("@Quantite", this.Quantite);
            com.Parameters.AddWithValue("@prixProduit", this.prixProduit);
            com.Parameters.AddWithValue("@nomFournisseur", this.nomFournisseur);
            com.Parameters.AddWithValue("@categorie", this.categorie);
            com.Parameters.AddWithValue("@dateLivraison", this.dateLivraison);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        // function that takes an product ID and deletes it
        public void deleteProduct(int produitID)
        {
            string query = "DELETE FROM Produit WHERE  Id_Produit=@ID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ID", produitID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // function that returns all the product as a datatable
        public DataTable showAllProduct()
        {
            string query = "SELECT * FROM Produit";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        // function that returns a database of a result of search (searching by name and last name)
        public DataTable searchProduct(string ProduitSearch)
        {
            string query = "SELECT * FROM Produit WHERE Nom_Produit Like '%" + ProduitSearch + "%' OR Categorie LIKE'%" + ProduitSearch + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;

        }

    }

}

