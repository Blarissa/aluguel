using Aluguel.Validacao;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos.Cartao
{
    public class UpdateCartaoDeCreditoDto
    {
        [Required]
        [StringLength(60, ErrorMessage = "Nome é obrigatório", MinimumLength = 5)]
        public string Nome { get; set; }

        [Required]
        [CreditCard]
        public string Numero { get; set; }

        [Required]
        [DataFutura]
        public string Validade { get; set; }
        [Required]
        [Range(001, 999)]
        public int CodigoSeguranca { get; set; }
    }
}
