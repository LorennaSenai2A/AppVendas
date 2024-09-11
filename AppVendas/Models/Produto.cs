namespace AppVendas.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public double Valor { get; set; }
        public double QtdeEstoque { get; set; }
        public bool CadastroAtivo { get; set; }

        /*Chave estrangeira */

        public Guid CatagoriaId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}
