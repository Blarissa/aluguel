using Aluguel.Data.Dtos.Servicos.Externo;

namespace Aluguel.Servicos
{
    public interface IEquipamentoService
    {
        public Task<HttpResponseMessage> BuscarBicicletaPorId(Guid idBicicleta);
        public Task<HttpResponseMessage> BuscarBicicletaPorTranca(Guid idTranca);
        public Task<HttpResponseMessage> BuscarTrancaPorId(Guid idTranca);
    }
}
