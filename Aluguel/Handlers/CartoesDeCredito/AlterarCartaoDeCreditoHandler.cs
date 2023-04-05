using Aluguel.Commands;
using Aluguel.Commands.CartoesDeCredito;
using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;
using AutoMapper;

namespace Aluguel.Handlers.CartoesDeCredito;

public class AlterarCartaoDeCreditoHandler : IHandler<AlterarCartaoDeCreditoCommand>
{
    private readonly ICartaoDeCreditoRepository _repository;
    private readonly IMapper _mapper;

    public AlterarCartaoDeCreditoHandler(ICartaoDeCreditoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ICommandResult Handle(AlterarCartaoDeCreditoCommand command)
    {
        if (!command.Validar())
            return new GenericCommandResult(command.Erros.ToArray());

        var request = _mapper.Map<PostValidaCartaoDto>(command);

        return new GenericCommandResult(request);
    }
}