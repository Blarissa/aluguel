using System.ComponentModel.DataAnnotations;

namespace Aluguel.Models
{
    public class Pais
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
