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
                //get item quantity
                string query5 = "SELECT quantity_cuisine FROM cuisine WHERE reference=@reference";
                SqlDataAdapter ada2 = new SqlDataAdapter(query5, con);
                ada2.SelectCommand.Parameters.AddWithValue("@reference", this.reference);
                // command result 
                DataTable dtb2 = new DataTable();
                ada.Fill(dtb2);
                int qun = (int)dtb2.Rows[0]["quantity"];
                int resultn = qun + this.quantity;
                //the case of the article already exists been modified some attributes

                string query4 = "UPDATE article SET quantity=@quantity , stock_alert=@stockAlert , quantity_utilisee=0 , date_expiration=@dateExp ,id_fournisseur= @idFournisseur ,prix_achat=@prixAchat ,prix_vente=@prixVente  , date_arrivage=@dateArrivage WHERE reference=@reference ";


                SqlCommand com1 = new SqlCommand(query4, con);
                com1.Parameters.AddWithValue("@reference", this.reference);
                com1.Parameters.AddWithValue("@quantity", resultn);
                com1.Parameters.AddWithValue("@stockAlert", this.stockAlert);
                com1.Parameters.AddWithValue("@dateExp", this.dateExp);
                com1.Parameters.AddWithValue("@idFournisseur", idFournisseur);
                com1.Parameters.AddWithValue("@prixAchat", this.prixAchat);
                com1.Parameters.AddWithValue("@prixVente", this.prixVente);
                com1.Parameters.AddWithValue("@dateArrivage", this.dateArrivage);
                con.Open();
                com1.ExecuteNonQuery();
                con.Close();

                // inseting into the historique Article
                string query6 = "INSERT INTO historiqueArticle ( referenceArticl , quantityArticl , date_expirationArticl , id_fournisseur , prix_achatArticl , prix_venteArticl , date_arrivageArticl , designationArticl)" +
                    "VALUES (@reference , @quantity , @dateExp ,  @idFournisseur , @prixAchat , @prixVente , @dateArrivage , @designation)";
                SqlCommand com2 = new SqlCommand(query6, con);
                // params
                com2.Parameters.AddWithValue("@reference", this.reference);
                com2.Parameters.AddWithValue("@quantity", this.quantity);
                com2.Parameters.AddWithValue("@dateExp", this.dateExp);
                com2.Parameters.AddWithValue("@idFournisseur", idFournisseur);
                com2.Parameters.AddWithValue("@prixAchat", this.prixAchat);
                com2.Parameters.AddWithValue("@prixVente", this.prixVente);
                com2.Parameters.AddWithValue("@dateArrivage", this.dateArrivage);
                com2.Parameters.AddWithValue("@designation", this.designation);
                con.Open();
                com2.ExecuteNonQuery();
                con.Close();
                return "5";

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
                string query2 = "INSERT INTO article (reference, designation, famille, quantity, stock_alert, quantity_utilisee, date_expiration, id_fournisseur, prix_achat, prix_vente, localisation, date_arrivage , type_consommable) " +
                    "VALUES (@reference, @designation, @famille, @quantity, @stockAlert, 0, @dateExp, @idFournisseur, @prixAchat, @prixVente, @localisation, @dateArrivage , 'null')";

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
                // inseting into the historique Article
                string query6 = "INSERT INTO historiqueArticle ( referenceArticl , quantityArticl , date_expirationArticl , id_fournisseur , prix_achatArticl , prix_venteArticl , date_arrivageArticl , designationArticl)" +
                    "VALUES (@reference , @quantity , @dateExp ,  @idFournisseur , @prixAchat , @prixVente , @dateArrivage , @designation)";
                SqlCommand com2 = new SqlCommand(query6, con);
                // params
                com2.Parameters.AddWithValue("@reference", this.reference);
                com2.Parameters.AddWithValue("@quantity", this.quantity);
                com2.Parameters.AddWithValue("@dateExp", this.dateExp);
                com2.Parameters.AddWithValue("@idFournisseur", idFournisseur);
                com2.Parameters.AddWithValue("@prixAchat", this.prixAchat);
                com2.Parameters.AddWithValue("@prixVente", this.prixVente);
                com2.Parameters.AddWithValue("@dateArrivage", this.dateArrivage);
                com2.Parameters.AddWithValue("@designation", this.designation);
                con.Open();
                com2.ExecuteNonQuery();
                con.Close();


                // add attribute to cuisine


                // add attribute to hotel

                return "Article added successfuly";
            }
        }


        //  returns all articles as spreadsheet with proofread
        public DataTable showAllArticles()
        {
            string query = "SELECT article.reference, article.designation, article.famille , article.quantity, article.stock_alert, article.quantity_utilisee, article.date_expiration, fournisseur.name, fournisseur.lname, article.prix_achat, article.prix_vente, article.localisation, article.date_arrivage, article.type_consommable FROM article" +
                " INNER JOIN fournisseur ON fournisseur.id_fournisseur = article.id_fournisseur";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        // function that returns all the articles as a datatable

        public DataTable showAllArticles1()
        {
            string query = "SELECT reference , designation , famille , quantity, stock_alert , prix_achat ,prix_vente,localisation , type_consommable FROM article" +
                " INNER JOIN fournisseur ON fournisseur.id_fournisseur = article.id_fournisseur";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }

        // function that takes a type and returns the name 
        public DataTable FilterByLocalisation(string type)
        {
            string query = "SELECT designation , quantity FROM article WHERE type_consommable=@type";

            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@type", type);

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
        // function that returns a database of a result of search (searching by name and last name)
        public DataTable searchArticle(string searchArticle)
        {
            string query = "SELECT * FROM article WHERE reference Like '%" + searchArticle + "%' OR designation LIKE'%" + searchArticle + "%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        public DataTable showAllHistoriqueArticle(string reference)
        {
            string query = "SELECT historiqueArticle.referenceArticl, historiqueArticle.quantityArticl , historiqueArticle.date_expirationArticl ,  fournisseur.name, fournisseur.lname, historiqueArticle.prix_achatArticl, historiqueArticle.prix_venteArticl, historiqueArticle.date_arrivageArticl , historiqueArticle.designationArticl  FROM historiqueArticle  " +
                " INNER JOIN fournisseur ON fournisseur.id_fournisseur = historiqueArticle.id_fournisseur " +
                 "WHERE historiqueArticle.referenceArticl=@reference";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@reference", reference);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
        public DataTable showQuantite(string desig)
        {
            // checking if an employee exists
            string query = "SELECT quantity FROM article WHERE designation=@Desig";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@Desig", desig);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
        public void modiftyquantity(string Designa , int quant)
        {
            string query1 = "SELECT quantity FROM article WHERE designation=@Designa ";
            SqlDataAdapter ada = new SqlDataAdapter(query1, con);

            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@Designa", Designa);
          

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);
            int qun1 = (int)dtbl.Rows[0]["quantity"];
            string query = "UPDATE article SET quantity=@quantite WHERE designation=@Designa";
            SqlCommand com = new SqlCommand(query, con);
            int qun = qun1 - quant;
                // params
            com.Parameters.AddWithValue("@quantite", qun);
            com.Parameters.AddWithValue("@Designa", Designa);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
    }
}
