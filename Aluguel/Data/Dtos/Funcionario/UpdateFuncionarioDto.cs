namespace Aluguel.Data.Dtos;

public class UpdateFuncionarioDto
{
    public string Nome { get; set; }
    public string Senha { get; set; }
    public int Idade { get; set; }
    public int Funcao { get; set; }
}