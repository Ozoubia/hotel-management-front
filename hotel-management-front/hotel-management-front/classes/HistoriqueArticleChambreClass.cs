using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    class HistoriqueArticleChambreClass
    {
        // connection variable
        SqlConnection con = new SqlConnection(GlobalVariable.databasePath);


        //VAR

        string nomchambre;
        DateTime date;
        string type;
        int IDsejour;
        int quantite;
        string designation;
       

        public HistoriqueArticleChambreClass()
        {
        }
        public HistoriqueArticleChambreClass(string nomchamb, DateTime dateSej,  string typeChambre  , int idSej , int quantity , string design)
        {
            this.nomchambre = nomchamb;
            this.date = dateSej;
            this.type = typeChambre;
            this.IDsejour = idSej;
            this.quantite = quantity;
            this.designation = design;

        }
        public string addHistorique()
        {
            // checking if an employee exists
          // string query = "SELECT * FROM HistoriqueArticleChambre WHERE Nom_chambre=@name AND date_sejour=@time";
            //SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //query parameters 
            //ada.SelectCommand.Parameters.AddWithValue("@name", this.nomchambre);
            //ada.SelectCommand.Parameters.AddWithValue("@time", this.date);

            // command result 
            //DataTable dtbl = new DataTable();
            //ada.Fill(dtbl);
            //user already exists 
            //if (dtbl.Rows.Count == 1)
            //{
              //  return "Employee already exists";
            //}
           // else { 
                string query1 = "INSERT INTO HistoriqueArticleChambre (Nom_chambre, date_sejour, type ,id_sejour ,quantity ,designation ) " +
                   "VALUES (@NomChambre, @Date, @Type ,@idSejour ,@quant , @designa )";

            SqlCommand com = new SqlCommand(query1, con);

            // params
            com.Parameters.AddWithValue("@NomChambre", this.nomchambre);
            com.Parameters.AddWithValue("@Date", this.date);
            com.Parameters.AddWithValue("@Type", this.type);
            com.Parameters.AddWithValue("@idSejour", this.IDsejour);
            com.Parameters.AddWithValue("@quant ", this.quantite);
            com.Parameters.AddWithValue("@designa", this.designation);


            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        //}
            return "Add";
        }
        public DataTable showAllhistoriqueChambre()
        {
            string query = "SELECT * FROM HistoriqueArticleChambre";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            con.Close();
            return data;
            
        }
        public DataTable showIDsejour(DateTime date1, string nomChambre)
        {
            string query = "SELECT id_sejour FROM HistoriqueArticleChambre WHERE Nom_chambre=@nom AND date_sejour=@date";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@nom", nomChambre);
            ada.SelectCommand.Parameters.AddWithValue("@date", DateTime.Parse(date1.ToString()));
            // command result 
            DataTable data = new DataTable();
            ada.Fill(data);
            return data;

        }
        public DataTable showID(DateTime date1, string nomChambre)
        {
            string query = "SELECT ID_historiqueArticleChambre FROM HistoriqueArticleChambre WHERE Nom_chambre=@nom AND date_sejour=@date";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@nom", nomChambre);
            ada.SelectCommand.Parameters.AddWithValue("@date", DateTime.Parse(date1.ToString()));
            // command result 
            DataTable data = new DataTable();
            ada.Fill(data);
            return data;

        }
        public string remplirQuantity( int quant ,int Idsejour , DateTime time  , string designationA) 
        {
            string query1 = "UPDATE HistoriqueArticleChambre SET quantity=@Quant  WHERE id_sejour=@ID AND  date_sejour =@dateSejour AND designation=@designationArticel ";

            SqlCommand com1 = new SqlCommand(query1, con);

            // params
            com1.Parameters.AddWithValue("@Quant", quant);
            com1.Parameters.AddWithValue("@designationArticel", designationA);
            com1.Parameters.AddWithValue("@ID", Idsejour);
            com1.Parameters.AddWithValue("@dateSejour", time);


          
            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
            return "modifier";
        }

        public DataTable showAllhistoriqueChambreBydesignation(string designa)
        {
         
            string query = "SELECT * FROM HistoriqueArticleChambre WHERE designation=@design AND quantity>0";

            SqlDataAdapter ada = new SqlDataAdapter(query, con);


            //query parameters 
            ada.SelectCommand.Parameters.AddWithValue("@design", designa);

            // command result 
            DataTable dtbl = new DataTable();
            ada.Fill(dtbl);

            return dtbl;
        }
    } 
}
