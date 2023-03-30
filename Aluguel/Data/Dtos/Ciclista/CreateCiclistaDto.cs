using Aluguel.Models;
using Aluguel.Validacao;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class CreateCiclistaDto
    {
        [Required]
        [ModelBinder(Name = Erros.NomeCod)]
        [StringLength(60, ErrorMessage = Erros.NomeMsg, MinimumLength = 2)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string? Cpf { get; set; }

        public PassaporteDto? Passaporte { get; set; }

        [Required]
        public string Nacionalidade { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.ImageUrl)]
        public Uri UrlFotoDocumento { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "A senha é obrigatória", MinimumLength = 8)]
        public string Senha { get; set; }
    }
}
