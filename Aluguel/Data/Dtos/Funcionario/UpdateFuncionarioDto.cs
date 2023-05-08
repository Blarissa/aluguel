using Aluguel.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos;

public class UpdateFuncionarioDto
{
    [Required]
    [ModelBinder(Name = Erros.SenhaCod)]
    [Compare("ConfirmaSenha", ErrorMessage = Erros.SenhaMsg)]
    public string Senha { get; set; }
    
    public string ConfirmaSenha { get; set; }

    [Required]
    [ModelBinder(Name = Erros.EmailCod)]
    [EmailAddress(ErrorMessage = Erros.EmailMsg)]
    public string Email { get; set; }

    [Required]
    [ModelBinder(Name = Erros.NomeCod)]
    [MinLength(5, ErrorMessage = Erros.NomeMsg)]
    public string Nome { get; set; }
    public string Idade { get; set; }
    public string Funcao { get; set; }
}