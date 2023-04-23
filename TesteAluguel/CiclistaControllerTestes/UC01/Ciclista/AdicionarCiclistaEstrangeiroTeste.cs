using Aluguel.Data.Dtos.Ciclista;
using System.Net;
using Xunit.Abstractions;
using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Passaporte;
using Aluguel.Data.Dtos.Pais;
using Xunit;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaEstrangeiroTeste : AdicionarCiclistaTesteBase
{
    public AdicionarCiclistaEstrangeiroTeste(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void VerificaSeAdicionarCiclistaEstrangeiroCorretoRetornaStatusPretendido()
    {
        var ciclista = CiclistaEstrangeiroValido();
        var cartao = CartaoValido(ciclista.Nome);

        var resposta = RespostaEsperada(ciclista, cartao).Result;

        Assert.Equal(HttpStatusCode.Created, resposta.StatusCode);
    }

    //criando cartão
    private CreateMeioDePagamentoDto CartaoValido(string nome)
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = nome,
            Numero = "5538492207925875",
            MesValidade = 7,
            AnoValidade = 2024,
            CodigoSeguranca = 591
        };
    }

    //criando ciclista
    private CreateCiclistaDto CiclistaEstrangeiroValido()
    {
        var passaporte = new CreatePassaporteDto()
        {
            Numero = "CE002311",
            DataValidade = DateTime.Parse("25/06/2025"),
            Pais = new ReadPaisDto("CA")
        };

        return new CreateCiclistaDto()
        {
            Nome = "Marcos Vinicius Matheus Alves",
            DataNascimento = DateTime.Parse("27/02/1968"),
            Passaporte = passaporte,
            Nacionalidade = "ESTRANGEIRO",
            Cpf = null,
            Email = "marcos.vinicius.alves@whgames.com.br",
            UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
            Senha = "LRnyTwi2Kj",
            ConfirmaSenha = "LRnyTwi2Kj"
        };
    }
}
