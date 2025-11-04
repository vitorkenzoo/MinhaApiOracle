using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Adicionado para [DatabaseGenerated]

namespace MinhaApiOracle.Models
{
    public class Moto
    {
        [Key]
        // Esta é a linha que corrige o erro "IDENTITY_INSERT"
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMoto { get; set; }
        
        public string Modelo { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public int Ano { get; set; }
        public string Status { get; set; } = null!;
    }
}
