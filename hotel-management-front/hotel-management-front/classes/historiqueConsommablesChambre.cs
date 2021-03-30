using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_management_front.classes
{
    class historiqueConsommablesChambre
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

        public historiqueConsommablesChambre()
        {
        }
        public historiqueConsommablesChambre(string nomchamb, DateTime dateSej, string typeChambre, int idSej, int quantity, string design)
        {
            this.nomchambre = nomchamb;
            this.date = dateSej;
            this.type = typeChambre;
            this.IDsejour = idSej;
            this.quantite = quantity;
            this.designation = design;

        }
       public string addHistoriqueConsomablesChambre() 
        {
            string query1 = "INSERT INTO historiqueConsommablesChambre (Nom_chambre, date_sejour, type ,id_sejour ,quantity ,designation ) " +
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
            string query = "SELECT * FROM historiqueConsommablesChambre";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapt.Fill(data);
            return data;
        }
        public string remplirQuantity(int quant, int Idsejour, DateTime time, string designationA)
        {
            string query1 = "UPDATE historiqueConsommablesChambre SET quantity=@Quant  WHERE id_sejour=@ID AND  date_sejour =@dateSejour AND designation=@designationArticel ";

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
    }
}
