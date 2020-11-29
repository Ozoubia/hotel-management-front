using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Media.Animation;

namespace hotel_management_front.classes
{
    class article
    {
        //vars 
        string reference;
        string designation;
        string familly;
        int quantity;
        int stockAlert;
        DateTime dateExp;
        string fournisseurName;
        int prixAchat;
        int prixVente;
        string localisation;
        DateTime dateArrivage;


        // constructor
        public article() { }

        public article(string reference, string designation, string familly, int quantity, int stockAlert, DateTime dateExpir, string fournisseur, 
                        int prixAchat, int prixVente, string localisation, DateTime dateArrivage)
        {
            this.reference = reference;
            this.designation = designation;
            this.familly = familly;
            this.quantity = quantity;
            this.stockAlert = stockAlert;
            this.dateExp = dateExpir;
            this.fournisseurName = fournisseur;
            this.prixAchat = prixAchat;
            this.prixVente = prixVente;
            this.localisation = localisation;
            this.dateArrivage = dateArrivage;
        }

        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);

        public string addArticle()
        {
            // checking if an employee exists
            string query = "SELECT * FROM article WHERE reference=@reference";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@reference", this.reference);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            //user already exists 
            if (dtbl.Rows.Count == 1)
            {
                return "Article already exists";
            }
            else
            {

                //getting the fournisseur ID

                //// separating name and last name
                string[] fullname = this.fournisseurName.Split(' ');

                // getting client id 
                string query1 = "SELECT id_fournisseur FROM fournisseur WHERE name=@name AND lname=@lname";
                SqlDataAdapter ada1 = new SqlDataAdapter(query1, con);
                ada1.SelectCommand.Parameters.AddWithValue("@name", fullname[0]);
                ada1.SelectCommand.Parameters.AddWithValue("@lname", fullname[1]);
                DataTable dtbl1 = new DataTable();
                ada1.Fill(dtbl1);
                int idFournisseur = int.Parse(dtbl1.Rows[0]["id_fournisseur"].ToString());


                // inseting into the general stock
                string query2 = "INSERT INTO article (reference, designation, famille, quantity, stock_alert, quantity_utilisee, date_expiration, id_fournisseur, prix_achat, prix_vente, localisation, date_arrivage) " +
                    "VALUES (@reference, @designation, @famille, @quantity, @stockAlert, 0, @dateExp, @idFournisseur, @prixAchat, @prixVente, @localisation, @dateArrivage)";

                SqlCommand com = new SqlCommand(query2, con);

                // params
                com.Parameters.AddWithValue("@reference", this.reference);
                com.Parameters.AddWithValue("@designation", this.designation);
                com.Parameters.AddWithValue("@famille", this.familly);
                com.Parameters.AddWithValue("@quantity", this.quantity);
                com.Parameters.AddWithValue("@stockAlert", this.stockAlert);
                com.Parameters.AddWithValue("@dateExp", this.dateExp);
                com.Parameters.AddWithValue("@idFournisseur", idFournisseur);
                com.Parameters.AddWithValue("@prixAchat", this.prixAchat);
                com.Parameters.AddWithValue("@prixVente", this.prixVente);
                com.Parameters.AddWithValue("@localisation", this.localisation);
                com.Parameters.AddWithValue("@dateArrivage", this.dateArrivage);


                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                // add attribute to room
                if (this.localisation == "Material")
                {
                    string query3 = "ALTER TABLE etat_lieu_room ADD " + this.designation + " int NULL" ;
                    SqlCommand com3 = new SqlCommand(query3, con);

                    con.Open();
                    com3.ExecuteNonQuery();
                    con.Close();
                }

                // add attribute to cuisine


                // add attribute to hotel

                return "Article added successfuly";
            }
        }


        // function that returns all the articles as a datatable
        public DataTable showAllArticles()
        {
            string query = "SELECT article.reference, article.designation, article.famille , article.quantity, article.stock_alert, article.quantity_utilisee, article.date_expiration, fournisseur.name, fournisseur.lname, article.prix_achat, article.prix_vente, article.localisation, article.date_arrivage FROM article" +
                " INNER JOIN fournisseur ON fournisseur.id_fournisseur = article.id_fournisseur";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }


        // function that takes a type and returns the name 
        public DataTable FilterByLocalisation(string localisation)
        {
            string query = "SELECT designation FROM article WHERE localisation=@loca";
            
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@loca", localisation);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
        public DataTable showIDArticle(string desig)
        {
            // checking if an employee exists
            string query = "SELECT id_article FROM article WHERE designation=@Desig";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@Desig", desig);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
        public void deleteActicle(string reference)
        {
            string query = "DELETE FROM article WHERE reference=@ID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ID", reference);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
