using Aluguel.Data.Dtos.Cartao;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class AdicionarCiclistaDto
    {
        public AdicionarCiclistaDto()
        {
        }

        public AdicionarCiclistaDto(CreateCiclistaDto ciclista, CreateMeioDePagamentoDto meioDePagamento)
        {
            Ciclista = ciclista;
            MeioDePagamento = meioDePagamento;
        }

        public CreateCiclistaDto Ciclista { get; set; }
        public CreateMeioDePagamentoDto MeioDePagamento { get; set; }


        
    }
}
