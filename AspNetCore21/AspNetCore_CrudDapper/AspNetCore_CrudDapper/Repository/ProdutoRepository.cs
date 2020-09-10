using AspNetCore_CrudDapper.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_CrudDapper.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public ProdutoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("CadastroDB");
        }



        public int Add(Produtos produto)
        {
            int count = 0;

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "INSERT INTO Produtos(Nome, Estoque, Preco) VALUES (@Nome, @Estoque, @Preco);" +
                                "SELECT CAST(SCOPE_IDENTITY() AS  INT);";
                    count = conexao.Execute(query, produto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return count;
            }
        }

        public int Delete(int id)
        {
            var count = 0;

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "DELETE FROM PRODUTOS WHERE PRODUTOID = " + id;
                    count = conexao.Execute(query);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return count;
            }
        }

        public int Edit(Produtos produto)
        {
            var count = 0;
            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "UPDATE PRODUTOS SET NOME = @NOME, ESTOQUE = @ESTOQUE, PRECO = @PRECO WHERE PRODUTOID =  " + produto.ProdutoId;
                    count = conexao.Execute(query, produto);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return count;
            }
        }

        public Produtos Get(int id)
        {
            Produtos produto = new Produtos();

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "SELECT * FROM PRODUTOS WHERE PRODUTOID = " + id;
                    produto = conexao.Query<Produtos>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                   throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return produto;
            }
        }

        public List<Produtos> GetProdutos()
        {
            List<Produtos> produtos = new List<Produtos>();

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "SELECT * FROM PRODUTOS";
                    produtos = conexao.Query<Produtos>(query).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return produtos;
            }
        }
    }
}
