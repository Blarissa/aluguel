using Aluguel.Models;
using Aluguel.Models.Entidades;

namespace Aluguel.Repositorios.Contracts;

public interface ICiclistaRepository
{
    void AdicionarCiclistaComCartao(Ciclista ciclista, CartaoDeCredito cartaoDeCredito);
    
    void AtualizarCiclista(Ciclista ciclista);

    void DeletaCiclista(Ciclista ciclista);
    
    IList<Emprestimo> RetornaEmprestimosPorCiclista(Guid idCiclista);

    Emprestimo? RetornaEmprestimoAtivo(Guid idCiclista);

    Ciclista? BuscarPorId(Guid id);
    
    Ciclista UltimoCiclistaAdicionado();

    IList<Ciclista> BuscarTodos();

    bool PassaporteExiste(string numero);
    
    bool EmailExiste(string email);
            
    EStatusCiclista RetornaStatusCiclista(Guid idCiclista);
    
    CartaoDeCredito? UltimoCartaoAdicionado(Guid idCiclista);
}