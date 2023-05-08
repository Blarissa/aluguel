using Aluguel.Data.Dtos.Passaporte;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class UpdateCiclitasDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public CreatePassaporteDto? Passaporte { get; set; }
        public string Nacionalidade { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
    }
}
