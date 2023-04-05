using Aluguel.Models.Entidades;

namespace Aluguel.Repositorios.Contracts; 

public interface ICartaoDeCreditoRepository 
{
    CartaoDeCredito? BuscarPorIdCiclista(Guid ciclistaId);

    void AlterarCartaoPorIdCiclista(Guid ciclistaId, CartaoDeCredito cartaoDeCredito);
}