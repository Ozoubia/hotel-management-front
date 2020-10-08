using System.Data;
using System.Windows.Controls;

namespace hotel_management_front.classes
{
    public class GlobalVariable
    {
        //used for tabs functionality
        public static TabControl tbControl;
        //
        public static DataRowView dataRowView;
        //zinou 
        public static string databasePath = "Data Source=DESKTOP-BI9TF77\\SQLEXPRESS;Initial Catalog=hotel_db;Integrated Security=True";

        //ouss 
        //public static string databasePath = "Data Source=DESKTOP-7JO0IDO\\SQLEXPRESS;Initial Catalog=hotel_db;Integrated Security=True";
    }
}
