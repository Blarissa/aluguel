namespace Aluguel.Validacao
{
    public interface IValidaRegraDoBancoCiclista
    {
        bool CPFCiclista(string cpf);        
        bool IdCiclista(Guid idCiclista);
        bool Passaporte(string codigo);
        bool Status(Guid idCiclista);
        bool PodeAlugar(Guid idCiclista);
    }
}