using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Models;

namespace Aluguel.Servicos
{
    public interface IEquipamentoService
    {
        public Task<HttpResponseMessage> BuscarBicicletaPorId(Guid idBicicleta);
        public Task<HttpResponseMessage> BuscarBicicletaPorTranca(Guid idTranca);
        public Task<HttpResponseMessage> BuscarTrancaPorId(Guid idTranca);
        public Task<HttpResponseMessage> AlterarStatusBicicleta(Guid idBicicleta, EStatusBicicleta acao);
        public Task<HttpResponseMessage> DestrancarTranca(Guid idTranca);
        public Task<HttpResponseMessage> BuscarTotens();
    }
}
