namespace Aluguel.Data.Dtos.Servicos.Externo
{
    public class ResponsePostEmailDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
    }
}
