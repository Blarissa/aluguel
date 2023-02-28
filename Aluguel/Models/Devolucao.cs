using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aluguel.Models
{
    public class Devolucao
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public float Valor { get; set; }

        [Required]
        public DateTime DataHoraPagamento { get; set; }

        //[Required]
        //[ForeignKey()]
        //public int EmprestimoId { get; set; }

        //[Required]
        //[ForeignKey()]
        //public int TrancaId { get; set; }

        [Required]
        [ForeignKey("CartaoDeCredito")]
        public int CartaoCreditoId { get; set; }

    }
}
