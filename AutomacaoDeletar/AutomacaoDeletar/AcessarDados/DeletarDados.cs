using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoDeletar.AcessarDados
{
    public class DeletarDados
    {
        AcessarDados _AcessoSQL = new AcessarDados();

        //Le e executa a procedure que deleta os registros da tabela escolhida
        public void Procedure(string tabela)
        {
            _AcessoSQL.LimparParametros();

            _AcessoSQL.AdicionarParametros(new SqlParameter("@tabela", tabela));

            _AcessoSQL.ExecutarProcedure("ProcedureDeletar");

        }

        //Metodo para executar o select para acessar as tabelas no BD
        public List<string> ExecutarSelect(string select)
        {
            _AcessoSQL.LimparParametros();

            return _AcessoSQL.ExecutarSQL(select);
        }
    }
}
