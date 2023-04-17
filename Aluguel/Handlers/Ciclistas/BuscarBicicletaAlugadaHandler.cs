using Aluguel.Commands;
using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Results;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;
using AutoMapper;

namespace Aluguel.Handlers.Ciclistas;

public class BuscarBicicletaAlugadaHandler : IHandler<BuscarBicicletaAlugadaCommand>
{
    private readonly ICiclistaRepository _repository;
    private readonly IMapper _mapper;

    public BuscarBicicletaAlugadaHandler(ICiclistaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ICommandResult Handle(BuscarBicicletaAlugadaCommand command)
    {
        if (!command.Validar())
            return new UnprocessableEntityCommandResult(command.Erros.ToArray());

        var ciclista = _repository.BuscarPorId(command.CiclistaId);

        var bicletaId = ciclista.BuscarBicicletaDoEmprestimoAtivo();

        // Chamar api do equipamento

        return new OkCommandResult("Funcionou");
    }
}