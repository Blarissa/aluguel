using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Devolucao;
using Aluguel.Validacao;

namespace Aluguel.Commands.Devolucoes
{
    public class RealizaDevolucaoCommand : BaseValidacao, ICommand
    {
        
        public PostDevolucaoDto Dados { get; set; }
        public IValida validacao;

        public RealizaDevolucaoCommand(PostDevolucaoDto postDevolucaoDto)
        {
            Dados = postDevolucaoDto;
            validacao = new Valida();
        }

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
