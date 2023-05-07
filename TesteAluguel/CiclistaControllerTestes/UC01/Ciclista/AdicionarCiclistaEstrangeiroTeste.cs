using Aluguel.Data.Dtos.Ciclista;
using System.Net;
using Xunit.Abstractions;
using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Passaporte;
using Xunit;
using Aluguel.Models;
using Aluguel.Repositorios.Contracts;
using AutoMapper;
using Aluguel.Models.Entidades;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaEstrangeiroTeste : AdicionarCiclistaTesteBase
{
    public AdicionarCiclistaEstrangeiroTeste(ITestOutputHelper output)
        : base(output)
    {
    }

    [Fact(DisplayName = "CT02 - StatusCode")]
    public void VerificaSeAdicionarCiclistaEstrangeiroCorretoRetornaStatusPretendido()
    {
        _context.Paises.Add(
            new Pais() { 
            Id = new Guid(),
            Codigo = "ca", 
            Nome = "Canadá"});

        _context.SaveChanges();

        var ciclistaDto = new AdicionarCiclistaDto(
                   CiclistaEstrangeiroValido(),
                   CartaoValido());

        var atual = ResponseAtual(ciclistaDto).Status;
        var esperado = HttpStatusCode.Created;

        Assert.Equal(esperado, atual);
    }

    [Fact(DisplayName = "CT02 - Response")]
    public void VerificaSeAdicionarCiclistaEstrangeiroCorretoRetornaResponsePretendido()
    {
        _context.Paises.Add(
            new Pais()
            {
                Id = Guid.NewGuid(),
                Codigo = "ca",
                Nome = "Canadá"
            });

        _context.SaveChanges();

        var ciclistaDto = new AdicionarCiclistaDto(
                    CiclistaEstrangeiroValido(),
                    CartaoValido());

        var atual = ResponseAtual(ciclistaDto).Data;

        Assert.Equivalent(ciclistaDto, atual);
    }

    //criando cartão
    private CreateMeioDePagamentoDto CartaoValido()
    {
        return new CreateMeioDePagamentoDto()
        {
            Nome = "Marcos Vinicius Matheus Alves",
            Numero = "5538492207925875",
            MesValidade = 7,
            AnoValidade = 24,
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
            Pais = "CA"
        };

        return new CreateCiclistaDto()
        {
            Nome = "Marcos Vinicius Matheus Alves",
            DataNascimento = DateTime.Parse("27/02/1968"),
            Passaporte = passaporte,
            Nacionalidade = ENacionalidade.ESTRANGEIRO,
            Email = "marcos.vinicius.alves@whgames.com.br",
            UrlFotoDocumento = "https://www.SomeValidURI.co",
            Senha = "LRnyTwi2Kj",
            ConfirmaSenha = "LRnyTwi2Kj"
        };
    }

    //Retorna o ciclista e o cartão adicionados por último
    private static AdicionarCiclistaDto ResponseEsperado(ICiclistaRepository ciclista,
        IPaisRepository pais, IMapper mapper)
    {        
        var ultimoCiclista = ciclista.UltimoCiclistaAdicionado();
        var id = ultimoCiclista.Passaporte.PaisId;
       
        ultimoCiclista.Passaporte.Pais = pais.RecuperarPorId(id);

        var ultimoCartao = ciclista.UltimoCartaoAdicionado(ultimoCiclista.Id);

        return new AdicionarCiclistaDto(
            mapper.Map<CreateCiclistaDto>(ultimoCiclista),
            mapper.Map<CreateMeioDePagamentoDto>(ultimoCartao));

    }
}
