using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aluguel.Models
{
    public class CartaoDeCredito
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public int MesValidade { get; set; }

        [Required]
        public int AnoValidade { get; set; }

        [Required]
        public int CodigoSeguranca { get; set; }

        [Required]
        public EStatusCartao Status { get; set; }

        //[Required]
        //[ForeignKey()]
        //public int IdCiclista { get; set; }

        //[Required]
        //[ForeignKey]
        //public IList<Emprestimo> Emprestimos { get; set; }

        //[Required]
        //[ForeignKey]
        //public IList<Devolucao> Devolucoes { get; set; }
    }
}
