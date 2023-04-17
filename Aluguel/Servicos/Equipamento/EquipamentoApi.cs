using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aluguel.Servicos.Bicicleta
{
    public class EquipamentoApi : IEquipamentoService
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

            return resposta;
        }

        public async Task<HttpResponseMessage> BuscarBicicletaPorTranca(Guid idTranca)
        {
            return await client
                .GetAsync(baseUriServico + 
                $"/tranca/{idTranca}/bicicleta");
        }

        public async Task<HttpResponseMessage> BuscarTrancaPorId(Guid idTranca)
        {
            var resposta = await client.GetAsync(baseUriServico+$"/tranca/{idTranca}");

            return resposta;
        }

        public async Task<HttpResponseMessage> AlterarStatusBicicleta(Guid idBicicleta, EStatusBicicleta acao)
        {
            return await client
                .GetAsync(baseUriServico + 
                $"/bicicleta/{idBicicleta}/status/{acao}");         
        }

        public async Task<HttpResponseMessage> DestrancarTranca(Guid idTranca)
        {
            return await client
                .GetAsync(baseUriServico +
                $"/tranca/{idTranca}/destrancar");

        }

        public async Task<HttpResponseMessage> BuscarTotens()
        {
            return await client
                .GetAsync(baseUriServico + 
                $"/totem");
        }
    }
}
