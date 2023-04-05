using Aluguel.Commands;
using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Cartao;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;
using AutoMapper;

namespace Aluguel.Handlers.CartoesDeCredito;

public class BuscarCartaoDeCreditoHandler : IHandler<BuscarBicicletaAlugadaCommand>
{
    private readonly ICartaoDeCreditoRepository _repository;
    private readonly IMapper _mapper;

    public ICommandResult Handle(BuscarBicicletaAlugadaCommand command)
    {
        if (!command.Validar())
            return new GenericCommandResult(command.Validar());

        var cartaoDeCredito = _repository.BuscarPorIdCiclista(command.CiclistaId);

        var cartaoDto = _mapper.Map<ReadCartaoDto>(cartaoDeCredito);

        return new GenericCommandResult(cartaoDto);
    }
}