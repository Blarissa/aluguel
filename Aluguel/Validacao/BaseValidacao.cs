using Aluguel.Models;

namespace Aluguel.Validacao;

public abstract class BaseValidacao
{
    protected BaseValidacao() => Erros = new List<Erro>();

    public bool Valida => Erros.Any() == false;
    public List<Erro> Erros { get; private set; }

    public void AdicionarErro(Erro erro)
    {
        Erros.Add(erro);
    }
}