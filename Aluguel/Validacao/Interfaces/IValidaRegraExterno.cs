using Aluguel.Data.Dtos.Servicos.Externo;

namespace Aluguel.Validacao.Interfaces
{
    public interface IValidaRegraExterno
    {
        bool CobracaValida(HttpResponseMessage cobranca);
    }
}