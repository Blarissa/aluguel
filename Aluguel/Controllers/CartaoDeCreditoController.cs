using Aluguel.Commands.CartoesDeCredito;
using Aluguel.Data;
using Aluguel.Data.Dao.Cartao;
using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Models.Entidades;
using Aluguel.Servicos.Externo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Controller
{
    [Tags("Aluguel")]
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class CartaoDeCreditoController : ControllerBase
    {
        private readonly AluguelContexto contexto;
        private readonly CartaoDeCreditoDao store;
        private IMapper mapper;

        private readonly ExternoApi externoApi;
        public CartaoDeCreditoController(AluguelContexto ctxt, IMapper map, IHttpClientFactory apiFactory)
        {
            HttpClient client = new HttpClient();
            store = new CartaoDeCreditoDao(ctxt);
            mapper = map;

            externoApi = new ExternoApi(apiFactory);
        }

        /// <summary>
        /// Recupera dados de cartão de crédito de um ciclista.
        /// </summary>       
        /// <response code="200">Dados do cartão</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="422">Dados inválidos</response>

        [HttpGet("{idCiclista}")]
        [ProducesResponseType(200, Type = typeof(ReadCartaoDto))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult GetCartaoDeCredito([FromRoute] string idCiclista)
        {
            try {

                Guid idTransformado = Guid.Parse(idCiclista);

                var cartaoAchado = store.BuscarPorIdCiclista(idTransformado);
                if(cartaoAchado == null) {
                    return NotFound(new Erro("404", "Cartao nao encontrado"));
                }

                var cartaoDto = mapper.Map<ReadCartaoDto>(cartaoAchado);
            
                return Ok(cartaoDto);
            }
            catch(FormatException formEx) {
                return UnprocessableEntity(new Erro("422", "Solicitacao Invalida"));
            }
            catch(Exception e) {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        /// <summary>        
        /// Alterar dados de cartão de crédito de um ciclista
        /// </summary>       
        /// <response code="200">Dados do cartão</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="422">Dados inválidos</response>

        [HttpPut("{idCiclista}")]
        [ProducesResponseType(200, Type = typeof(UpdateCartaoDeCreditoDto))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public async Task<IActionResult> PutCartaoDeCredito([FromRoute]string idCiclista, [FromBody,Required]AlterarCartaoDeCreditoCommand command)
        //public async Task<IActionResult> PutCartaoDeCredito([FromRoute]string idCiclista, [FromBody,Required] UpdateCartaoDeCreditoDto novosDados)
        {
            command.InserirCiclistaId(Guid.Parse(idCiclista));

            //try {
            //    Guid idTransformado = Guid.Parse(idCiclista);

            //    PostValidaCartaoDto request = mapper.Map<PostValidaCartaoDto>(novosDados);
            //    var retorno = await externoApi.ValidacaoCartao(request);

            //    if(retorno.StatusCode != System.Net.HttpStatusCode.OK) {
            //        return UnprocessableEntity(new Erro("422", "Solicitacao invalida"));
            //    }

            //    CartaoDeCredito? cartaoAchado = store.BuscarPorIdCiclista(idTransformado);
            //    if(cartaoAchado == null) {
            //        return NotFound(new Erro("422", "Cartao nao encontrado"));
            //    }

            //    CartaoDeCredito novosDadosMapeados = mapper.Map<UpdateCartaoDeCreditoDto,CartaoDeCredito>(novosDados, cartaoAchado);

            //    store.AlterarCartaoPorIdCiclista(idTransformado, novosDadosMapeados);

            //    return CreatedAtAction(nameof(GetCartaoDeCredito), new { idCiclista = idCiclista }, novosDados);

            //}
            //catch(FormatException formEx) {
            //    return UnprocessableEntity(new Erro("422", "Solicitacao Invalida"));
            //}
            //catch (Exception e) {
            //    Console.WriteLine(e);
            //    return StatusCode(500);
            //}
        }
    }
}
