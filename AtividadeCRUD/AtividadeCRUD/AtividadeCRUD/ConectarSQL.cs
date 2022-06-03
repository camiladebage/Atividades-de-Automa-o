using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeCRUD
{
    public class ConectarSQL
    {

        private SqlParameterCollection _parametros;

        public ConectarSQL()
        {
            _parametros = new SqlCommand().Parameters;
        }

        private SqlConnection ObterConexaoSQL()
        {
            return new SqlConnection("Data Source=DESKTOP-OD1QGET\\SQLEXPRESS;Initial Catalog=AtividadeCRUD;Integrated Security=True");
        }

        public void AdicionarParametros(SqlParameter parametro)
        {
            _parametros.Add(parametro);
        }
    
        public void LimparParametros()
        {
            _parametros.Clear();
        }

        private void AdicionarParametros(SqlCommand sqlCommand)
        {
         
            sqlCommand.Parameters.Clear();

          
            foreach (SqlParameter sqlParameter in _parametros)
            {
                sqlCommand.Parameters.Add(
                    new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
            }
        }

        public object ExecutarSQL(string comando)
        {
            using (SqlConnection SQLConn = ObterConexaoSQL())
            {
                SQLConn.Open(); 
                SqlCommand sqlCommand = SQLConn.CreateCommand(); ;
                sqlCommand.CommandTimeout = 50000;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = comando;
                AdicionarParametros(sqlCommand);

                return sqlCommand.ExecuteScalar();
            }
        }
    }
}
