using System.ComponentModel.DataAnnotations;

namespace Aluguel.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public string Matricula { get; set; }
        public string Nome {get; set; }
        public string Email { get; set; }      
        public string Senha { get; set; }       
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public EFuncao Funcao { get; set; }
    }
}
