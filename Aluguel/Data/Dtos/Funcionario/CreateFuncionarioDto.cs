using Aluguel.Models;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos;

public class CreateFuncionarioDto
{
    [Required]
    public int Matricula { get; set; }
    
    [Required]
    public string Nome { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Senha { get; set; }
    
    [Required]
    public string ConfirmaSenha { get; set; }
    
    [Required]    
    public string Cpf { get; set; }
    
    [Required]
    public int Idade { get; set; }

    [Required]
    [EnumDataType(typeof(EFuncao))]
    public string Funcao { get; set; }
}
