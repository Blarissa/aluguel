using Aluguel.Commands.Contracts;
using Aluguel.Validacao;

namespace Aluguel.Commands.Ciclistas;

public class PodeFazerEmprestimoCommand : BaseValidacao, ICommand
{
    public PodeFazerEmprestimoCommand() { }

    public PodeFazerEmprestimoCommand(Guid ciclistaId)
    {
        CiclistaId = ciclistaId;
    }

    public Guid CiclistaId { get; set; }

    public bool Validar()
    {
        return Valida;
    }
}