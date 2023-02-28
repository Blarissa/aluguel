namespace Aluguel.Models
{
    public class CartaoDeCredito
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public int MesValidade { get; set; }
        public int AnoValidade { get; set; }
        public int CodigoSeguranca { get; set; }
        public EStatusCartao Status { get; set; }
        public int IdCiclista { get; set; }
        //public IList<Emprestimo> Emprestimos { get; set; }
        public IList<Devolucao> Devolucoes { get; set; }
    }
}
