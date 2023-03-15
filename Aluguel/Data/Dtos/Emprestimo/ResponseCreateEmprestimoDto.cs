namespace Aluguel.Data.Dtos;

public class ResponseCreateEmprestimoDto 
{
    public Guid Bicicleta { get; set; }    
    public Guid TrancaInicio { get; set; }
    public Guid Cobranca { get; set; }       
    public DateTime DataHora { get; set; }
    public DateTime DataHoraPagamento { get; set; }
}