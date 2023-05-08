using Aluguel.Commands;
using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Results;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Handlers.Ciclistas;

public class PodeFazerEmprestimoHandler : IHandler<PodeFazerEmprestimoCommand>
{
    private readonly ICiclistaRepository _repository;

    public PodeFazerEmprestimoHandler(ICiclistaRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(PodeFazerEmprestimoCommand command)
    {
        if (!command.Validar())
            return new UnprocessableEntityCommandResult(command.Erros.ToArray());

        var ciclista = _repository.BuscarPorId(command.CiclistaId);

        var podeAlugarBicicleta = ciclista.PodeFazerEmprestimo();

        return new OkCommandResult(podeAlugarBicicleta);
    }
}