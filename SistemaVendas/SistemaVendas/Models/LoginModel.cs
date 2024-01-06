using SistemaVendas.Uteis;
using System.Data;

namespace SistemaVendas.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"select id from vendedor where email='{Email}' and senha ='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
