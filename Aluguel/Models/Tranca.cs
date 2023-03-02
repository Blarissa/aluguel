namespace Aluguel.Models
{
    public class Tranca
    {
        public IList<Emprestimo> Emprestimos { get; set; }

        public Tranca()
        {
            Emprestimos = new List<Emprestimo>();
        }
    }
}