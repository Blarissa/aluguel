using Aluguel.Models;

namespace Aluguel.Data.Dtos.Servicos.Equipamento
{
    public class GetTrancaPorIdDto
    {
        public Guid Id { get; set; }
        public Guid Bicicleta { get; set; }
        public int Numero { get; set; }
        public string Localizacao { get; set; }
        public string AnoDeFabricacao { get; set; }
        public string Modelo { get; set; }
        public EStatusTranca Status { get; set; }
    }
}
