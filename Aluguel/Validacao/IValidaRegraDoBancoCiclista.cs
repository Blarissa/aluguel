namespace Aluguel.Validacao
{
    public interface IValidaRegraDoBancoCiclista
    {
        bool CPFCiclista(string cpf);        
        bool IdCiclista(Guid idCiclista);
        bool Passaporte(string codigo);
    }
}