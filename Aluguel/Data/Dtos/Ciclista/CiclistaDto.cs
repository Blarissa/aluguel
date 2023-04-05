using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class CiclistaDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Nome { get; set; }       
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public PassaporteDto? Passaporte { get; set; }
        public string Nacionalidade { get; set; }
        public string Email { get; set; }
        public Uri UrlFotoDocumento { get; set; }
    }
}
