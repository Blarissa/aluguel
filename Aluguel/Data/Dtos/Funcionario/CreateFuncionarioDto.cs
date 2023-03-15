using Aluguel.Models;
using Aluguel.Validacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Aluguel.Data.Dtos;

public class CreateFuncionarioDto
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
    public string ConfirmaSenha { get; set; }

    [Required]    
    public string Cpf { get; set; }

    [Required]
    public int Idade { get; set; }

    [Required]    
    public string Funcao { get; set; }
}
