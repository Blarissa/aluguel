using Aluguel.Commands;
using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Handlers.Ciclistas;

public class VerificarSeEmailExisteHandler : IHandler<VerificarSeEmailExisteCommand>
{
    private readonly ICiclistaRepository _repository;

    public VerificarSeEmailExisteHandler(ICiclistaRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(VerificarSeEmailExisteCommand command)
    {
        if (!command.Validar())
            return new GenericCommandResult(command.Erros.ToArray());

        var emailExiste = _repository.EmailExiste(command.Email);

        return new GenericCommandResult(emailExiste);
    }
}