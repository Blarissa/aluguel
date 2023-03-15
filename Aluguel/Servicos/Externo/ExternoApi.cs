using Aluguel.Data.Dtos.Servicos.Externo;
using Newtonsoft.Json;
using System.Text;

namespace Aluguel.Servicos.Externo
{
    public class ExternoApi
    {
        private const string FilaCobrancaEndpoint = "/filaCobranca";
        private const string CobrancaEndpoint = "/Cobranca";
        private const string ValidaCartaoEndpoint = "/validaCartaoDeCredito";
        private const string EnviarEmailEndpoint = "/enviarEmail";


        private readonly HttpClient client;
        private readonly string baseUriServico;

        public ExternoApi(IHttpClientFactory apiClient)
        {
            client = apiClient.CreateClient();
            //client = apiClient;

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

        public async Task<HttpResponseMessage> EnviarEmail(PostEnviarEmailDto emailDto)
        {
            var conteudoJson = JsonConvert.SerializeObject(emailDto);
            var requestBody = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var resposta = await client.PostAsync(baseUriServico+EnviarEmailEndpoint, requestBody);

            return resposta;
        }

        public async Task<HttpResponseMessage> BuscarCobranca(Guid idCobranca)
        {
            var resposta = await client.GetAsync(baseUriServico+CobrancaEndpoint+$"{idCobranca}");

            return resposta;
        }

        public async Task<HttpResponseMessage> ValidacaoCartao(PostValidaCartaoDto validaCartaoDto)
        {
            var conteudoJson = JsonConvert.SerializeObject(validaCartaoDto);
            var requestBody = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var resposta = await client.PostAsync(baseUriServico+ValidaCartaoEndpoint, requestBody);

            return resposta;
        }
    }
}
