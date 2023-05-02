namespace Aluguel.Data.Dtos.Passaporte;

public class CreatePassaporteDto
{    
    public string Numero { get; set; }
    public DateTime DataValidade { get; set; }
    internal Guid PaisId { get; set; }
    public string Pais { get; set; }
}