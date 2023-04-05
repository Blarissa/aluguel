using Aluguel.Data.Dtos.Servicos.Externo;

namespace Aluguel.Servicos
{
    public interface IExternoService
    {
        public Task<HttpResponseMessage> EnviarCobrancaParaFila(PostFilaCobrancaDto cobrancaDto);
        public Task<HttpResponseMessage> EnviarCobranca(PostCobrancaDto cobrancaDto);
        public Task<HttpResponseMessage> EnviarEmail(PostEnviarEmailDto emailDto);
        public Task<HttpResponseMessage> BuscarCobranca(Guid idCobranca);
        public Task<HttpResponseMessage> ValidacaoCartao(PostValidaCartaoDto validaCartaoDto);
    }
}
