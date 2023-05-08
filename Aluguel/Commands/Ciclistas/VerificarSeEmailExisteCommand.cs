using Aluguel.Commands.Contracts;
using Aluguel.Validacao;

namespace Aluguel.Commands.Ciclistas;

public class VerificarSeEmailExisteCommand : BaseValidacao, ICommand
{
    public VerificarSeEmailExisteCommand() { }

    public VerificarSeEmailExisteCommand(string email)
    {
        Email = email;
    }

    public string Email { get; set; }

    public bool Validar()
    {
        return Valida;
    }
}
