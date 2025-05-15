namespace MinhaApiOracle.Models
{
    public class EstacionamentoMoto
    {
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public int Capacidade { get; set; }
        public int QtdAtual { get; set; }
    }
}
