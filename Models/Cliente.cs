using System.ComponentModel.DataAnnotations;

namespace MinhaApiOracle.Models
{
    public class Cliente
    {
        [Key]
        public int IdClientes { get; set; }

        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string Cpf { get; set; } = null!;

        [Required]
        public string Telefone { get; set; } = null!;

        [Required]
        public int EnderecoId { get; set; }

        public Endereco? Endereco { get; set; }  // Navegação opcional
    }
}
