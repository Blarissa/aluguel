using Aluguel.Queries.Contracts;
using Aluguel.Validacao;

namespace Aluguel.Queries.Funcionarios
{
    public class RecuperaFuncionarioPorMatriculaQuery : BaseValidacao, IQuery
    {
        public int Matricula { get; set; }        

        public RecuperaFuncionarioPorMatriculaQuery(int matricula)
        {
            Matricula = matricula;
        }
    }
}
