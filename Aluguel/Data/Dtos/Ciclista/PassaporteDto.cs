using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class PassaporteDto
    {
        public string Numero { get; set; }        
        public string DataValidade { get; set; }
        public PaisDto Pais { get; set; }
    }
}
