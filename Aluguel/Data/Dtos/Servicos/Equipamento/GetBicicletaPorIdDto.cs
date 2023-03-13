using Aluguel.Models;
using System.IO.Pipes;

namespace Aluguel.Data.Dtos.Servicos.Equipamento
{
    public class GetBicicletaPorIdDto
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public int Numero { get; set; }
        public EStatusBicicleta Status { get; set; }
    }
}
