using Aluguel.Data.Dtos.Servicos.Externo;
using Newtonsoft.Json;
using System.Text;

namespace Aluguel.Servicos.Externo
{
    public class ExternoApi : IExternoService
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

            //baseUriServico = Environment.GetEnvironmentVariable("BASE_URI_SERVICO") ?? "";
            baseUriServico = "https://8ce1aa22-9fa7-4f00-9f8b-614adabcea21.mock.pstmn.io";
            if(baseUriServico == "") throw new Exception("Variavel de ambiente não encontrada");
        }

        public Task<HttpResponseMessage> EnviarCobrancaParaFila(CreateFilaCobrancaDto cobrancaDto)
        {
            var conteudoJson = JsonConvert.SerializeObject(cobrancaDto);
            var requestBody = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var resposta = client.PostAsync(baseUriServico+FilaCobrancaEndpoint, requestBody);

            return resposta;
        }

        public Task<HttpResponseMessage> EnviarCobranca(CreateCobrancaDto cobrancaDto)
        {
            var conteudoJson = JsonConvert.SerializeObject(cobrancaDto);
            var requestBody = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var resposta = client.PostAsync(baseUriServico+CobrancaEndpoint, requestBody);

            return resposta;
        }

        public Task<HttpResponseMessage> EnviarEmail(CreateEnviarEmailDto emailDto)
        {
            var conteudoJson = JsonConvert.SerializeObject(emailDto);
            var requestBody = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var resposta = client.PostAsync(baseUriServico+EnviarEmailEndpoint, requestBody);

            return resposta;
        }

        public Task<HttpResponseMessage> BuscarCobranca(Guid idCobranca)
        {
            var resposta = client.GetAsync(baseUriServico+CobrancaEndpoint+$"{idCobranca}");

            return resposta;
        }

        public Task<HttpResponseMessage> ValidacaoCartao(CreateValidaCartaoDto validaCartaoDto)
        {
            var conteudoJson = JsonConvert.SerializeObject(validaCartaoDto);
            var requestBody = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            var resposta = client.PostAsync(baseUriServico+ValidaCartaoEndpoint, requestBody);

            return resposta;
        }
    }
}
