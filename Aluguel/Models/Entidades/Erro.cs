namespace Aluguel.Models.Entidades;

public class Erro
{    
    public string Codigo { get; set; }    
    public string Mensagem { get; set; }
    private ListaDeErros Erros;

    public Erro(string codigo)
    {
        Erros = new ListaDeErros();
        
        Codigo = codigo;
        Mensagem = Erros.RetornaErro(codigo);
    }

    public override string ToString()
    {
        return $"Código: {Codigo}\n" +
               $"Mensagem: {Mensagem}\n";
    }
}