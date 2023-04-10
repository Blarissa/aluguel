using Aluguel.Models;
using Aluguel.Models.Entidades;

namespace Aluguel.Repositorios.Contracts;

public interface ICiclistaRepository
{
    void AdicionarCiclistaComCartao(Ciclista ciclista, CartaoDeCredito cartaoDeCredito);
    
    void AtualizarCiclista(Ciclista ciclista);
    
    IList<Emprestimo> RetornaEmprestimosPorCiclista(Guid idCiclista);

    Emprestimo? RetornaEmprestimoAtivo(Guid idCiclista);

    Ciclista BuscarPorId(Guid id);
    
    IList<Ciclista> BuscarTodos();
    
    bool EmailExiste(string email);
            
    EStatusCiclista RetornaStatusCiclista(Guid idCiclista);
    
    CartaoDeCredito? UltimoCataoAdicionado(Guid idCiclista);
}