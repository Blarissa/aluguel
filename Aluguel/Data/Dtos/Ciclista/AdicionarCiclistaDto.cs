using Aluguel.Data.Dtos.Cartao;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class AdicionarCiclistaDto
    {
        public CreateCiclistaDto Ciclista { get; set; }
        public CreateMeioDePagamentoDto MeioDePagamento { get; set; }
    }
}
