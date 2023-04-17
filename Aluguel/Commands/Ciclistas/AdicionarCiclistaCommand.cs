using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Validacao;

namespace Aluguel.Commands.Ciclistas;

public class AdicionarCiclistaCommand : BaseValidacao, ICommand
{
    public AdicionarCiclistaCommand() { }

    public AdicionarCiclistaCommand(CreateCiclistaDto ciclista, CreateMeioDePagamentoDto meioDePagamento)
    {
        Ciclista = ciclista;
        MeioDePagamento = meioDePagamento;
    }

    public CreateCiclistaDto Ciclista { get; set; }
    public CreateMeioDePagamentoDto MeioDePagamento { get; set; }

    public bool Validar()
    {
        //Validações

        return Valida;
    }
}