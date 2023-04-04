using Aluguel.Data.Dtos;
using Aluguel.Queries.Contracts;

namespace Aluguel.Queries.Funcionarios
{
    public class RecuperaTodosFuncionariosQuery : IQuery
    {
        public List<ReadFuncionarioDto> Funcionarios { get; set; }
    }
}
