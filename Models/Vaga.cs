using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Adicionado

namespace MinhaApiOracle.Models
{
    public class Vaga
    {
        [Key] // Diz ao EF que esta é a Chave Primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Diz ao EF que o Banco de Dados gera este valor
        public int Id { get; set; }
        
        // "Numero" é apenas um campo normal agora
        public int Numero { get; set; } 
        
        public string Ocupado { get; set; } = null!;
    }
}
