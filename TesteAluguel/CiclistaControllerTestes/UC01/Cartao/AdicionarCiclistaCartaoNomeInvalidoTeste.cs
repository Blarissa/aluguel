﻿using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaCartaoNomeInvalidoTeste : AdicionarCiclistaTesteBase
{
    public AdicionarCiclistaCartaoNomeInvalidoTeste(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "CT09 - StatusCode")]
    public void VerificaSeAdicionarCiclistaBrasileiroComCartaoNomeInvalidoRetornaStatusPretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
                    CiclistaBrasileiro(),
                    Cartao());

        var atual = ResponseAtual(ciclistaDto).Status;
        var esperado = HttpStatusCode.UnprocessableEntity;

        Assert.Equal(esperado, atual);
    }

    [Fact(DisplayName = "CT09 - Response")]
    public void VerificaSeAdicionarCiclistaBrasileiroComCartaoNomeInvalidoRetornaResponsePretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
                    CiclistaBrasileiro(),
                    Cartao());

        var atual = ResponseAtual(ciclistaDto).Data;     

        var esperado = new List<Erro>();
        esperado.Add(new Erro("004a"));

        Assert.Equivalent(esperado, atual);
    }

    //criando cartao
    private static CreateMeioDePagamentoDto Cartao()
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = "Ba",
            Numero = "6011715265483138",
            MesValidade = 3,
            AnoValidade = 24,
            CodigoSeguranca = 0
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
            Nacionalidade = ENacionalidade.BRASILEIRO,
            Email = "barbarabrendaaraujo@publiconsult.com.br",
            UrlFotoDocumento = "https://www.SomeValidURI.co",
            Senha = "hqQ6RlkuOJ",
            ConfirmaSenha = "hqQ6RlkuOJ"
        };
    }
}
