using Aluguel.Models;

namespace Aluguel.Data.Dtos.Servicos.Externo
{
    public class CreateFilaCobrancaDto
    {

        public double Valor{ get; set; }
        public Guid Ciclista{ get; set; }
        
        public CreateFilaCobrancaDto(double valor, Guid ciclista)
        {
            Valor = valor;
            Ciclista = ciclista;
        }
    }
}
