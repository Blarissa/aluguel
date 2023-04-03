using Aluguel.Commands.Contracts;
using Aluguel.Commands.Funcionarios;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Handlers.Funcionarios
{
    public class DeletaFuncionarioHandler : IHandler<DeletaFuncionarioCommand>
    {
        private readonly IFuncionarioRepository _repository;

        public DeletaFuncionarioHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(DeletaFuncionarioCommand command)
        {
            throw new NotImplementedException();
        }        
    }
}
