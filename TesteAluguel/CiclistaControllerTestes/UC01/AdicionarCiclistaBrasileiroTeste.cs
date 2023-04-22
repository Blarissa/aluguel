using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using AutoMapper;
using System.Net.Http.Json;
using Xunit.Abstractions;
using System.Net;
using Aluguel.Repositorios.Contracts;
using Moq;

namespace TesteAluguel;

public class AdicionarCiclistaBrasileiroTeste : AdicionarCiclistaTesteBase
{
    public AdicionarCiclistaBrasileiroTeste(ITestOutputHelper output) 
        : base(output)
    {
    }

    [Fact]
    public async void VerificaSeAdicionarCiclistaBrasileiroCorretoRetornaStatusCreated()
    {
        string resquestUri = BaseUri + "/ciclista";

        var ciclista = CiclistaBrasileiroValido();
        var cartao = CartaoValido(ciclista.Nome);

        var ciclistaDto = new AdicionarCiclistaDto()
        {
            Ciclista = ciclista,
            MeioDePagamento = cartao
        };

        var resposta = await client
            .PostAsJsonAsync(resquestUri, ciclistaDto);

        Assert.Equal(HttpStatusCode.Created, resposta.StatusCode);
    }
  
    //criando cartao
    private static CreateMeioDePagamentoDto CartaoValido(string nome)
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = nome,
            Numero = "4929685404235515",
            MesValidade = 8,
            AnoValidade = 2024,
            CodigoSeguranca = 643
        };
    }

    //criando ciclista
    private static CreateCiclistaDto CiclistaBrasileiroValido()
    {
        return new CreateCiclistaDto()
        {
            Nome = "Renato Lucca Noah Aparício",
            DataNascimento = DateTime.Parse("19/03/1953"),
            Cpf = "56230950898",
            Passaporte = null,
            Nacionalidade = "BRASILEIRO",
            Email = "renato-aparicio70@mega.com.br",
            UrlFotoDocumento = new Uri("https://www.SomeValidURI.co"),
            Senha = "Ft3cY5pEzK",
            ConfirmaSenha = "Ft3cY5pEzK"
        };
    }
    
}



