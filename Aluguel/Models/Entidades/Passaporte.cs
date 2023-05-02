namespace Aluguel.Models.Entidades;

public class Passaporte
{
    public Guid Id { get; set; }
    public string Numero { get; set; }
    public DateTime DataValidade { get; set; }
    public Guid PaisId { get; set; }
    public virtual Pais Pais { get; set; }

    public void AtualizarDados(Passaporte passaporte)
    {
        Numero = passaporte.Numero;
        DataValidade = passaporte.DataValidade;
        PaisId = passaporte.PaisId;
       // Pais.AtualizarDados(passaporte.Pais);
    }
}