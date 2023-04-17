using Aluguel.Data.Dtos.Servicos.Externo;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Mock.Externo
{
    [Route("/mock/[controller]")]
    [ApiController]
    public class ValidaCartaoDeCreditoController : ControllerBase
    {
        [HttpPost]
        public IActionResult VerificarValidadaCartao(CreateValidaCartaoDto dados)
        {
            return Ok();
        }
    }
}
