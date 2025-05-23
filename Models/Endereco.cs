namespace MinhaApiOracle.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Cep { get; set; } = null!;

        public ICollection<Cliente>? Clientes { get; set; }
    }
}
