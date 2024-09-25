using System.ComponentModel.DataAnnotations;

namespace AppVendas.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo não pode ser vazio!")]
        [MaxLength(100, ErrorMessage = "O campo deve ter, no máximo, 100 caracteres!")]
        [MinLength(3, ErrorMessage = "O campo deve ter, no minimo, 3 caracteres!")]
        public string ProdutoNome { get; set; }
        [Required(ErrorMessage = "O campo não pode ser vazio!")]
        [Range(0, double.MaxValue, ErrorMessage = "A valor do produto deve ser um número positivo!")]
        public double Valor { get; set; }
        [Display(Name = "Estoque atual")]
        [Required(ErrorMessage = "O campo não pode ser vazio!")]
        [Range(0, double.MaxValue, ErrorMessage = "A quantidade em estoque deve positivo!")]
        public double QtdeEstoque { get; set; }
        [Display(Name = "Ativo?")]
        public bool CadastroAtivo { get; set; }

        /*Chave estrangeira */

        [Required(ErrorMessage = "O campo não pode ser vazio!")]
        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}
