namespace Aluguel.Models
{
    public class Devolucao
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public float Valor { get; set; }
        public DateTime DataHoraPagamento { get; set; }
        public int EmprestimoId { get; set; }
        public int TrancaId { get; set; }
        public int CartaoDeCreditoId { get; set; }
    }
}
