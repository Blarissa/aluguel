namespace Aluguel.Validacao
{
    public interface IValidaRegraDoBancoCiclista
    {
        bool CPFCiclista(string cpf);
        bool EmailCiclista(string email);
        bool IdCiclista(Guid idCiclista);
        bool Passaporte(string codigo);
        bool Status(Guid idCiclista);
        bool PodeAlugar(Guid idCiclista);
    }
}