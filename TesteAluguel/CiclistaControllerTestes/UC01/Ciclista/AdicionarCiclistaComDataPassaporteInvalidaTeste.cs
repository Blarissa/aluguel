using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Pais;
using Aluguel.Data.Dtos.Passaporte;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaComDataPassaporteInvalidaTeste : AdicionarCiclistaTesteBase
{
    public AdicionarCiclistaComDataPassaporteInvalidaTeste(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact]
    public void VerificaSeAdicionarCiclistaEstrangeiroComDataPassaporteInvalidoRetornaStatusPretendido()
    {
        var ciclista = CiclistaEstrangeiro();
        var cartao = Cartao(ciclista.Nome);

        var resposta = RespostaEsperada(ciclista, cartao).Result;

        Assert.Equal(HttpStatusCode.MethodNotAllowed, resposta.StatusCode);
    }

    //criando cartao
    private static CreateMeioDePagamentoDto Cartao(string nome)
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = nome,
            Numero = "379004508263881",
            MesValidade = 1,
            AnoValidade = 2025,
            CodigoSeguranca = 8589
        };
    }

    //criando ciclista
    private static CreateCiclistaDto CiclistaEstrangeiro()
    {
        var passaporte = new CreatePassaporteDto()
        {
            Numero = "II112243",
            Pais = new ReadPaisDto("DE"),
            DataValidade = DateTime.Parse("01/04/2021")
        };

        return new CreateCiclistaDto()
        {
            Nome = "Sophia Elaine Pietra Silver",
            DataNascimento = DateTime.Parse("03/01/1965"),
            Cpf = null,
            Passaporte = passaporte,
            Nacionalidade = "ESTRANGEIRO",
            Email = "sophiaelainepeixoto@yahoo.de",
            UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
            Senha = "1pdEIjynkU",
            ConfirmaSenha = "1pdEIjynkU"
        };
    }
}
