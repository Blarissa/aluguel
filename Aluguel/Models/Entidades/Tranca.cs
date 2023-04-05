using Aluguel.Models.Entidades;

namespace Aluguel.Models.Entidades;

public class Tranca
{

    public Guid Id { get; set; }
    public virtual IList<Emprestimo> Emprestimos { get; set; }
    public virtual IList<Devolucao> Devolucoes { get; set; }

    public Tranca()
    {
        Emprestimos = new List<Emprestimo>();
        Devolucoes = new List<Devolucao>();
    }
}