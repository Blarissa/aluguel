using Aluguel.Commands.Contracts;
using Aluguel.Validacao;

namespace Aluguel.Commands.Funcionarios
{
    public class DeletaFuncionarioCommand : BaseValidacao, ICommand
    {
        public int Matricula { get; set; }

        public DeletaFuncionarioCommand(int Matricula)
        {
            this.Matricula = Matricula;
        }

        public bool Validar()
        {
            //TODO: Vailidações
            return Valida;
        }
    }
}
