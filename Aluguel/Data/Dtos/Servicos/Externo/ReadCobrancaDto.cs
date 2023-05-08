using Aluguel.Models;

namespace Aluguel.Data.Dtos.Servicos.Externo
{
    public class ReadCobrancaDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime HoraSolicitacao { get; set; }
        public DateTime HoraFinalizacao { get; set; }
        public double Valor{ get; set; }
        public Guid Ciclista{ get; set; }

        public override string ToString()
        {
            return $"Valor : {Valor}\n" +
                   $"Horário de pagamento : {HoraFinalizacao: t}";
        }
    }
}
