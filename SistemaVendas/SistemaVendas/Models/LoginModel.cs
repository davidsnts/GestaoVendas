using SistemaVendas.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class LoginModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage="Informe o E-mail do usuário")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="O e-mail é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"select ID, NOME from vendedor where email='{Email}' and senha ='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt.Rows.Count == 1)
            {
                Id = dt.Rows[0]["ID"].ToString();
                Nome = dt.Rows[0]["NOME"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
