namespace Aluguel.Models
{
    public class Tranca
    {

        public int Id { get; set; }
        public virtual IList<Emprestimo> Emprestimos { get; set; }

        public Tranca()
        {
            Emprestimos = new List<Emprestimo>();
        }
    }
}