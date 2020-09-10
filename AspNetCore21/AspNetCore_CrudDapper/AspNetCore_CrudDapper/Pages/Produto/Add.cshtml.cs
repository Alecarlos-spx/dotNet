using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_CrudDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCore_CrudDapper.Pages.Produto
{
    public class AddModel : PageModel
    {
        private readonly IProdutoRepository _produtoRepository;

        public AddModel(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [BindProperty]
        public Entities.Produtos produto { get; set; }

        [TempData]
        public string Message { get; set; }



        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var count = _produtoRepository.Add(produto);
                if(count > 0)
                {
                    Message = "Novo Produto incluído com sucesso!";
                    return RedirectToPage("/Produto/Index");
                }
            }
            return Page();
        }
    }
}
