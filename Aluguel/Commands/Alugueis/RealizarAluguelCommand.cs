using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Validacao;

namespace Aluguel.Commands.Alugueis
{
    public class RealizarAluguelCommand : BaseValidacao, ICommand
    {
        public CreateEmprestimoDto emprestimoDto;

        public RealizarAluguelCommand(CreateEmprestimoDto emprestimoDto)
        {
            this.emprestimoDto = emprestimoDto;
        }

        public bool Validar()
        {
            return Valida;
        }
    }
}
