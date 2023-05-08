namespace Aluguel.Models.Entidades;

public class Devolucao
{
    public Guid Id { get; set; }
    public DateTime DataHora { get; set; }
    public float Valor { get; set; }
    public DateTime DataHoraPagamento { get; set; }

    public Guid EmprestimoId { get; set; }
    public Guid TrancaId { get; set; }
    public Guid CartaoDeCreditoId { get; set; }

    public virtual CartaoDeCredito CartaoDeCredito { get; set; }
    public virtual Tranca Tranca { get; set; }
    public virtual Emprestimo Emprestimo { get; set; }
}
