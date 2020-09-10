using AspNetCore_CrudDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AspNetCore_CrudDapper.Pages.Produto
{
    public class IndexModel : PageModel
    {
        private readonly IProdutoRepository _produtoRepository;

        public IndexModel(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [BindProperty]
        public List<Entities.Produtos> listaProdutos { get; set; }

        [BindProperty]
        public Entities.Produtos produto { get; set; }

        [TempData]
        public string Message { get; set; }


        public void OnGet()
        {
            listaProdutos = _produtoRepository.GetProdutos();
        }

        public IActionResult OnPostDelete(int id)
        {

            if (id > 0)
            {
                var count = _produtoRepository.Delete(id);
                if(count > 0)
                {
                    Message = "Produto Deletado com sucesso!";
                    return RedirectToPage("/Produto/Index");
                }
            }

            return Page();
        }
    }
}
