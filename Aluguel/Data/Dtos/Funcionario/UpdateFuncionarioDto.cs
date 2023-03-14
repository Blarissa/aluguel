using Aluguel.Models;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Aluguel.Data.Dtos;

public class UpdateFuncionarioDto
{
    [Required]
    public string Nome { get; set; }        
    
    [Required]
    public string Senha { get; set; }
    
    [Required]
    public string ConfirmaSenha { get; set; }
    
    [Required]
    public int Idade { get; set; }
    
    [Required]    
    public string Funcao { get; set; }
}