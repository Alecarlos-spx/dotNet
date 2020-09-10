using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_CrudDapper.Entities
{
    public class Produtos
    {
        [Key]
        [Display(Name = "Id")]
        public int ProdutoId { get; set; }
        [Required]
        [Display(Name ="Nome do Produto")]
        [StringLength(100, ErrorMessage = "O Nome deve ter entre 1 até 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Estoque")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Valor deve ser maior ou igual a 1")]
        public int Estoque { get; set; }
        [Required]
        [Display(Name = "Preço")]
        public float Preco { get; set; }
    }
}
