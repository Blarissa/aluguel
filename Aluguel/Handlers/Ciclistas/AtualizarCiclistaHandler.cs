using Aluguel.Commands;
using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Handlers.Contracts;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;
using AutoMapper;

namespace Aluguel.Handlers.Ciclistas;

public class AtualizarCiclistaHandler : IHandler<AtualizarCiclistaCommand>
{
    private readonly ICiclistaRepository _repository;
    private readonly IMapper _mapper;

    public AtualizarCiclistaHandler(ICiclistaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ICommandResult Handle(AtualizarCiclistaCommand command)
    {
        if (!command.Validar())
            return new GenericCommandResult(command.Erros.ToArray());

        var ciclista = _repository.BuscarPorId(command.Id);
        
        var ciclistaAtualizado = _mapper.Map<Ciclista>(command);

        ciclista.AtualizarDados(ciclistaAtualizado);

        _repository.AtualizarCiclista(ciclista);

        return new GenericCommandResult(command);
    }
}