namespace Aluguel.Models.Entidades;

public class CartaoDeCredito
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Numero { get; set; }
    public int MesValidade { get; set; }
    public int AnoValidade { get; set; }
    public int CodigoSeguranca { get; set; }

    public Guid CiclistaId { get; set; }
     
    public virtual Ciclista Ciclista { get; set; }
    public virtual IList<Emprestimo> Emprestimos { get; set; }
    public virtual IList<Devolucao> Devolucoes { get; set; }

    public CartaoDeCredito()
    {
        Emprestimos = new List<Emprestimo>();
        Devolucoes = new List<Devolucao>();
    }

    public void AtualizarDadosCartao(string nome, string numero, int mesValidade, int anoValidade, int codigoSeguranca)
    {
        Nome = nome;
        Numero = numero;
        MesValidade = mesValidade;
        AnoValidade = anoValidade;
        CodigoSeguranca = codigoSeguranca;
    }
}
