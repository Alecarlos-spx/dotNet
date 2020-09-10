using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_CrudDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCore_CrudDapper.Pages.Produto
{
    public class EditModel : PageModel
    {
        private readonly IProdutoRepository _produtoRepository;

        public EditModel(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        [BindProperty]
        public Entities.Produtos produto { get; set; }



        public void OnGet(int id)
        {
            produto = _produtoRepository.Get(id);
        }

        public IActionResult OnPost()
        {
            var dados = produto;
            if (ModelState.IsValid)
            {
                var count = _produtoRepository.Edit(dados);
                if(count > 0)
                {
                    return RedirectToPage("/Produto/Index");
                }
            }
            return Page();
        }


    }
}
