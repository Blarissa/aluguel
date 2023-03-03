namespace Aluguel.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public float Valor { get; set; }
        public DateTime? DataHoraPagamento { get; set; }
        
        public int CartaoDeCreditoId { get; set; }
        public int CiclistaId { get; set; }
        public int BicicletaId { get; set; }        
        public int TrancaId { get; set; }
        public int? DevolucaoId { get; set; }
        
        public virtual CartaoDeCredito CartaoDeCredito { get; set; }
        public virtual Ciclista Ciclista { get; set; }        
        public virtual Bicicleta Bicicleta { get; set; }                     
        public virtual Tranca Tranca { get; set; }          
        public virtual Devolucao? Devolucao { get; set; }
    }
}
