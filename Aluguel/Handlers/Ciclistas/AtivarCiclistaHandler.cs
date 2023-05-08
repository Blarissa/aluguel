using Aluguel.Commands;
using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Results;
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
            return new UnprocessableEntityCommandResult(command.Erros);

        var ciclista = _repository.BuscarPorId(command.CiclistaId);

        ciclista.Ativar();

        _repository.AtualizarCiclista(ciclista);

        return new OkCommandResult(command);
    }
}