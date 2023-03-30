using Aluguel.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class CreateMeioDePagamentoDto
    {
        [Required]
        [ModelBinder(Name = Erros.NomeCod)]
        [StringLength(60, ErrorMessage = Erros.NomeMsg, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required]
        [CreditCard]
        public string Numero { get; set; }

        [Required]
        [Range(01, 12)]
        public int MesValidade { get; set; }
        
        [Required]
        [Range(23, 99)]
        public int AnoValidade { get; set; }
        
        [Required]
        [Range(001, 999)]
        public int CodigoSeguranca { get; set; }
    }
}