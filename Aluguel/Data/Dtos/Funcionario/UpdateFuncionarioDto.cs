﻿namespace Aluguel.Data.Dtos;

public class UpdateFuncionarioDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Funcao { get; set; }
}