using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Commands;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;
using AutoMapper;
using Aluguel.Models;

namespace Aluguel.Handlers.Ciclistas;

public class AdicionarCiclistaHandler : IHandler<AdicionarCiclistaCommand>
{
    private readonly ICiclistaRepository _repository;
    private readonly IMapper _mapper;

    public AdicionarCiclistaHandler(ICiclistaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ICommandResult Handle(AdicionarCiclistaCommand command)
    {
        if (!command.Validar())
            return new GenericCommandResult(command.Erros.ToArray());

        var ciclista = _mapper.Map<Ciclista>(command.Ciclista);

        var cartaoDeCredito = _mapper.Map<CartaoDeCredito>(command.MeioDePagamento);

        cartaoDeCredito.Ciclista = ciclista;

        _repository.AdicionarCiclistaComCartao(ciclista, cartaoDeCredito);

        return new GenericCommandResult(command);
    }
}