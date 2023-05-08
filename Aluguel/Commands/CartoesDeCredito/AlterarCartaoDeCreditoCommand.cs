using Aluguel.Commands.Contracts;
using Aluguel.Validacao;

namespace Aluguel.Commands.CartoesDeCredito;

public class AlterarCartaoDeCreditoCommand : BaseValidacao, ICommand
{
    public AlterarCartaoDeCreditoCommand() { }

    public AlterarCartaoDeCreditoCommand(string nome, string numero, string validade, int codigoSeguranca)
    {
        Nome = nome;
        Numero = numero;
        Validade = validade;
        CodigoSeguranca = codigoSeguranca;
    }

    private Guid CiclistaId { get; set; }
    public string Nome { get; set; }
    public string Numero { get; set; }
    public string Validade { get; set; }
    public int CodigoSeguranca { get; set; }

    public bool Validar()
    {
        return Valida;
    }

    public void InserirCiclistaId(Guid id)
    {
        CiclistaId = id;
    }

    public Guid GetCiclistaId()
    {
        return CiclistaId;
    }
}