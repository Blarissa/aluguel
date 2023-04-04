using Aluguel.Data;
using Aluguel.Models;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Repositorios
{
    public class PaisRepository : IPaisRepository
    {
        private AluguelContexto contexto;

        public PaisRepository(AluguelContexto contexto)
        {
            this.contexto = contexto;
        }

        public IList<Pais> RecuperarTodos()
        {
            return contexto.Paises.ToList();
        }
    }
}
