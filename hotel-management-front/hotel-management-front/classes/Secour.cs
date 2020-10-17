using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

 using hotel_management_front.tabsUserControl;

namespace hotel_management_front.classes
{
    public class Secour
    {
        //var 
        string nomMsecour;
        int quantiteMsecour;
        int prixMsecour;
        string nomFournisseur;
        DateTime dateAchat;
        string etatMsecour;
        string emplacement;
        string description;


        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        




        // Material de secours constructor 
        public Secour()
        {
        }

        public Secour(string nomMsecour, int quantiteMsecour, string nomFournisseur, string emplacement, string description, string etatMsecour, DateTime dateAchat, int prixMsecour)
        {
            this.nomMsecour = nomMsecour;
            this.quantiteMsecour = quantiteMsecour;
            this.nomFournisseur = nomFournisseur;
            this.emplacement = emplacement;
            this.description = description;
            this.etatMsecour = etatMsecour;
            this.dateAchat = dateAchat;
            this.prixMsecour = prixMsecour;
        }

        public Secour(string nomMsecour, int quantiteMsecour, int prixMsecour, string nomFournisseur, DateTime dateAchat, string etatMsecour, string emplacement, string description)
        {
            this.nomMsecour = nomMsecour;
            this.quantiteMsecour = quantiteMsecour;
            this.prixMsecour = prixMsecour;
            this.nomFournisseur = nomFournisseur;
            this.dateAchat = dateAchat;
            this.etatMsecour = etatMsecour;
            this.emplacement = emplacement;
            this.description = description;
        }

        public string addMsecour()
        {
            string query = "INSERT INTO Secours (Nom_Msecour, Quantite_Msecour , prix_Msecour , Nom_fournisseur, Date_Achat , Etat_MaterailS, Emplacement_reserve ,Description) " + "VALUES (@nomMsecour, @quantiteMsecour, @prixMsecour, @nomFournisseur , @dateAchat , @etatMsecour ,@Description ,@emplacement)";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@nomMsecour", this.nomMsecour);
            com.Parameters.AddWithValue("@quantiteMsecour", this.quantiteMsecour);
            com.Parameters.AddWithValue("@prixMsecour", this.prixMsecour);
            com.Parameters.AddWithValue("@nomFournisseur", this.nomFournisseur);
            com.Parameters.AddWithValue("@dateAchat", this.dateAchat);
            com.Parameters.AddWithValue("@etatMsecour", this.etatMsecour);
            com.Parameters.AddWithValue("@emplacement", this.emplacement);
            com.Parameters.AddWithValue("@Description", this.description);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            return "Emergency Material added successfuly";
        }

        // function that takes an material ID and return all its information as a datatable
        public DataTable getMaterialS(int materialID)
        {
            // checking if an material exists
            string query = "SELECT * FROM Secours WHERE Id_Msecour=@id";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@id", materialID);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
        public void modiftyMsecour(int materialID)
        {
            string query = "UPDATE Secours SET Nom_Msecour=@nomMsecour, Quantite_Msecour=@quantiteMsecour, prix_Msecour=@prixMsecour, Nom_fournisseur=@nomFournisseur, Date_Achat=@dateAchat, Etat_MaterailS=@etatMsecour , Description=@Description ,Emplacement_reserve=@emplacement" + " WHERE Id_Msecour=@ID";

            SqlCommand com = new SqlCommand(query, con);

            // params

            com.Parameters.AddWithValue("@ID", materialID);
            com.Parameters.AddWithValue("@nomMsecour", this.nomMsecour);
            com.Parameters.AddWithValue("@quantiteMsecour", this.quantiteMsecour);
            com.Parameters.AddWithValue("@prixMsecour", this.prixMsecour);
            com.Parameters.AddWithValue("@nomFournisseur", this.nomFournisseur);
            com.Parameters.AddWithValue("@dateAchat", this.dateAchat);
            com.Parameters.AddWithValue("@etatMsecour", this.etatMsecour);
            com.Parameters.AddWithValue("@emplacement", this.emplacement);
            com.Parameters.AddWithValue("@Description", this.description);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        // function that takes an material ID and deletes it
        public void deleteMsecour(int materialID)
        {
            string query = "DELETE FROM Secours WHERE  Id_Msecour=@ID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ID", materialID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // function that returns all the material as a datatable
        public DataTable showAllMsecour()
        {
            string query = "SELECT * FROM Secours";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        // function that returns a database of a result of search (searching by name and last name)
        public DataTable searchMsecour(string MaterialSearch)
        {
            string query = "SELECT * FROM Secours WHERE Nom_Msecour Like '%" + MaterialSearch + "%' OR Emplacement_reserve LIKE'%" + MaterialSearch + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;

        }
    }
}
