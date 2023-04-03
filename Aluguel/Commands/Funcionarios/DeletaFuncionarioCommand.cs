using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos;

namespace Aluguel.Commands.Funcionarios
{
    public class DeletaFuncionarioCommand : ICommand
    {
        int Matricula { get; set; }

        public DeletaFuncionarioCommand(int Matricula)
        {
            this.Matricula = Matricula;
        }

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
