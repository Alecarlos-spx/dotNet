using AspNetCore_CrudWebApi.Entities;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AspNetCore_CrudWebApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("CadastroDB");
        }

        public int Add(Clientes cliente)
        {
            int count = 0;

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "INSERT INTO CLIENTES(NOME, ENDERECO, NUMERO, COMPLEMENTO, CIDADE, ESTADO, CEP) VALUES (@NOME, @ENDERECO, @NUMERO, @COMPLEMENTO, @CIDADE, @ESTADO, @CEP)";
                 
                    count = conexao.Execute(query, cliente);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
            }
            return count;
        }

        public int Delete(int id)
        {
            int count = 0;

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "DELETE FROM CLIENTES WHERE CLIENTEID = " + id;
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

        public int Edit(Clientes cliente)
        {
            int count = 0;

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "UPDATE CLIENTES SET NOME = @NOME, ENDERECO = @ENDERECO, NUMERO = @NUMERO, COMPLEMENTO = @COMPLEMENTO, CIDADE = @CIDADE, ESTADO = @ESTADO, CEP = @CEP WHERE CLIENTEID = "+ cliente.ClienteId;
                    count = conexao.Execute(query, cliente);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
            }
            return count;
        }

        public Clientes Get(int id)
        {
            Clientes cliente = new Clientes();
            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "SELECT * FROM CLIENTES WHERE CLIENTEID = " + id;
                    cliente = conexao.Query<Clientes>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return cliente;
            }
        }

        public List<Clientes> GetClientes()
        {
            List<Clientes> clientes = new List<Clientes>();

            using (var conexao = new SqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();
                    var query = "SELECT * FROM CLIENTES";
                    clientes = conexao.Query<Clientes>(query).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }
                return clientes;

            }
        }
    }
}
