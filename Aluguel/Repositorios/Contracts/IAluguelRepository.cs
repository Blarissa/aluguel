using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Models.Entidades;

namespace Aluguel.Repositorios.Contracts; 

public interface IAluguelRepository 
{
    void RealizaAluguel(Emprestimo emprestimo);
    Emprestimo? RecuperaAluguelPorId(Guid id);    
    IList<Emprestimo?> RecuperaAlugueisAtivos();
    IList<Emprestimo?> RecuperaAlugueis();    
}