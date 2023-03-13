using Aluguel.Data.Dtos.Servicos.Externo;
using Newtonsoft.Json;
using System.Text;

namespace Aluguel.Servicos.Externo
{
    public class ExternoApi
    {
        private const string FilaCobrancaEndpoint = "/filaCobranca";
        private const string CobrancaEndpoint = "/Cobranca";


        private readonly HttpClient client;
        private readonly string baseUriServico;

        public ExternoApi(IHttpClientFactory apiClient)
        {
            client = apiClient.CreateClient();

            baseUriServico = Environment.GetEnvironmentVariable("BASE_URI_SERVICO") ?? "";
            if(baseUriServico == "") throw new Exception("Variavel de ambiente não encontrada");
        }

        public async Task<HttpResponseMessage> EnviarCobrancaParaFila(PostFilaCobrancaDto cobrancaDto)
        {
            var conteudoJson = JsonConvert.SerializeObject(cobrancaDto);
            var requestBody = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var resposta = await client.PostAsync(baseUriServico+FilaCobrancaEndpoint, requestBody);

            return resposta;
        }

        public async Task<HttpResponseMessage> EnviarCobranca(PostCobrancaDto cobrancaDto)
        {
            var conteudoJson = JsonConvert.SerializeObject(cobrancaDto);
            var requestBody = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var resposta = await client.PostAsync(baseUriServico+CobrancaEndpoint, requestBody);

            return resposta;
        }

        public async Task<HttpResponseMessage> BuscarCobranca(Guid idCobranca)
        {
            var resposta = await client.GetAsync(baseUriServico+CobrancaEndpoint+$"{idCobranca}");

            return resposta;
        }
    }
}
