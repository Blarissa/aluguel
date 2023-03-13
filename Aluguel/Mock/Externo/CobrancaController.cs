using Aluguel.Data.Dtos.Servicos.Externo;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Mock.Externo
{
    [Route("mock/[controller]")]
    [ApiController]
    public class CobrancaController : ControllerBase
    {

        [HttpPost]
        public IActionResult MockPostCobranca([FromBody] PostFilaCobrancaDto dados)
        {
            var retorno = new ResponsePostCobrancaDto() {
                Id = Guid.NewGuid(),
                Status = "Concluido",
                HoraSolicitacao = new DateTime(2023, 03, 12, 21, 00, 00),
                HoraFinalizacao = new DateTime(2023, 03, 12, 22, 00, 00),
                Valor = 100,
                Ciclista = Guid.Parse("123e4567-e89b-12d3-a456-426614174000"),
            };

            return Ok(retorno);
        }

        [HttpGet("{idCobranca}")]
        public IActionResult MockGetCobranca(Guid idCobranca)
        {
            var retorno = new ResponsePostCobrancaDto() {
                Id = Guid.NewGuid(),
                Status = "Concluido",
                HoraSolicitacao = new DateTime(2023, 03, 12, 21, 00, 00),
                HoraFinalizacao = new DateTime(2023, 03, 12, 22, 00, 00),
                Valor = 100,
                Ciclista = Guid.Parse("123e4567-e89b-12d3-a456-426614174000"),
            };

            return Ok(retorno);
        }
    }
}
