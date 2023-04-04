using Aluguel.Models;

namespace Aluguel.Repositorios.Contracts
{
    public interface IPaisRepository
    {
        IList<Pais> RecuperarTodos();
    }
}
