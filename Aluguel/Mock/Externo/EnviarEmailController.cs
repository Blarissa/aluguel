using Aluguel.Data.Dtos.Servicos.Externo;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Mock.Externo
{
    [Route("mock/[controller]")]
    [ApiController]
    public class EnviarEmailController : ControllerBase
    {

        [HttpPost]
        public IActionResult MockPostEnviarEmail([FromBody] CreateEnviarEmailDto dados)
        {
            var retorno = new ResponsePostEmailDto() {
                Id = Guid.NewGuid(),
                Email = "email@mock.com",
                Mensagem = "Mensagem",
                Assunto = "Mail Subject"
            };

            return Ok(retorno);
        }
    }
}
