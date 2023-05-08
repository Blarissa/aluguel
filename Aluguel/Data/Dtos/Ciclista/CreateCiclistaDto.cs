using Aluguel.Data.Dtos.Passaporte;
using Aluguel.Models;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class CreateCiclistaDto
    {
        public string Nome { get; set; }        
        public DateTime DataNascimento { get; set; }
        public ENacionalidade Nacionalidade { get; set; }        
        public string? Cpf { get; set; }
        public CreatePassaporteDto? Passaporte { get; set; }
        public string Email { get; set; }  
        public string UrlFotoDocumento { get; set; }          
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
    }
}
