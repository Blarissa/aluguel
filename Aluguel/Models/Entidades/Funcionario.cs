namespace Aluguel.Models.Entidades;

public class Funcionario
{
    public int Matricula { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
    public EFuncao Funcao { get; set; }    
}
