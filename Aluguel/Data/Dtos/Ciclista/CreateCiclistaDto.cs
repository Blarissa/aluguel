using Aluguel.Data.Dtos.Passaporte;
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
        public string Nome { get; set; }        
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }        
        public string? Cpf { get; set; }
        public CreatePassaporteDto? Passaporte { get; set; }
        public string Email { get; set; }  
        public Uri UrlFotoDocumento { get; set; }          
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }       
    }
}
