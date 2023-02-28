namespace Aluguel.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public float Valor { get; set; }
        public DateTime DataHoraPagamento { get; set; }
        public int CiclistaId { get; set; }
        public int BicicletaId { get; set; }
        public int TrancaId { get; set; }
    }
}
