using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AutomacaoDeletar.AcessarDados
{
    public class AcessarDados
    {

        //Lista de todos os parametros de entrada da PROC
        private SqlParameterCollection _ListaParametros;

        public AcessarDados()
        {
            _ListaParametros = new SqlCommand().Parameters;
        }

        //Cria a conexão com o Banco de Dados
        private SqlConnection ObterConexaoSQL()
        {
            return new SqlConnection("Data Source=DESKTOP-OD1QGET\\SQLEXPRESS;Initial Catalog=ATIVIDADEDELETAR;Integrated Security=True");
        }

        //Metodo para adicionar os paremetros
        public void AdicionarParametros(SqlParameter parametro)
        {
            _ListaParametros.Add(parametro);
        }

        //Metodo para limpar os parametros das variaveis.
        public void LimparParametros()
        {
            _ListaParametros.Clear();
        }

        private void AdicionarParametros(SqlCommand sqlCommand)
        {
            //Limpar todos os paremetros
            sqlCommand.Parameters.Clear();

            //Percorrer todos os elemtros contidos na lista de parametros
            foreach (SqlParameter sqlParameter in _ListaParametros)
            {
                sqlCommand.Parameters.Add(
                    new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }
        }

        //Metodo para achar a procedure no banco de dados
        public object ExecutarProcedure(string strComando)
        {
            using (SqlConnection SQLConn = ObterConexaoSQL())
            {
                SQLConn.Open(); // abrir conexao
                SqlCommand sqlCommand = SQLConn.CreateCommand(); ;
                sqlCommand.CommandTimeout = 50000;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = strComando;
                AdicionarParametros(sqlCommand);


                return sqlCommand.ExecuteScalar();
            }
        }


        
        public List<string> ExecutarSQL(string strComando)
        {
            using (SqlConnection SQLConn = ObterConexaoSQL())
            {
                SQLConn.Open(); // abrir conexao
                SqlCommand sqlCommand = SQLConn.CreateCommand(); ;
                sqlCommand.CommandTimeout = 50000;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = strComando;


                List<string> dados = new List<string>();
                SqlDataReader leitor = sqlCommand.ExecuteReader();

                //Le todas as linhas que retornaram do BD
                while (leitor.Read())
                {
                    dados.Add(leitor.GetString(0));
                }
                return dados;
            }
        }

    }
}
