namespace Aluguel.Models
{
    public class Bicicleta
    {
        public IList<Emprestimo> Emprestimos { get; set; }

        public Bicicleta()
        {
            Emprestimos = new List<Emprestimo>();   
        }
    }
}