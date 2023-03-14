using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class CreatePassaporteDto
    {
        public string Numero { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }
        public PaisDto Pais { get; set; }
    }
}
