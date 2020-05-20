using System.Data;
using MySql.Data.MySqlClient;

namespace project
{
    class variables
    {
        public static MySqlConnection conn;
        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;
        public static DataTable dt;
        public static DataSet ds;
        public static string sql;
        ///// Переменнные моего очка
        // Имя, описание и фото фонда
        public static string gCharityName;
        public static string gCharityDescription;
        public static string gCharityImage;
        // Сумма пожертвования
        public static int gCharityCash;
        // Месяц и год карты
        public static string gMonthCard;
        public static string gYearCard;
        // Имя бегуна
        public static string gNameRunner;
        // Данные пользователя
        public static string gUserId;
        public static string gUserLogin;
        public static string gUserRole;
        public static string gUserPassword;
    }
}
