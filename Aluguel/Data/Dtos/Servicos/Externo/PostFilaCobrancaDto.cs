using Aluguel.Models;

namespace Aluguel.Data.Dtos.Servicos.Externo
{
    public class PostFilaCobrancaDto
    {
        public double Valor{ get; set; }
        public Guid Ciclista{ get; set; }
    }
}
