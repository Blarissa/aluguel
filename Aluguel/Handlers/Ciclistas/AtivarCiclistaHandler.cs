using Aluguel.Commands;
using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Handlers.Ciclistas;

public class AtivarCiclistaHandler : IHandler<AtivarCiclistaCommand>
{
    private readonly ICiclistaRepository _repository;

    public AtivarCiclistaHandler(ICiclistaRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(AtivarCiclistaCommand command)
    {
        command.Validar();
        if (!command.Valida)
            return new GenericCommandResult(command.Erros.ToArray());

        var ciclista = _repository.BuscarPorId(command.CiclistaId);

        ciclista.Ativar();

        _repository.AtualizarCiclista(ciclista);

        return new GenericCommandResult(command);
    }
}