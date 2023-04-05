using Aluguel.Commands.Contracts;
using Aluguel.Validacao;

namespace Aluguel.Commands.Ciclistas;

public class AtivarCiclistaCommand : BaseValidacao, ICommand
{
    public AtivarCiclistaCommand() { }

    public AtivarCiclistaCommand(Guid ciclistaId)
    {
        CiclistaId = ciclistaId;
    }

    public Guid CiclistaId { get; set; }

    public bool Validar()
    {
        return Valida;
    }
}