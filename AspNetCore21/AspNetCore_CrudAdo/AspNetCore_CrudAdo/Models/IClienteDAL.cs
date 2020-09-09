using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_CrudAdo.Models
{
    public interface IClienteDAL
    {
        IEnumerable<Clientes> GetAllClientes();
        void AddClientes(Clientes cliente);
        void UpdateCliente(Clientes cliente);
        Clientes GetCliente(int? id);
        void DeleteCliente(int? id);

    }
}
