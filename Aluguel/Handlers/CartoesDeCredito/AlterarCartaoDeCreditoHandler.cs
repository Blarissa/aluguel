using Aluguel.Commands;
using Aluguel.Commands.CartoesDeCredito;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Results;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Handlers.Contracts;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;
using Aluguel.Servicos;
using AutoMapper;

namespace Aluguel.Handlers.CartoesDeCredito;

public class AlterarCartaoDeCreditoHandler : IHandler<AlterarCartaoDeCreditoCommand>
{
    private readonly ICartaoDeCreditoRepository _repository;
    private readonly IMapper _mapper;
    private readonly IExternoService _service;

    public AlterarCartaoDeCreditoHandler(
        ICartaoDeCreditoRepository repository, 
        IMapper mapper, 
        IExternoService service)
    {
        _repository = repository;
        _mapper = mapper;
        _service = service;
    }

    public ICommandResult Handle(AlterarCartaoDeCreditoCommand command)
    {
        if (!command.Validar())
            return new GenericCommandResult(command.Erros.ToArray());

        var request = _mapper.Map<PostValidaCartaoDto>(command);
        var retorno = _service.ValidacaoCartao(request);

        var cartaoAchado = _repository.BuscarPorIdCiclista(command.GetCiclistaId());

        if (cartaoAchado == null)
            return new NotFoundCommandResult(new Erro("422", "Solicitacao Invalida"));

        cartaoAchado.AtualizarDadosCartao(
            command.Nome, 
            command.Numero,
            int.Parse(command.Validade.Split("/")[0]),
            int.Parse(command.Validade.Split("/")[1]), 
            command.CodigoSeguranca);

        _repository.AlterarCartao(cartaoAchado);

        return new GenericCommandResult(cartaoAchado);
    }
}