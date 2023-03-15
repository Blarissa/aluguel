using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aluguel.Servicos.Bicicleta
{
    public class EquipamentoApi
    {
        private readonly HttpClient client;
        private readonly string baseUriServico;

        public EquipamentoApi(IHttpClientFactory apiClient)
        {
            client = apiClient.CreateClient();

            //baseUriServico = Environment.GetEnvironmentVariable("BASE_URI_SERVICO") ?? "";
            baseUriServico = "https://residencia-nebula.ed.dev.br/aluguel-grupo2";
            if(baseUriServico == "") throw new Exception("Variavel de ambiente não encontrada");
        }

        public async Task<HttpResponseMessage> BuscarBicicletaPorId(Guid idBicicleta)
        {
            var resposta = await client.GetAsync(baseUriServico+$"/bicicleta/{idBicicleta}");



            //GetBicicletaPorIdDto? valorTraduzido = JsonConvert.DeserializeObject<GetBicicletaPorIdDto>(await resposta.Content.ReadAsStringAsync());


            //if(valorTraduzido == null)
            //    return new GetBicicletaPorIdDto();

            return resposta;
        }

        public async Task<HttpResponseMessage> BuscarTrancaPorId(Guid idTranca)
        {
            var resposta = await client.GetAsync(baseUriServico+$"/tranca/{idTranca}");

            //GetTrancaPorIdDto? valorTraduzido = JsonConvert.DeserializeObject<GetTrancaPorIdDto>(await resposta.Content.ReadAsStringAsync());

            //if(valorTraduzido == null)
            //    return new GetTrancaPorIdDto();

            return resposta;
        }

    }
}
