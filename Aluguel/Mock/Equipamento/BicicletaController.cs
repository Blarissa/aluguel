using Aluguel.Data.Dtos.Servicos.Equipamento;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Mock.Equipamento
{
    [Route("mock/[controller]")]
    [ApiController]
    public class BicicletaController : ControllerBase
    {

        [HttpGet("{idBicicleta}")]
        public IActionResult MockBicicletaPorId(Guid idBicicleta)
        {
            var retorno = new ReadBicicletaDto() { 
                Id = Guid.NewGuid(),
                Ano = "2020",
                Marca = "CALOI", 
                Modelo = "BMX",
                Numero = 456,
                Status = Models.EStatusBicicleta.EM_USO 
            };

            return Ok(retorno);
        }
    }
}
