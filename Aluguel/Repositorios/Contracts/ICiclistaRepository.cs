using Aluguel.Models;

namespace Aluguel.Repositorios.Contracts;

public interface ICiclistaRepository
{
    void Create(Ciclista ciclista);
    void Update(Ciclista ciclista);
}