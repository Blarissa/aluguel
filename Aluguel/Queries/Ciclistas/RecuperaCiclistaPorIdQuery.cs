using Aluguel.Models.Entidades;
using Aluguel.Queries.Contracts;
using System.Linq.Expressions;

namespace Aluguel.Queries.Ciclistas;

public class RecuperaCiclistaPorIdQuery : IQuery
{
    public Expression<Func<Ciclista, bool>> BuscarPorId(Guid id)
    {
        return c => c.Id == id;
    }
}