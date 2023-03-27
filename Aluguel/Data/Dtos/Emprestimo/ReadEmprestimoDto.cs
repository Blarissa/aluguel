using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos.Emprestimo
{
    public class ReadEmprestimoDto
    {
        public Guid Bicicleta { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public Guid TrancaInicio { get; set; }
        public Guid TrancaFim { get; set; }
        public Guid Cobranca { get; set; }
        public Guid Ciclista { get; set; }
    }
}
