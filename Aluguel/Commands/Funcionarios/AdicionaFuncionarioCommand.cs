using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models;

namespace Aluguel.Commands.Funcionarios
{
    public class AdicionaFuncionarioCommand : ICommand
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
