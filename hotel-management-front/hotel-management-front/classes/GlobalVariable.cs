using System.Collections.Generic;
using System.Data;
using System.Windows.Controls;

namespace hotel_management_front.classes
{
    public class GlobalVariable
    {
        //used for tabs functionality
        public static TabControl tbControl;
        //
        //username
        public static string username;
        //
        //  var refresh 
        public static bool tast = false;
        //
        public static DataRowView dataRowView;
        //zinou 
        public static string databasePath = "Data Source=DESKTOP-BI9TF77\\SQLEXPRESS;Initial Catalog=hotel_db;Integrated Security=True";
        // Contenu de la table
        public static string ContenuTable;
        // type chambre 
        public static string chambreType;
        // type chambre 
        public static string chambreType1;
        // prixtotal
        public static double prixTotal;



        //used to store the logged in user permissions (exp : add client ...)
        public static List<string> permissionList = new List<string>();

        //ouss 
        // public static string databasePath = "Data Source=DESKTOP-7JO0IDO\\SQLEXPRESS;Initial Catalog=hotel_db;Integrated Security=True";
    }
}
