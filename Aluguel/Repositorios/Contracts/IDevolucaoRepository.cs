using Aluguel.Models;
using Aluguel.Models.Entidades;

namespace Aluguel.Repositorios.Contracts; 

public interface IDevolucaoRepository 
{
    public Emprestimo? BuscarEmprestimoAberto(Guid idBicicleta, Guid idTranca);
}