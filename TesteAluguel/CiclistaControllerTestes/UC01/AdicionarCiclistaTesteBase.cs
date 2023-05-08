using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Controllers;
using Aluguel.Data;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Handlers.Ciclistas;
using Aluguel.Profiles;
using Aluguel.Repositorios;
using Aluguel.Repositorios.Contracts;
using Aluguel.Servicos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace TesteAluguel.CiclistaControllerTestes;

public class AdicionarCiclistaTesteBase
{
    internal readonly WebApplicationFactory<Program> application;
    internal readonly HttpClient client;
    internal readonly IMapper _mapper;
    internal readonly ITestOutputHelper output;
    internal readonly string BaseUri = "https://localhost:7054";
    internal readonly DbContextOptions _options;
    internal readonly AluguelContexto _context;
    internal readonly ICiclistaRepository _ciclistaRepository;
    internal readonly IPaisRepository _paisRepository;
    internal readonly IExternoService _externo; 
    internal readonly CiclistaController _ciclistaController;

    public AdicionarCiclistaTesteBase(ITestOutputHelper output)
    {
        application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                // Configure test services
            });

        client = application.CreateClient();

        this.output = output;

       // configurando inMemoryDatabase
        _options = new DbContextOptionsBuilder<AluguelContexto>()
            .UseInMemoryDatabase("Aluguel")
            .Options;

        _context = new AluguelContexto(_options);
        _ciclistaRepository = new CiclistaRepository(_context);
        _paisRepository = new PaisRepository(_context);        

        //configurando IMapper
        if (_mapper == null)
        {
            var mappingConfig = new MapperConfiguration(mc =>
                mc.AddProfile(new CiclistaProfile()));

            _mapper = mappingConfig.CreateMapper();
        }
    }

    //retona resultado da adição do ciclista
    public ICommandResult ResponseAtual(AdicionarCiclistaDto ciclistaDto)
    {
        var handler = new AdicionarCiclistaHandler(
            _ciclistaRepository, _paisRepository, 
            _mapper, _externo);

        var command = new AdicionarCiclistaCommand(ciclistaDto);

        return handler.Handle(command);
    }
}
