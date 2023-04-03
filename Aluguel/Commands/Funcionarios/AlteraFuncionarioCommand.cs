using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos;
using Aluguel.Validacao;

namespace Aluguel.Commands.Funcionarios
{
    public class AlteraFuncionarioCommand : BaseValidacao, ICommand
    {

        public int Matricula { get; set; }
        public UpdateFuncionarioDto FuncionarioDto { get; set;}
        
        public AlteraFuncionarioCommand(int matricula, UpdateFuncionarioDto funcionarioDto)
        {
            Matricula = matricula;
            FuncionarioDto = funcionarioDto;
        }
        

        public bool Validar()
        {
            //TODO: Vailidações
            return Valida; 
        }
    }
}
