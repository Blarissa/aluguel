using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Xunit.Abstractions;
using System.Net;
using Xunit;
using Aluguel.Models;
using Aluguel.Repositorios.Contracts;
using AutoMapper;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaBrasileiroTeste : AdicionarCiclistaTesteBase
{   
    public AdicionarCiclistaBrasileiroTeste(ITestOutputHelper output) : base(output)
    {
    }

    [Fact(DisplayName = "CT01 - StatusCode")]
    public void VerificaSeAdicionarCiclistaBrasileiroCorretoRetornaStatusPretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
                    CiclistaBrasileiroValido(),
                    CartaoValido());

        var atual = ResponseAtual(ciclistaDto).Status;
        var esperado = HttpStatusCode.Created;
        
        Assert.Equal(esperado, atual);       
    }
    
    [Fact(DisplayName = "CT01 - Response")]
    public void VerificaSeAdicionarCiclistaBrasileiroCorretoRetornaResponsePretendido()
    {
        var ciclistaDto = new AdicionarCiclistaDto(
                    CiclistaBrasileiroValido(),
                    CartaoValido());

        var atual = ResponseAtual(ciclistaDto).Data;
        var esperado = ResponseEsperado(_ciclistaRepository, _mapper);
        
        Assert.Equivalent(esperado, atual);        
    }

    //criando cartao
    private static CreateMeioDePagamentoDto CartaoValido()
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = "Renato Lucca Noah Aparício",
            Numero = "4929685404235515",
            MesValidade = 8,
            AnoValidade = 24,
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
            Nacionalidade = ENacionalidade.BRASILEIRO,
            Email = "renato-aparicio70@mega.com.br",
            UrlFotoDocumento = "https://www.SomeValidURI.co",
            Senha = "Ft3cY5pEzK",
            ConfirmaSenha = "Ft3cY5pEzK"
        };
    }

    //Retorna o ciclista e o cartão adicionados por último
    private static AdicionarCiclistaDto ResponseEsperado(ICiclistaRepository ciclista, 
        IMapper mapper)
    {
        var ultimoCiclista = ciclista.UltimoCiclistaAdicionado();
        var ultimoCartao = ciclista.UltimoCartaoAdicionado(ultimoCiclista.Id);

        return new AdicionarCiclistaDto(
            mapper.Map<CreateCiclistaDto>(ultimoCiclista),
            mapper.Map<CreateMeioDePagamentoDto>(ultimoCartao));
        
    }
}



