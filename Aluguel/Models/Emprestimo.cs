namespace Aluguel.Models
{
    public class Emprestimo
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public float Valor { get; set; }
        public DateTime? DataHoraPagamento { get; set; }
        
        public Guid CartaoDeCreditoId { get; set; }
        public Guid CiclistaId { get; set; }
        public Guid BicicletaId { get; set; }        
        public Guid TrancaId { get; set; }   
        
        public Guid? DevolucaoId { get; set; }
        
        public virtual CartaoDeCredito CartaoDeCredito { get; set; }
        public virtual Ciclista Ciclista { get; set; }        
        public virtual Bicicleta Bicicleta { get; set; }                     
        public virtual Tranca Tranca { get; set; }          
        public virtual Devolucao? Devolucao { get; set; }
    }
}
