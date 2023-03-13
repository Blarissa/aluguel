using Aluguel.Data;
using Aluguel.Data.Dao.Devolucao;
using Aluguel.Data.Dtos.Devolucao;
using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Models;
using Aluguel.Servicos.Bicicleta;
using Aluguel.Servicos.Externo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;

namespace Aluguel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DevolucaoController : ControllerBase
    {
        private readonly HttpClient client;
        private readonly DevolucaoDao store;
        private readonly IMapper mapper;
        private readonly EquipamentoApi equipamentoApi;
        private readonly ExternoApi externoApi;


        public DevolucaoController(AluguelContexto ctxt, IHttpClientFactory apiClient, IMapper map)
        {
            client = apiClient.CreateClient();
            store = new DevolucaoDao(ctxt);
            equipamentoApi = new EquipamentoApi(apiClient);
            externoApi = new ExternoApi(apiClient);
            mapper = map;
        }

        [Route("Custom")]
        [HttpGet]
        public async Task<IActionResult> Testando(){
            Console.WriteLine("TO AQUI");
            HttpClient cliente = new HttpClient();

            var result = await cliente.GetAsync("https://api.exchangerate.host/convert?from=USD&to=EUR&amount=100");

            string responseBody = await result.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);

            return Ok(responseBody);
        }

        [HttpPost]
        public async Task<IActionResult> PostDevolucao([FromBody] PostDevolucaoDto dados)
        {

            /**
             * alterar o estado da tranca /tranca/{idTranca}/trancar -> idBicicleta no body ja faz o resto na bicicleta
             * calcular possíveis custos adicionais a ser pago pelo ciclista, recorre a fila de cobrança para realiza-lo, 
             * notificando o ciclista da devolução e da taxa extra paga. /enviarEmail
             */
            try {
                if(!ModelState.IsValid) {
                    return BadRequest(new Erro() { Codigo = 400, Mensagem = "Erro: Dados inválidos" });
                }

                //chamado da tranca
                var retornoBicicleta = await equipamentoApi.BuscarBicicletaPorId(dados.IdBicicleta);
                GetBicicletaPorIdDto bicicletaEmprestada = JsonConvert.DeserializeObject<GetBicicletaPorIdDto>(await retornoBicicleta.Content.ReadAsStringAsync()) ?? new GetBicicletaPorIdDto();

                //chamado da tranca
                var retornoTranca= await equipamentoApi.BuscarTrancaPorId(dados.IdTranca);
                GetTrancaPorIdDto trancaUsada = JsonConvert.DeserializeObject<GetTrancaPorIdDto>(await retornoTranca.Content.ReadAsStringAsync()) ?? new GetTrancaPorIdDto();

                //Verifica o status da bicicleta e tranca
                if(bicicletaEmprestada.Status != EStatusBicicleta.EM_USO || trancaUsada.Status != EStatusTranca.LIVRE) {
                    return UnprocessableEntity(new Erro() { Codigo = 422, Mensagem = "Erro: Dados conflituosos" });
                }


                Emprestimo emprestimoBicicleta = store.BuscarEmprestimoAberto(dados.IdBicicleta, dados.IdTranca);
                if(emprestimoBicicleta == null) {
                    return NotFound(new Erro() { Codigo = 404, Mensagem = "Erro: Sem emprestimo corrente" });
                }

                TimeSpan duracaoAlguel = DateTime.Now - emprestimoBicicleta.DataHora;

                double valorAdicional = 0;

                double ValorDevido = 0;

                if(duracaoAlguel.TotalHours > 2)
                    ValorDevido = Math.Ceiling((duracaoAlguel.TotalMinutes - 120) / 30) * valorAdicional;

                //montar pacote de retorno
                ResponsePostDevolucaoDto confirmacao = new() {
                    Bicicleta = dados.IdBicicleta,
                    Ciclista = emprestimoBicicleta.CiclistaId,
                    Cobranca = Guid.Empty,
                    TrancaFim = dados.IdTranca,
                    HoraInicio = emprestimoBicicleta.DataHora,
                    HoraFim = DateTime.Now,
                };

                if(ValorDevido <= 0)
                    return Ok(confirmacao);

                //faz cobranca do valor 
                var retCobranca = await externoApi.EnviarCobranca(new PostCobrancaDto(){
                    Valor = ValorDevido, 
                    Ciclista = emprestimoBicicleta.CiclistaId 
                });

                //Fluxo alternativo caso cobrança falhe
                if(retCobranca.StatusCode != System.Net.HttpStatusCode.OK) {
                    var retFilaCobranca = await externoApi.EnviarCobrancaParaFila(new PostFilaCobrancaDto(){
                        Valor = ValorDevido,
                        Ciclista = emprestimoBicicleta.CiclistaId
                    });

                    if(retFilaCobranca.StatusCode != System.Net.HttpStatusCode.OK)
                        return UnprocessableEntity(new Erro() { Codigo = 422, Mensagem = "Erro: Cobranca falhou em todas as tentativas" });

                    ResponsePostFilaCobrancaDto bodyRetFilaCobranca =  JsonConvert.DeserializeObject<ResponsePostFilaCobrancaDto>(await retCobranca.Content.ReadAsStringAsync());

                    confirmacao.Cobranca = bodyRetFilaCobranca.Id;
                    confirmacao.HoraFim = bodyRetFilaCobranca.HoraFinalizacao;
                    return Ok(confirmacao);
                }

                ResponsePostCobrancaDto bodyRetCobranca =  JsonConvert.DeserializeObject<ResponsePostCobrancaDto>(await retCobranca.Content.ReadAsStringAsync());
                confirmacao.Cobranca = bodyRetCobranca.Id;
                confirmacao.HoraFim = bodyRetCobranca.HoraFinalizacao;
                return Ok(confirmacao);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
