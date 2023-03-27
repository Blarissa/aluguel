using System.ComponentModel.DataAnnotations;

namespace Aluguel.Models
{
    public class Erro
    {
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Mensagem { get; set; }         
        
        public Erro(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
    }    
}
