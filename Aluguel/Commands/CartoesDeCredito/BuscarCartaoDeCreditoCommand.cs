using Aluguel.Commands.Contracts;
using Aluguel.Validacao;

namespace Aluguel.Commands.CartoesDeCredito;

public class BuscarCartaoDeCreditoCommand : BaseValidacao, ICommand
{
    public BuscarCartaoDeCreditoCommand() { }

    public BuscarCartaoDeCreditoCommand(Guid ciclistaId)
    {
        CiclistaId = ciclistaId;
    }

    public Guid CiclistaId { get; set; }

    public bool Validar()
    {
        return Valida;
    }
}