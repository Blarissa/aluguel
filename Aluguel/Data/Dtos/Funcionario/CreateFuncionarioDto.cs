using Aluguel.Models;
using Aluguel.Validacao;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos;

public class CreateFuncionarioDto
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

    [Required]
    [ModelBinder(Name = Erros.IdadeCod)]
    [Range(18, 100, ErrorMessage = Erros.IdadeMsg)]
    public int Idade { get; set; }

    [Required]
    [ModelBinder(Name = Erros.FuncaoCod)]
    [EnumDataType(typeof(EFuncao), ErrorMessage = Erros.FuncaoMsg)]
    public string Funcao { get; set; }

    [Required]
    [ModelBinder(Name = Erros.CpfCod)]
    [Cpf(ErrorMessage = Erros.CpfMsg)]
    public string Cpf { get; set; }
}
