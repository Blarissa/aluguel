using Aluguel.Models.Entidades;

namespace Aluguel.Repositorios.Contracts
{
    public interface IPaisRepository
    {
        IList<Pais> RecuperarTodos();
        Pais? RecuperarPorCodigo(string codigo);
        bool PaisExiste(string codigo);
        Pais? RecuperarPorId(Guid id);
    }
}
