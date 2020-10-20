using System;
using System.Data.SqlClient;
using System.Data;

namespace hotel_management_front.classes
{
    public class Material
    {
        //Var
        string nomMaterial;
        int quantiteMaterial;
        int   prixMaterial ;
        string nomFournisseur;
        DateTime dateAchat;
        string etatMaterial;
        DateTime dateUtilisation;
        string Description;

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        //Material constructor 
        public Material()
        {

        }
        

        public Material(string nomMaterial, int quantiteMaterial, int prixMaterial, string nomFournisseur, DateTime dateAchat, DateTime dateUtilisation, string etatMaterial, string description)
        {
            this.nomMaterial = nomMaterial;
            this.quantiteMaterial = quantiteMaterial;
            this.prixMaterial = prixMaterial;
            this.nomFournisseur = nomFournisseur;
            this.dateAchat = dateAchat;
            this.dateUtilisation = dateUtilisation;
            this.etatMaterial = etatMaterial;
            Description = description;
        }

        public string addMaterial()
        {
            string query = "INSERT INTO Material (Nom_Material , Quantite_Material , prix_Material , Nom_fournisseur, Date_Achat , date_Utilisation, etat_Material ,Description) " + "VALUES (@nomMaterial, @quantiteMaterial, @prixMaterial, @nomFournisseur , @dateAchat , @etatMaterial ,@Description ,@dateUtilisation)";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@nomMaterial", this.nomMaterial);
            com.Parameters.AddWithValue("@quantiteMaterial", this.quantiteMaterial);
            com.Parameters.AddWithValue("@prixMaterial", this.prixMaterial);
            com.Parameters.AddWithValue("@nomFournisseur", this.nomFournisseur);
            com.Parameters.AddWithValue("@dateAchat", this.dateAchat);
            com.Parameters.AddWithValue("@dateUtilisation", this.dateUtilisation);
            com.Parameters.AddWithValue("@etatMaterial", this.etatMaterial);
            _ = com.Parameters.AddWithValue("@Description", Description);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            return "Material added successfuly";
        }
        // function that takes an material ID and return all its information as a datatable
        public DataTable getMaterial(int materialID)
        {
            // checking if an material exists
            string query = "SELECT * FROM Material WHERE Id_Material=@id";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@id", materialID);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }

        public void modiftyMaterial(int materialID)
        {
            string query = "UPDATE Material SET Nom_Material=@nomMaterial, Quantite_Material=@quantiteMaterial, prix_Material=@prixMaterial, Nom_fournisseur=@nomFournisseur, Date_Achat=@dateAchat, date_Utilisation=@dateUtilisation , Description=@Description ,etat_Material=@etatMaterial" + " WHERE Id_Material=@ID";

            SqlCommand com = new SqlCommand(query, con);

            // params

            com.Parameters.AddWithValue("@ID", materialID);
            com.Parameters.AddWithValue("@nomMaterial", this.nomMaterial);
            com.Parameters.AddWithValue("@quantiteMaterial", this.quantiteMaterial);
            com.Parameters.AddWithValue("@prixMaterial", this.prixMaterial);
            com.Parameters.AddWithValue("@nomFournisseur", this.nomFournisseur);
            com.Parameters.AddWithValue("@dateAchat", this.dateAchat);
            com.Parameters.AddWithValue("@dateUtilisation", this.dateUtilisation);
            com.Parameters.AddWithValue("@etatMaterial", this.etatMaterial);
            com.Parameters.AddWithValue("@Description", this.Description);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        // function that takes an material ID and deletes it
        public void deleteMaterial(int materialID)
        {
            string query = "DELETE FROM Material WHERE  Id_Material=@ID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ID", materialID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // function that returns all the material as a datatable
        public DataTable showAllMaterial()
        {
            string query = "SELECT * FROM Material";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        // function that returns a database of a result of search (searching by name and last name)
        public DataTable searchMaterial(string MaterialSearch)
        {
            string query = "SELECT * FROM Material WHERE Nom_Material Like '%" + MaterialSearch + "%' OR Date_Achat LIKE'%" + MaterialSearch + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;

        }
    }
    }
