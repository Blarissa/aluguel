using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Passaporte;
using Aluguel.Models.Entidades;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaComNacionalidadeInvalidaTeste : AdicionarCiclistaTesteBase
{
    public AdicionarCiclistaComNacionalidadeInvalidaTeste(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "CT13 - StatusCode")]
    public void VerificaSeAdicionarCiclistaEstrangeiroComNacionalidadeInvalidaRetornaStatusPretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
            CiclistaEstrangeiro(),
            Cartao());

        var atual = ResponseAtual(ciclistaDto).Status;
        var esperado = HttpStatusCode.UnprocessableEntity;

        Assert.Equal(esperado, atual);
    }

    [Fact(DisplayName = "CT13 - Response")]
    public void VerificaSeAdicionarCiclistaEstrangeiroComNacionalidadeInvalidaRetornaResponsePretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
            CiclistaEstrangeiro(),
            Cartao());

        var atual = ResponseAtual(ciclistaDto).Data;

        var esperado = new List<Erro>();
        esperado.Add(new Erro("021a"));

        Assert.Equivalent(esperado, atual);
    }

    //criando cartao
    private static CreateMeioDePagamentoDto Cartao()
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = "Sophia Elaine Pietra Silver",
            Numero = "379004508263881",
            MesValidade = 1,
            AnoValidade = 25,
            CodigoSeguranca = 8589
        };
    }

    //criando ciclista
    private static CreateCiclistaDto CiclistaEstrangeiro()
    {
        var passaporte = new CreatePassaporteDto()
        {
            Numero = "II112243",
            Pais = "de",
            DataValidade = DateTime.Parse("01/04/2025")
        };

        return new CreateCiclistaDto()
        {
            Nome = "Sophia Elaine Pietra Silver",
            DataNascimento = DateTime.Parse("03/01/1965"),
            Passaporte = passaporte,
            Nacionalidade = 0,
            Email = "sophiaelainepeixoto@yahoo.de",
            UrlFotoDocumento = "https://www.SomeValidURI.co/",
            Senha = "1pdEIjynkU",
            ConfirmaSenha = "1pdEIjynkU"
        };
    }
}
