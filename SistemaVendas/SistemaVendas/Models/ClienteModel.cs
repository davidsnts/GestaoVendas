using SistemaVendas.Uteis;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SistemaVendas.Models
{
    public class ClienteModel
    {
        
        public string Id { get; set; }
        [Required(ErrorMessage ="Informe o dado abaixo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o dado abaixo")]
        public string cpf_cnpj { get; set; }
        [Required(ErrorMessage = "Informe o dado abaixo")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o dado abaixo")]
        public string Senha { get; set; }

        public List<ClienteModel> ListarTodosClientes ()
        {
            List<ClienteModel> lista = new List<ClienteModel> ();   
           ClienteModel item;
            DAL objDAL = new DAL();
            string sql = "select id, nome, cpf_cnpj, email,senha from cliente order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel
                {
                    Id = dt.Rows[i]["id"].ToString(),
                    Nome = dt.Rows[i]["nome"].ToString(),
                    cpf_cnpj = dt.Rows[i]["cpf_cnpj"].ToString(),
                    Email = dt.Rows[i]["email"].ToString(),
                    Senha = dt.Rows[i]["senha"].ToString()
                };
                lista.Add (item);   
            }
            return lista;
        }

        public void Inserir() 
        {
            DAL objDAL = new DAL();
            string sql = $"INSERT INTO CLIENTE(NOME, CPF_CNPJ, EMAIL, SENHA) VALUES ('{Nome}', '{cpf_cnpj}','{Email}','{Senha}')";

            objDAL.ExecutarComandoSQL(sql);


        }
    }
}
