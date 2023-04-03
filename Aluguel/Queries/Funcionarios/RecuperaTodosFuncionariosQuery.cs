using Aluguel.Data.Dtos;
using Aluguel.Models;
using Aluguel.Queries.Contracts;
using System.Linq.Expressions;

namespace Aluguel.Queries.Funcionarios
{
    public class RecuperaTodosFuncionariosQuery : IQuery
    {
        public IList<ReadFuncionarioDto> funcionarioDto { get; set; }
    }
}
