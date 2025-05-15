using System.ComponentModel.DataAnnotations;

namespace MinhaApiOracle.Models
{
    public class Moto
    {
        [Key]
        public int IdMoto { get; set; }
        public string Modelo { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public int Ano { get; set; }
        public string Status { get; set; } = null!;
    }
}
