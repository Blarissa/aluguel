using Aluguel.Commands.Contracts;
using Aluguel.Validacao;

namespace Aluguel.Commands.Ciclistas;

public class BuscarBicicletaAlugadaCommand : BaseValidacao, ICommand
{
    public BuscarBicicletaAlugadaCommand() { }

    public BuscarBicicletaAlugadaCommand(Guid ciclistaId)
    {
        CiclistaId = ciclistaId;
    }

    public Guid CiclistaId { get; set; }

    public bool Validar()
    {
        return Valida;
    }
}