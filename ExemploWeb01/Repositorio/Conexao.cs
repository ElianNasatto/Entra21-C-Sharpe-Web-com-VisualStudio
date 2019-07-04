using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Conexao
    {
        public SqlCommand Conectar()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\BD_Estoque.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            return comando;
        }
    }
}
