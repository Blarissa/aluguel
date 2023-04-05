using Aluguel.Commands.Funcionarios;
using Aluguel.Data.Dtos;
using Aluguel.Handlers.Funcionarios;
using Aluguel.Models.Entidades;
using Aluguel.Queries.Funcionarios;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aluguel.Controllers
{   
    [Tags("Aluguel")]    
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        /// <summary>
        /// Recupera funcionários cadastrados
        /// </summary>      
        /// <response code="200">200 OK</response>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ReadFuncionarioDto>))]
        public IActionResult RecuperaFuncionarios([FromServices] RecuperaTodosFuncionariosHandler handler)
        {
            return Ok(handler.Handle());            
        }

        /// <summary>
        /// Recupera funcionário
        /// </summary>
        /// <response code="200">Dados recuperados</response>
        /// <response code="422">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>

        [HttpGet("{idFuncionario}")]
        [ProducesResponseType(200, Type = typeof(ReadFuncionarioDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult RecuperaFuncionarioPorId(int idFuncionario, 
            [FromServices] RecuperaFuncionarioPorMatriculaHandler handler)
        {
            return Ok(handler.Handle(new RecuperaFuncionarioPorMatriculaQuery(idFuncionario)));
        }

        /// <summary>
        /// Cadastrar funcionário
        /// </summary>
        /// <response code="200">Dados cadastrados</response>
        /// <response code="422">Dados Inválidos</response>

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ReadFuncionarioDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public IActionResult AdicionaFuncionario(
            [FromBody, Required] CreateFuncionarioDto funcionarioDto,
            [FromServices] AdicionaFuncionarioHandler handler)
        {
            return Ok(handler.Handle(new AdicionaFuncionarioCommand(funcionarioDto)));            
        }

        /// <summary>
        /// Editar funcionário
        /// </summary>
        /// <response code="200">Dados atualizados</response>
        /// <response code="422">Dados Inválidos</response>
        /// <response code="404">Não encontrado</response>

        [HttpPut("{idFuncionario}")]
        [ProducesResponseType(200, Type = typeof(ReadFuncionarioDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult AtualizaFuncionario(int idFuncionario,
            [FromBody, Required] UpdateFuncionarioDto funcionarioDto,
            [FromServices] AlteraFuncionarioHandler handler)
        {
            return Ok(handler.Handle(new AlteraFuncionarioCommand(idFuncionario,funcionarioDto)));
        }

        /// <summary>
        /// Remover funcionário
        /// </summary>
        /// <response code="200">Dados removidos</response>
        /// <response code="422">Dados Inválidos</response>
        /// <response code="404">Não encontrado</response>

        [HttpDelete("{idFuncionario}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult DeletaFuncionario(int idFuncionario,
            [FromServices] DeletaFuncionarioHandler handler)
        {
                return Ok(handler.Handle(new DeletaFuncionarioCommand(idFuncionario)));                        
        }
    }
}
