using Aluguel.Models;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos;

public class ReadFuncionarioDto
{
    [Required]
    public int Matricula { get; set; }
    
    [Required]    
    public string Nome { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Senha { get; set; }
    
    [Required]
    public string Cpf { get; set; }
    
    [Required]    
    public int Idade { get; set; }

    [Required]    
    public string Funcao { get; set; }
}
