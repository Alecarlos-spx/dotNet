using AspNetCore_CrudDapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_CrudDapper.Repository
{
    public interface IProdutoRepository
    {
        List<Produtos> GetProdutos();
        Produtos Get(int id);
        int Add(Produtos produto);
        int Edit(Produtos produto);
        int Delete(int id);
    }
}
