using Aluguel.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aluguel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private AluguelContexto contexto;

        public FuncionarioController(AluguelContexto contexto)
        {
            this.contexto = contexto;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> RecuperaFuncionarios()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string RecuperaFuncionarioPorId(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void AdicionaFuncionario([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void AtualizaFuncionario(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void DeletaFuncionario(int id)
        {
        }
    }
}
