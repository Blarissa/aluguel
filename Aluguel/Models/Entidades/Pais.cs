namespace Aluguel.Models.Entidades;

public class Pais
{
    public Guid Id { get; set; }
    public string Codigo { get; set; }
    public string Nome { get; set; }

    public void AtualizarDados(Pais pais)
    {
        Codigo = pais.Codigo;
        Nome = pais.Nome;
    }
}