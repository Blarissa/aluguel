using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Validacao;

namespace Aluguel.Commands.Ciclistas;

public class AtualizarCiclistaCommand : BaseValidacao, ICommand
{
    public AtualizarCiclistaCommand() { }

    public AtualizarCiclistaCommand(Guid id, string status, string nome, DateTime dataNascimento, string? cpf, PassaporteDto? passaporte, string nacionalidade, string email, Uri urlFotoDocumento)
    {
        Id = id;
        Status = status;
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
        Passaporte = passaporte;
        Nacionalidade = nacionalidade;
        Email = email;
        UrlFotoDocumento = urlFotoDocumento;
    }

    public Guid Id { get; set; }
    public string Status { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? Cpf { get; set; }
    public PassaporteDto? Passaporte { get; set; }
    public string Nacionalidade { get; set; }
    public string Email { get; set; }
    public Uri UrlFotoDocumento { get; set; }

    public bool Validar()
    {
        return Valida;
    }
}