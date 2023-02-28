namespace Aluguel.Models
{
    public class Ciclista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string UrlFotoDocumento { get; set; }
        public EStatusCiclista Status { get; set; }
        public ENacionalidade Nacionalidade { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraConfirmacao { get; set; }
        public IList<CartaoCredito> Cartoes { get; set; }
        public IList<Emprestimo> Emprestimos { get; set; }
    }
}
