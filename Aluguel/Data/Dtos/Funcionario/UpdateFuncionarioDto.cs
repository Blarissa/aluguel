namespace Aluguel.Data.Dtos;

public class UpdateFuncionarioDto
{    
    public string Senha { get; set; }   
    public string ConfirmaSenha { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Idade { get; set; }
    public string Funcao { get; set; }
}