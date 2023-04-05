using Aluguel.Models.Entidades;

namespace Aluguel.Repositorios.Contracts
{
    public interface IPaisRepository
    {
        IList<Pais> RecuperarTodos();
    }
}
