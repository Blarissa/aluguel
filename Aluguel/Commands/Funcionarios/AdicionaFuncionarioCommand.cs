using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos;
using Aluguel.Validacao;

namespace Aluguel.Commands.Funcionarios
{
    public class AdicionaFuncionarioCommand : BaseValidacao, ICommand
    {
        public CreateFuncionarioDto funcionarioDto { get; set; }

        public AdicionaFuncionarioCommand(CreateFuncionarioDto funcionarioDto)
        {
           this.funcionarioDto = funcionarioDto;
        }             

        public bool Validar()
        {
            //TODO: Vailidações
            return Valida;
        }
    }
}
