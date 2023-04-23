using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaTesteBase
{
    internal readonly WebApplicationFactory<Program> application;
    internal readonly HttpClient client;
    internal readonly IMapper _mapper;
    internal readonly ITestOutputHelper output;
    internal readonly string BaseUri = "https://localhost:7054";

    public AdicionarCiclistaTesteBase(ITestOutputHelper output)
    {
        application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // Configure test services
            });

        client = application.CreateClient();

        this.output = output;

        if (_mapper == null)
        {
            var mappingConfig = new MapperConfiguration(mc =>
                mc.AddProfile(new CiclistaProfile()));

            _mapper = mappingConfig.CreateMapper();
        }
    }

    public async Task<HttpResponseMessage> RespostaEsperada(CreateCiclistaDto ciclista, 
        CreateMeioDePagamentoDto cartao)
    {
        string resquestUri = BaseUri + "/ciclista";        

        var ciclistaDto = new AdicionarCiclistaDto()
        {
            Ciclista = ciclista,
            MeioDePagamento = cartao
        };

        return await client
            .PostAsJsonAsync(resquestUri, ciclistaDto);
    }
}
