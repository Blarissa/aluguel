namespace Aluguel.Models;

public class Passaporte
{
    public Guid Id { get; set; }
    public string Numero { get; set; }
    public DateTime DataValidade { get; set; }
    public Guid PaisId { get; set; }
    public Pais Pais { get; set; }
}
