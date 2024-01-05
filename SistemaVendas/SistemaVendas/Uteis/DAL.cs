using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaVendas.Uteis
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "sistema_venda";
        private static string User = "root";
        private static string Password = "";
        private static string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;Charset=utf8;";

        private static MySqlConnection Connection;

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        public DataTable RetDataTable(string sql)
        {
            DataTable data = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(data);
            return data;
        }
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Connection);
            command.ExecuteNonQuery();
        }


    }
}
