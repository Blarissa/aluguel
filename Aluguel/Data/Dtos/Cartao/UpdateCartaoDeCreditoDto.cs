using Aluguel.Models;
using Aluguel.Validacao;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Aluguel.Data.Dtos.Cartao
{
    public class UpdateCartaoDeCreditoDto
    {
        [Required]
        [ModelBinder(Name = Erros.NomeCod)]
        [StringLength(60, ErrorMessage = Erros.NomeMsg, MinimumLength = 2)]
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
