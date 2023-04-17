using Aluguel.Commands.Alugueis;
using Aluguel.Data;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Handlers.Alugueis;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios;
using Aluguel.Repositorios.Contracts;
using Aluguel.Servicos.Bicicleta;
using Aluguel.Servicos.Externo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Aluguel.Controllers
{
    [Tags("Aluguel")]    
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class AluguelController : ControllerBase
    {        
        private EquipamentoApi equipamentoApi;
        private ExternoApi externoApi;
        private IAluguelRepository aluguel;
        private IMapper _mapper;

        public AluguelController(AluguelContexto contexto, IHttpClientFactory apiFactory, IMapper mapper)
        {
            aluguel = new AluguelRepository(contexto);
            _mapper = mapper;
            equipamentoApi = new(apiFactory);
            externoApi = new(apiFactory);

        }

        /// <summary>
        /// Realizar aluguel
        /// </summary>
        /// <remarks>
        /// Realiza uma cobrança de um valor fixo e em caso de aprovada a mesma libera a tranca com a 
        /// bicicleta escolhida pelo ciclista. A mesma também notifica o ciclista da retirada da bicicleta.
        /// </remarks>
        /// <response code="200">Aluguel realizado</response>
        /// <response code="422">Dados Inválidos</response>

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ReadEmprestimoDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public async Task<IActionResult> RealizaEmprestimo(
            [FromBody,Required] CreateEmprestimoDto emprestimoDto,
            [FromServices] RealizaAluguelHandler handler)
        {
            var comando = new RealizarAluguelCommand(emprestimoDto);
            var resultado = handler.Handle(comando).Result;

            switch (resultado.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(resultado.Data);

                case HttpStatusCode.UnprocessableEntity:
                    return UnprocessableEntity(resultado.Data);

                default: return Problem(statusCode:500);
            }
        }
    }
}
