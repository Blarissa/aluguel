using Aluguel.Data;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Repositorios;

public class CartaoDeCreditoRepository : ICartaoDeCreditoRepository
{
    private readonly AluguelContexto _contexto;

    public CartaoDeCreditoRepository(AluguelContexto contexto)
    {
        _contexto = contexto;
    }

    public CartaoDeCredito? BuscarPorIdCiclista(Guid ciclistaId)
    {
        var query = from cartao in _contexto.CartoesDeCredito
                    where cartao.CiclistaId == ciclistaId
                    select cartao;

        return query.FirstOrDefault();
    }

    public void AlterarCartaoPorIdCiclista(Guid ciclistaId, CartaoDeCredito cartaoDeCredito)
    {
        CartaoDeCredito cartaoParaAlterar = BuscarPorIdCiclista(ciclistaId);

        cartaoParaAlterar = cartaoDeCredito;

        _contexto.CartoesDeCredito.Update(cartaoParaAlterar);
        _contexto.SaveChanges();
    }
}