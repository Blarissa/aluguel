using Aluguel.Models;

namespace Aluguel.Data.Dtos.Servicos.Equipamento
{
    public class GetTrancaPorIdDto
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public int Numero { get; set; }
        public EStatusTranca Status { get; set; }
    }
}
