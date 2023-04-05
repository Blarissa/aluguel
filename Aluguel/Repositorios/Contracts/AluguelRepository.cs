using Aluguel.Data;
using Aluguel.Models.Entidades;

namespace Aluguel.Repositorios.Contracts
{
    public class AluguelRepository : IAluguelRepository
    {
        private AluguelContexto contexto;

        public AluguelRepository(AluguelContexto contexto)
        {
            this.contexto = contexto;
        }

        public void RealizaAluguel(Emprestimo emprestimo)
        {
            contexto.Emprestimos.Add(emprestimo);
            contexto.SaveChanges();
        }
    }
}
