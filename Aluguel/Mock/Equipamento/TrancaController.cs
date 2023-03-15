using Aluguel.Data.Dtos.Servicos.Equipamento;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Mock.Equipamento
{
    [Route("mock/[controller]")]
    [ApiController]
    public class TrancaController : ControllerBase
    {

        [HttpGet("{idTranca}")]
        public IActionResult MockTrancaPorId(Guid idTranca)
        {
            var retorno = new GetTrancaPorIdDto() {
                Id = Guid.NewGuid(),
                Bicicleta = Guid.NewGuid(),
                AnoDeFabricacao = "2020",
                Localizacao = "Rua Avenida Brasil 2 - A novela",
                Modelo = "BMX",
                Numero = 456,
                Status = Models.EStatusTranca.LIVRE
            };

            return Ok(retorno);
        }
    }
}
