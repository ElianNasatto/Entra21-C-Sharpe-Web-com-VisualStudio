using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class EstoqueRepositorio
    {
        //Atraves do objeto da conexao podera ter acesso ao sql
        Conexao conexao = new Conexao();

        public int Inserir(Estoque estoque)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO estoques (nome,valor,quantidade) VALUES (@NOME,@VALOR,@QUANTIDADE)";
            comando.Parameters.AddWithValue("@NOME", estoque.Nome);
            comando.Parameters.AddWithValue("@VALOR", estoque.Valor);
            comando.Parameters.AddWithValue("@QUANTIDADE", estoque.Quantidade);
            //Insere no banco e retorna o id do registro inserido
            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public List<Estoque> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM estoques";
            comando.Parameters.AddWithValue("@NOME", busca);

            List<Estoque> estoques = new List<Estoque>();
            DataTable tabela = new DataTable();


            tabela.Load(comando.ExecuteReader());

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Estoque estoque = new Estoque();
                estoque.Id = Convert.ToInt32(linha["id"]);
                estoque.Nome = linha["nome"].ToString();
                estoque.Quantidade = Convert.ToInt32(linha["quantidade"]);
                estoque.Valor = Convert.ToDecimal(linha["valor"]);
                estoques.Add(estoque);
            }

            return estoques;
        }

        public void Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "DELETE FROM estoques WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            comando.Connection.Close();

        }

        public bool Atualizar(Estoque estoque)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"UPDATE estoques SET nome = @NOME,valor=@VALOR,quantidade = @QUANTIDADE WHERE id = @id ,quantidade) VALUES (@NOME,@VALOR,@QUANTIDADE)";
            comando.Parameters.AddWithValue("@ID", estoque.Id);
            comando.Parameters.AddWithValue("@NOME", estoque.Nome);
            comando.Parameters.AddWithValue("@VALOR", estoque.Valor);
            comando.Parameters.AddWithValue("@QUANTIDADE", estoque.Quantidade);
            //Insere no banco e retorna o id do registro inserido
            int afetada = Convert.ToInt32(comando.ExecuteNonQuery());
            comando.Connection.Close();
            if (afetada != 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public Estoque ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = "SELECT * FROM estoques WHERE id=@ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());

            if (tabela.Rows.Count == 1)
            {
                DataRow linha = tabela.Rows[0];
                Estoque estoque = new Estoque();
                estoque.Id = Convert.ToInt32(linha["id"]);
                estoque.Nome = linha["nome"].ToString();
                estoque.Quantidade = Convert.ToInt32(linha["quantidade"]);
                estoque.Valor = Convert.ToDecimal(linha["valor"]);
                return estoque;
            }
            else
            {
                return null;
            }
        }


    }
}
