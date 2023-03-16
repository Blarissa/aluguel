using Aluguel.Models;
using Aluguel.Validacao;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos;

public class CreateFuncionarioDto
{
    [Required]    
    public int Matricula { get; set; }

    [Required]
    [ModelBinder(Name = "001a")]
    [MinLength(5, ErrorMessage = "Nome deve ter pelo menos 5 caracteres!")]
    public string Nome { get; set; }

    [Required]
    [ModelBinder(Name = "006a")]
    [EmailAddress(ErrorMessage = "Email dever ser no padrão user@example.com!")]
    public string Email { get; set; }
    
    [Required]
    [ModelBinder(Name = "007a")]
    [Compare("ConfirmaSenha", ErrorMessage = "Senha de confirmação diferente!")]
    public string Senha { get; set; }

    [Required]
    public string ConfirmaSenha { get; set; }

    [Required]
    [ModelBinder(Name = "002a")]
    [Cpf(ErrorMessage = "CPF deve ter 11 dígitos!")]
    public string Cpf { get; set; }

    [Required]
    [ModelBinder(Name = "005a")]
    [Range(18, 200, ErrorMessage = "Idade deve ser pelo menos 18!")]
    public int Idade { get; set; }

    [Required]
    [ModelBinder(Name = "012a")]
    [EnumDataType(typeof(EFuncao), ErrorMessage = "Função dever ser REPARADOR ou ADMINISTRATIVO!")]
    public string Funcao { get; set; }
}
