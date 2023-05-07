using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using System.Net;
using Xunit.Abstractions;
using Xunit;
using Aluguel.Models;
using Aluguel.Models.Entidades;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaComDataDeNascimentoInvalidaTeste : AdicionarCiclistaTesteBase
{
    public AdicionarCiclistaComDataDeNascimentoInvalidaTeste(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "CT04 - StatusCode")]
    public void VerificaSeAdicionarCiclistaBrasileiroComDataDeNascimentoInvalidaRetornaStatusPretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
            CiclistaBrasileiro(),
            Cartao());

        var atual = ResponseAtual(ciclistaDto).Status;
        var esperado = HttpStatusCode.UnprocessableEntity;

        Assert.Equal(esperado, atual);
    }

    [Fact(DisplayName = "CT04 - Response")]
    public void VerificaSeAdicionarCiclistaBrasileiroComDataDeNascimentoInvalidaRetornaResponsePretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
            CiclistaBrasileiro(),
            Cartao());

        var atual = ResponseAtual(ciclistaDto).Data;

        var esperado = new List<Erro>();
        esperado.Add(new Erro("005a"));

        Assert.Equivalent(esperado, atual);
    }

    //criando cartao
    private static CreateMeioDePagamentoDto Cartao()
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = "Sophia Elaine Pietra Silver",
            Numero = "6011715265483138",
            MesValidade = 3,
            AnoValidade = 24,
            CodigoSeguranca = 7493
        };
    }

    //criando ciclista
    private static CreateCiclistaDto CiclistaBrasileiro()
    {
        return new CreateCiclistaDto()
        {
            Nome = "Bárbara Brenda Araújo",
            DataNascimento = DateTime.Parse("10/12/2005"),
            Cpf = "10262643596",
            Passaporte = null,
            Nacionalidade = ENacionalidade.BRASILEIRO,
            Email = "barbarabrendaaraujo@publiconsult.com.br",
            UrlFotoDocumento = "https://www.SomeValidURI.co",
            Senha = "hqQ6RlkuOJ",
            ConfirmaSenha = "hqQ6RlkuOJ"
        };
    }
}
