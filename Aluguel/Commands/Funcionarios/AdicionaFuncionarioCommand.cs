using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models;
using Aluguel.Validacao;

namespace Aluguel.Commands.Funcionarios
{
    public class AdicionaFuncionarioCommand : BaseValidacao, ICommand
    {
        CreateFuncionarioDto funcionarioDto { get; set; }

        public AdicionaFuncionarioCommand(CreateFuncionarioDto funcionarioDto)
        {
           this.funcionarioDto = funcionarioDto;
        }             

        public bool Validar()
        {
            return true;
        }
    }
}
