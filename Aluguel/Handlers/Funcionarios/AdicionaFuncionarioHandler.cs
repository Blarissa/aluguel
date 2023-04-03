using Aluguel.Commands.Contracts;
using Aluguel.Commands.Funcionarios;
using Aluguel.Handlers.Contracts;
using Aluguel.Models;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Handlers.Funcionarios
{
    public class AdicionaFuncionarioHandler : IHandler<AdicionaFuncionarioCommand>
    {
        private readonly IFuncionarioRepository _repository;

        public AdicionaFuncionarioHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionaFuncionarioCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
