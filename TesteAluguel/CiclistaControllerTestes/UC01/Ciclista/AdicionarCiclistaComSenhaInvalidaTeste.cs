using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaComSenhaInvalidaTeste : AdicionarCiclistaTesteBase
{
    public AdicionarCiclistaComSenhaInvalidaTeste(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void VerificaSeAdicionarCiclistaBrasileiroComSenhaInvalidaRetornaStatusPretendido()
    {
        var ciclista = CiclistaBrasileiro();
        var cartao = Cartao(ciclista.Nome);

        var resposta = RespostaEsperada(ciclista, cartao).Result;

        Assert.Equal(HttpStatusCode.UnprocessableEntity, resposta.StatusCode);
    }

    //criando cartao
    private static CreateMeioDePagamentoDto Cartao(string nome)
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = nome,
            Numero = "6011715265483138",
            MesValidade = 3,
            AnoValidade = 2024,
            CodigoSeguranca = 7493
        };
    }

    //criando ciclista
    private static CreateCiclistaDto CiclistaBrasileiro()
    {
        return new CreateCiclistaDto()
        {
            Nome = "Bárbara Brenda Araújo",
            DataNascimento = DateTime.Parse("10/03/1987"),
            Cpf = "10262643596",
            Passaporte = null,
            Nacionalidade = "BRASILEIRO",
            Email = "barbarabrendaaraujo@publiconsult.com.br",
            UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
            Senha = "hqQ6RlkuOJ",
            ConfirmaSenha = "hqQ6Rlk"
        };
    }
}
