using Aluguel.Commands;
using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Results;
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
            return new UnprocessableEntityCommandResult(command.Erros.ToArray());

        var emailExiste = _repository.EmailExiste(command.Email);

        return new OkCommandResult(emailExiste);
    }
}