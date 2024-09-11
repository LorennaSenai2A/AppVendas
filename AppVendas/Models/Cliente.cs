namespace AppVendas.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public int Email { get; set; }
        public string Celular { get; set; }
        public int CadastroAtivo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
