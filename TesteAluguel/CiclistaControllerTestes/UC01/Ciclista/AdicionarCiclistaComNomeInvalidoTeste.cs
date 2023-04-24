using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaComNomeInvalidoTeste : AdicionarCiclistaTesteBase
{
    public AdicionarCiclistaComNomeInvalidoTeste(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void VerificaSeAdicionarCiclistaBrasileiroComNomeInvalidoRetornaStatusPretendido()
    {
        var ciclista = CiclistaBrasileiro();
        var cartao = Cartao();

        var resposta = RespostaEsperada(ciclista, cartao).Result;

        Assert.Equal(HttpStatusCode.UnprocessableEntity, resposta.StatusCode);
    }

    //criando cartao
    private static CreateMeioDePagamentoDto Cartao()
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = "Bárbara Brenda Araújo",
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
            Nome = "ba",
            DataNascimento = DateTime.Parse("10/03/1987"),
            Cpf = "10262643596",
            Passaporte = null,
            Nacionalidade = "BRASILEIRO",
            Email = "barbarabrendaaraujo@publiconsult.com.br",
            UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
            Senha = "hqQ6RlkuOJ",
            ConfirmaSenha = "hqQ6RlkuOJ"
        };
    }
}
