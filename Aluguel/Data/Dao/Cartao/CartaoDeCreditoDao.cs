using Aluguel.Data.Dtos.Cartao;
using Aluguel.Models;

namespace Aluguel.Data.Dao.Cartao
{
    public class CartaoDeCreditoDao
    {

        private AluguelContexto contexto;
        public CartaoDeCreditoDao(AluguelContexto ctxt)
        {
            this.contexto = ctxt;
        }

        public CartaoDeCredito? BuscarPorIdCiclista(Guid IdCiclista)
        {
            var query = from cartao in contexto.CartoesDeCredito
                                      where cartao.CiclistaId == IdCiclista && cartao.Status == (int) EStatusCartao.ATIVO
                                      select cartao;

            return query.FirstOrDefault();
        }

        public void AlterarCartaoPorIdCiclista(Guid IdCiclista, CartaoDeCredito dados)
        {
            CartaoDeCredito cartaoParaAlterar = BuscarPorIdCiclista(IdCiclista);

            cartaoParaAlterar = dados;

            contexto.CartoesDeCredito.Update(cartaoParaAlterar);
            contexto.SaveChanges();
        }
    }
}
