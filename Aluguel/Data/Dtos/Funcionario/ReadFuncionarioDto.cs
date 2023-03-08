using Aluguel.Models;

namespace Aluguel.Data.Dtos;

public class ReadFuncionarioDto
{
    public int Matricula { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
    public int Funcao { get; set; }
}
