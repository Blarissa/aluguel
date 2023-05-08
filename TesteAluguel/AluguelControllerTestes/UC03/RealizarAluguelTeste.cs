using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TesteAluguel.AluguelControllerTestes.UC03
{
    internal class RealizarAluguelTeste : RealizarAluguelTesteBase
    {
        public RealizarAluguelTeste(ITestOutputHelper output) : base(output)
        {
        }

        [Fact(DisplayName = "CT01 - StatusCode")]
        public void VerificaSeRealizarAluguelCorretoRetornaStatusPretendido()
        {
            var ciclista = AdicionaCiclista();
            var tranca = AdicionaTranca();

            var emprestimoDto = new CreateEmprestimoDto() { 
                Ciclista = ciclista.Id, 
                TrancaInicio = tranca.Id
            };
        }

        private Tranca AdicionaTranca()
        {
            throw new NotImplementedException();
        }

        private Ciclista AdicionaCiclista()
        {
            var ciclista = new CreateCiclistaDto()
            {
                Nome = "Renato Lucca Noah Aparício",
                DataNascimento = DateTime.Parse("19/03/1953"),
                Cpf = "56230950898",
                Passaporte = null,
                Nacionalidade = ENacionalidade.BRASILEIRO,
                Email = "renato-aparicio70@mega.com.br",
                UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
                Senha = "Ft3cY5pEzK",
                ConfirmaSenha = "Ft3cY5pEzK"
            };

            var cartao = new CreateMeioDePagamentoDto()
            {
                Nome = "Renato Lucca Noah Aparício",
                Numero = "4929685404235515",
                MesValidade = 8,
                AnoValidade = 24,
                CodigoSeguranca = 643
            }; 

            return _ciclistaRepository
                .AdicionarCiclistaComCartao();
        }
    }
}
