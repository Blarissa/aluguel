using Aluguel.Commands.Devolucoes;
using Aluguel.Data;
using Aluguel.Data.Dao.Devolucao;
using Aluguel.Data.Dtos.Devolucao;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Handlers.Devolucoes;
using Aluguel.Models;
using Aluguel.Servicos;
using Aluguel.Models.Entidades;
using Aluguel.Servicos.Bicicleta;
using Aluguel.Servicos.Externo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Controllers
{
    [Tags("Aluguel")]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class DevolucaoController : ControllerBase
    {
        private readonly IDevolucaoRepository store;
        private readonly IEquipamentoService equipamentoApi;
        private readonly IExternoService externoApi;

        public DevolucaoController(IDevolucaoRepository repository, IExternoService externoApi, IEquipamentoService equipamentoApi)
        {
            store = repository;
            this.equipamentoApi = equipamentoApi;
            this.externoApi = externoApi;
        }

        /// <summary>
        /// Realizar devolução, sendo invocado de maneira automática pelo 
        /// hardware do totem ao encostar a bicicleta na tranca.
        /// </summary>  
        /// <remarks>
        /// Ao se devolver a bicicleta deve-se alterar o estado da tranca, 
        /// e calcular possíveis custos adicionais a ser pago pelo ciclista 
        /// e recorre a fila de cobrança para realiza-lo, notificando o 
        /// ciclista da devolução e da taxa extra paga.
        /// </remarks>      
        /// <response code="200">Devolução realizada</response>
        /// <response code="422">Dados inválidos</response>

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ResponsePostDevolucaoDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public async Task<IActionResult> PostDevolucao([FromBody, Required] PostDevolucaoDto dados, [FromServices] RealizaDevolucaoHandler handler)
        {
            var command = new RealizaDevolucaoCommand(dados);
            var retorno = await handler.RealizarDevolucaoAsync(command);

            switch(retorno.Status) {
                case System.Net.HttpStatusCode.OK: return Ok(retorno.Data);
                case System.Net.HttpStatusCode.NotFound: return NotFound(retorno.Data);
                case System.Net.HttpStatusCode.UnprocessableEntity: return UnprocessableEntity(retorno.Data);
                default: return StatusCode(500);
            }
        }
    }
}
