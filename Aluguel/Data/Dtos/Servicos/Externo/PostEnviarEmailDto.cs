namespace Aluguel.Data.Dtos.Servicos.Externo
{
    public class PostEnviarEmailDto
    {
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
    }
}
