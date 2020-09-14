using AspNetCore_CrudWebApi.Entities;
using System.Collections.Generic;

namespace AspNetCore_CrudWebApi.Repository
{
    public interface IClienteRepository
    {
        List<Clientes> GetClientes();
        Clientes Get(int id);
        int Add(Clientes cliente);
        int Edit(Clientes cliente);
        int Delete(int id);
    }
}
