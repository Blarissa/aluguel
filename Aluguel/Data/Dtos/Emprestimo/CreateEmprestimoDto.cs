namespace Aluguel.Data.Dtos;

public class CreateEmprestimoDto 
{
    public Guid BicicletaId { get; set; }    
    public Guid TrancaFimId { get; set; }
    public Guid CobrancaId { get; set; }       
    public DateTime DataHora { get; set; }
    public DateTime DataHoraPagamento { get; set; }
}