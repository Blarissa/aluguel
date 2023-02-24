using System.ComponentModel.DataAnnotations;

namespace Aluguel.Models
{
    public class Funcionario
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Matricula { get; set; }
        [Required]
        public string Nome {get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public EFuncao Funcao { get; set; }
    }
}
