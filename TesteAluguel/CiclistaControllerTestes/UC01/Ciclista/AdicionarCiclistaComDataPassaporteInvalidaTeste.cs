using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Passaporte;
using Aluguel.Models;
using Aluguel.Models.Entidades;
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

    [Fact(DisplayName = "CT16 - StatusCode")]
    public void VerificaSeAdicionarCiclistaEstrangeiroComDataPassaporteInvalidoRetornaStatusPretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
            CiclistaEstrangeiro(),
            Cartao());

        var atual = ResponseAtual(ciclistaDto).Status;
        var esperado = HttpStatusCode.UnprocessableEntity;

        Assert.Equal(esperado, atual);
    }

    [Fact(DisplayName = "CT16 - Response")]
    public void VerificaSeAdicionarCiclistaEstrangeiroComDataPassaporteInvalidoRetornaResponsePretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
            CiclistaEstrangeiro(),
            Cartao());

        var atual = ResponseAtual(ciclistaDto).Data;

        var esperado = new List<Erro>();
        esperado.Add(new Erro("008a"));

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
            DataValidade = DateTime.Parse("01/04/2021")
        };

        return new CreateCiclistaDto()
        {
            Nome = "Sophia Elaine Pietra Silver",
            DataNascimento = DateTime.Parse("03/01/1965"),
            Cpf = null,
            Passaporte = passaporte,
            Nacionalidade = ENacionalidade.ESTRANGEIRO,
            Email = "sophiaelainepeixoto@yahoo.de",
            UrlFotoDocumento = "https://www.SomeValidURI.co",
            Senha = "1pdEIjynkU",
            ConfirmaSenha = "1pdEIjynkU"
        };
    }
}
