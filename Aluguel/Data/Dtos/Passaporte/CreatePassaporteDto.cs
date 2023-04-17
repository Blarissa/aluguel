using Aluguel.Data.Dtos.Pais;

namespace Aluguel.Data.Dtos.Passaporte;

public class CreatePassaporteDto
{
    public string Numero { get; set; }
    public DateTime DataValidade { get; set; }
    public ReadPaisDto Pais { get; set; }
}