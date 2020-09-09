using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Formatting;
using System.Security.Cryptography;

namespace AspNetCore_CrudAdo.Models
{
    public class ClientesDAL : IClienteDAL
    {
        public static IConfiguration Configuration;

        public readonly string connectionString;
        public ClientesDAL(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = Configuration.GetConnectionString("CadastroDB");
        }



        public IEnumerable<Clientes> GetAllClientes()
        {
            List<Clientes> ListaClientes = new List<Clientes>();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ClienteId, Nome, Endereco, Numero, Complemento, Cidade, Estado, Cep from Clientes", conexao);
                cmd.CommandType = CommandType.Text;

                try
                {
                    conexao.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                   

                    while (reader.Read())
                    {
                        Clientes cliente = new Clientes();
                        cliente.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                        cliente.Nome = reader["Nome"].ToString();
                        cliente.Endereco = reader["Endereco"].ToString();
                        cliente.Numero = reader["Numero"].ToString();
                        cliente.Complemento = reader["Complemento"].ToString();
                        cliente.Cidade = reader["Cidade"].ToString();
                        cliente.Estado = reader["Estado"].ToString();
                        cliente.Cep = reader["Cep"].ToString();

                        ListaClientes.Add(cliente);
                    }
                    conexao.Close();

                }
                catch (Exception e)
                {
                    throw;
                }
                return ListaClientes;

            }

        }
        public void AddClientes(Clientes cliente)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string comandoSql = "insert into Clientes (Nome, Endereco, Numero, Complemento, Cidade, Estado, Cep) Values(@Nome, @Endereco, @Numero, @Complemento, @Cidade, @Estado, @Cep)";
                SqlCommand cmd = new SqlCommand(comandoSql, conexao);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
                cmd.Parameters.AddWithValue("@Complemento", cliente.Complemento);
                cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@Cep", cliente.Cep);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void UpdateCliente(Clientes cliente)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string commandSQL = "Update Clientes set Nome = @Nome, Endereco = @Endereco, Numero = @Numero, Complemento = @Complemento, Cidade = @Cidade, Estado = @Estado, Cep = @Cep where ClienteId = @ClienteId";

                SqlCommand cmd = new SqlCommand(commandSQL, conexao);
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
                cmd.Parameters.AddWithValue("@Complemento", cliente.Complemento);
                cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@Cep", cliente.Cep);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }


        public Clientes GetCliente(int? id)
        {
            Clientes cliente = new Clientes();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Clientes WHERE ClienteId = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, conexao);

                conexao.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cliente.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                    cliente.Nome = reader["Nome"].ToString();
                    cliente.Endereco = reader["Endereco"].ToString();
                    cliente.Numero = reader["Numero"].ToString();
                    cliente.Complemento = reader["Complemento"].ToString();
                    cliente.Cidade = reader["Cidade"].ToString();
                    cliente.Estado = reader["Estado"].ToString();
                    cliente.Cep = reader["Cep"].ToString();
                }

            }
            return cliente;
        }

        public void DeleteCliente(int? id)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string commnadSQL = "Delete from Clientes where ClienteId = @ClienteId";
                SqlCommand cmd = new SqlCommand(commnadSQL, conexao);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ClienteId", id);

                conexao.Open();
                cmd.ExecuteReader();
                conexao.Close();
            }
        }



    }
}
