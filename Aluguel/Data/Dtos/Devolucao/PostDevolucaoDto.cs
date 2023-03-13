using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos.Devolucao
{
    public class PostDevolucaoDto
    {

        [Required]
        public Guid IdTranca { get; set; }
        [Required(ErrorMessage = "Id da Bicicleta é obrigatório")]
        public Guid IdBicicleta { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (true) {
        //        yield return new ValidationResult("Id da tranca");
        //    }
        //}
    }
}
