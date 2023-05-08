using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Servicos;
using Aluguel.Validacao.Interfaces;
using Newtonsoft.Json;
using System.Net;

namespace Aluguel.Validacao
{
    public class ValidaRegraExterno : IValidaRegraExterno
    {
        IExternoService externoService;

        public ValidaRegraExterno(IExternoService externoService)
        {
            this.externoService = externoService;
        }

        public bool CobracaValida(HttpResponseMessage resposta)
        {                       
            return resposta.StatusCode.Equals(HttpStatusCode.OK);
        }
        
    }
}
