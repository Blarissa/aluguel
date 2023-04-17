namespace Aluguel.Data.Dtos.Servicos.Externo
{
    public class CreateEnviarEmailDto
    {

        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        
        public CreateEnviarEmailDto(string email, string assunto, string mensagem)
        {
            Email = email;
            Assunto = assunto;
            Mensagem = mensagem;
        }
    }
}
