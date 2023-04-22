using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Servicos;
using Aluguel.Servicos.Externo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAluguel.RepositoriosFakes
{
    internal class ExternoDouble : IExternoService
    {

        public ExternoDouble() 
        { 
        }

        public Task<HttpResponseMessage> BuscarCobranca(Guid idCobranca)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> EnviarCobranca(CreateCobrancaDto cobrancaDto)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> EnviarCobrancaParaFila(CreateFilaCobrancaDto cobrancaDto)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> EnviarEmail(CreateEnviarEmailDto emailDto)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ValidacaoCartao(CreateValidaCartaoDto validaCartaoDto)
        {
            throw new NotImplementedException();
        }
    }
}
