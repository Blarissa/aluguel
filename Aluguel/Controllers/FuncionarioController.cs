using Aluguel.Commands;
using Aluguel.Commands.Funcionarios;
using Aluguel.Data.Dtos;
using Aluguel.Handlers.Funcionarios;
using Aluguel.Models.Entidades;
using Aluguel.Queries.Funcionarios;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


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
        private AluguelContexto contexto;
        private IDaoComInt<Funcionario> funcionarioDao;
        private IMapper mapper;

        public FuncionarioController(AluguelContexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            funcionarioDao = new FuncionarioDao(contexto);
            this.mapper = mapper;            
        }

        /// <summary>
        /// Recupera funcionários cadastrados
        /// </summary>      
        /// <response code="200">200 OK</response>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ReadFuncionarioDto>))]        
        public IActionResult RecuperaFuncionarios()
        {
            return Ok(handler.Handle().Data);            
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
        public IActionResult RecuperaFuncionarioPorId(int idFuncionario)
        {
            var comando = new RecuperaFuncionarioPorMatriculaQuery(idFuncionario);

            var resultado = handler.Handle(comando);

            switch (resultado.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(resultado.Data);

                case HttpStatusCode.NotFound:
                    return NotFound(resultado.Data);

                case HttpStatusCode.UnprocessableEntity:
                    return UnprocessableEntity(resultado.Data);

                default: return Problem(statusCode: 500);
            }
        }


        /// <summary>
        /// Cadastrar funcionário
        /// </summary>
        /// <response code="200">Dados cadastrados</response>
        /// <response code="422">Dados Inválidos</response>

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ReadFuncionarioDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public IActionResult AdicionaFuncionario([FromBody, Required] CreateFuncionarioDto funcionarioDto)
        {
            var comando = new AdicionaFuncionarioCommand(funcionarioDto);

            var resultado = handler.Handle(comando);

            switch (resultado.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(resultado.Data);

                case HttpStatusCode.UnprocessableEntity:
                    return UnprocessableEntity(resultado.Data);

                default: return Problem(statusCode: 500);
            }
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
            var comando = new AlteraFuncionarioCommand(idFuncionario,funcionarioDto);

            var resultado = handler.Handle(comando);

            switch (resultado.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(resultado.Data);

                case HttpStatusCode.NotFound:
                    return NotFound(resultado.Data);

                case HttpStatusCode.UnprocessableEntity:
                    return UnprocessableEntity(resultado.Data);

                default: return Problem(statusCode: 500);
            }
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
        public IActionResult DeletaFuncionario(int idFuncionario)
        {
            var comando = new DeletaFuncionarioCommand(idFuncionario);
            var resultado = handler.Handle(comando);

            switch (resultado.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(resultado.Data);

                case HttpStatusCode.NotFound:
                    return NotFound(resultado.Data);

                case HttpStatusCode.UnprocessableEntity:
                    return UnprocessableEntity(resultado.Data);

                default: return Problem(statusCode: 500);
            }
        }
    }
}
