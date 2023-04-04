namespace Aluguel.Models;

public class Bicicleta
{
    public Guid Id { get; set; }
    public virtual IList<Emprestimo> Emprestimos { get; set; }

    public Bicicleta()
    {
        Emprestimos = new List<Emprestimo>();
    }
}