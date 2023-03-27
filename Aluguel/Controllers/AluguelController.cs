using Aluguel.Data;
using Aluguel.Data.Dao.Cartao;
using Aluguel.Data.Dtos;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Models;
using Aluguel.Servicos.Bicicleta;
using Aluguel.Servicos.Externo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Controllers
{
    [Tags("Aluguel")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    public class AluguelController : ControllerBase
    {
        private CartaoDeCreditoDao storeCartao;
        private EquipamentoApi equipamentoApi ;
        private ExternoApi externoApi;

        //Refatorar -> criar DAO
        AluguelContexto contexto;

        private IMapper mapper;

        public AluguelController(AluguelContexto contexto,IHttpClientFactory apiFactory, IMapper mapper)
        {
            this.storeCartao = new (contexto);

            //Remover apos refatorar
            this.contexto= contexto;

            this.equipamentoApi = new(apiFactory);
            this.externoApi = new(apiFactory);

            this.mapper = mapper;
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
        public async Task<IActionResult> RealizaEmprestimo([FromBody,Required] CreateEmprestimoDto emprestimoDto)
        {
            Guid ciclistaId = emprestimoDto.Ciclista;
            Guid trancaId = emprestimoDto.TrancaInicio;

            var cartaoDoCiclista = storeCartao.BuscarPorIdCiclista(ciclistaId);

            if(cartaoDoCiclista == null)
                return NotFound(new Erro("404", "Ciclista nao encontrado"));

            var retornoTranca = await equipamentoApi.BuscarTrancaPorId(trancaId);
            GetTrancaPorIdDto tranca = JsonConvert.DeserializeObject<GetTrancaPorIdDto>(await retornoTranca.Content.ReadAsStringAsync()) ?? new GetTrancaPorIdDto();

            if(retornoTranca.StatusCode != System.Net.HttpStatusCode.OK)
                return NotFound(new Erro("404", "Tranca nao encontrada"));
            else if(tranca.Bicicleta == Guid.Empty)
                return NotFound(new Erro("404", "Tranca vazia"));

            //Faz cobrança
            var retornoCobranca = await externoApi.EnviarCobranca(new PostCobrancaDto(){
                Valor = 30,
                Ciclista = ciclistaId,
            });
            ResponsePostCobrancaDto cobranca = JsonConvert.DeserializeObject<ResponsePostCobrancaDto>(await retornoCobranca.Content.ReadAsStringAsync()) ?? new ResponsePostCobrancaDto();

            if(retornoCobranca.StatusCode != System.Net.HttpStatusCode.OK && cobranca.Id != Guid.Empty) {
                await externoApi.EnviarEmail(new PostEnviarEmailDto() {
                    Email = "TestEmail@com.com",
                    Assunto = "Assunto",
                    Mensagem = "Mensagem: Ocorreu um problema ao realizar a cobrança - Aluguel barrado",
                });
                return UnprocessableEntity(new Erro("422", "Erro ao fazer cobranca"));
            }

            ResponseCreateEmprestimoDto retorno = new() {
                TrancaInicio = trancaId,
                Bicicleta= tranca.Bicicleta,
                DataHora = DateTime.Now,
                Cobranca = cobranca.Id,

                //Finalizacao do pagamento
                DataHoraPagamento= cobranca.HoraFinalizacao,
            };

            //var aluguel = mapper.Map<Emprestimo>(emprestimoDto);

            //Fazer um mapping automatico
            var aluguel = new Emprestimo(){
                CiclistaId = ciclistaId,
                CartaoDeCreditoId = cartaoDoCiclista.Id,
                Valor = 30,
                DataHora = retorno.DataHora,
                DataHoraPagamento = retorno.DataHoraPagamento,
                TrancaId = trancaId,
                BicicletaId = tranca.Bicicleta,
            };


            contexto.Emprestimos.Add(aluguel);
            contexto.SaveChanges();

            return Ok(retorno);
        }
    }
}
