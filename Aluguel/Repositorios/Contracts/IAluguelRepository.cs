using Aluguel.Models.Entidades;

namespace Aluguel.Repositorios.Contracts; 

public interface IAluguelRepository 
{
    void RealizaAluguel(Emprestimo emprestimo);
}