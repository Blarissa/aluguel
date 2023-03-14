using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class CreateCiclistaDto
    {
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string? Cpf { get; set; }
        public PassaporteDto? Passaporte { get; set; }
        public string Nacionalidade { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.ImageUrl)]
        public Uri UrlFotoDocumento { get; set; }
        public string Senha { get; set; }
    }
}
