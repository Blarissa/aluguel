using System.ComponentModel.DataAnnotations;

namespace Aluguel.Models
{
    public class Pais
    {        
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public Passaporte Passaporte { get; set; }
    }
}
