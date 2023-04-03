using Aluguel.Data.Dtos;
using Aluguel.Models;
using Aluguel.Queries.Contracts;
using System.Linq.Expressions;

namespace Aluguel.Queries.Funcionarios
{
    public class RecuperaFuncionarioPorMatriculaQuery : IQuery
    {
        public int Matricula { get; set; }        
        
        public RecuperaFuncionarioPorMatriculaQuery(int matricula)
        {
            Matricula = matricula;
        }
    }
}
