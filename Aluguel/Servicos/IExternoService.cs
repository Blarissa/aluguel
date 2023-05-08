using Aluguel.Data.Dtos.Servicos.Externo;

namespace Aluguel.Servicos
{
    public interface IExternoService
    {
        public Task<HttpResponseMessage> EnviarCobrancaParaFila(CreateFilaCobrancaDto cobrancaDto);
        public Task<HttpResponseMessage> EnviarCobranca(CreateCobrancaDto cobrancaDto);
        public Task<HttpResponseMessage> EnviarEmail(CreateEnviarEmailDto emailDto);
        public Task<HttpResponseMessage> BuscarCobranca(Guid idCobranca);
        public Task<HttpResponseMessage> ValidacaoCartao(CreateValidaCartaoDto validaCartaoDto);
    }
}
