using Aluguel.Data;
using Aluguel.Models.Entidades;
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

        public bool PaisExiste(string codigo)
        {
            return contexto.Paises
                .Any(p => p.Codigo.Equals(codigo.ToLower()));
        }

        public Pais? RecuperarPorCodigo(string codigo)
        {
            return contexto.Paises
                .FirstOrDefault(
                    p => p.Codigo.ToLower() == codigo);
        }

        public IList<Pais> RecuperarTodos()
        {
            return contexto.Paises.ToList();
        }

        public Pais? RecuperarPorId(Guid id)
        {
            return contexto.Paises.FirstOrDefault(p => p.Id == id);
        }
    }
}
