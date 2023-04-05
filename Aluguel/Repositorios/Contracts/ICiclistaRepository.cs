using Aluguel.Models;

namespace Aluguel.Repositorios.Contracts;

public interface ICiclistaRepository
{
    void AdicionarCiclistaComCartao(Ciclista ciclista, CartaoDeCredito cartaoDeCredito);
    void AtualizarCiclista(Ciclista ciclista);
    Ciclista BuscarPorId(Guid id);
    bool EmailExiste(string email);
}