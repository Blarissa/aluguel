using Aluguel.Commands.Alugueis;
using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Devolucoes;
using Aluguel.Controllers;
using Aluguel.Data;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Handlers.Alugueis;
using Aluguel.Handlers.Ciclistas;
using Aluguel.Profiles;
using Aluguel.Repositorios;
using Aluguel.Repositorios.Contracts;
using Aluguel.Servicos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace TesteAluguel.AluguelControllerTestes;

public class RealizarAluguelTesteBase
{
    internal readonly WebApplicationFactory<Program> application;
    internal readonly HttpClient client;
    internal readonly IMapper _mapper;
    internal readonly ITestOutputHelper output;
    internal readonly string BaseUri = "https://localhost:7054";
    internal readonly DbContextOptions _options;
    internal readonly AluguelContexto _context;
    internal readonly IAluguelRepository _aluguelRepository;
    internal readonly ICiclistaRepository _ciclistaRepository;
    internal readonly IPaisRepository _paisRepository;

    internal readonly IEquipamentoService _equipamento;
    internal readonly IExternoService _externo; 

    public RealizarAluguelTesteBase(ITestOutputHelper output)
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

        _aluguelRepository = new AluguelRepository(_context);
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

    //retona resultado do aluguel
    public ICommandResult ResponseAtual(CreateEmprestimoDto emprestimoDto)
    {
        var handler = new RealizaAluguelHandler(_aluguelRepository, _mapper, 
            _equipamento, _externo, _ciclistaRepository, _paisRepository);

        var command = new RealizarAluguelCommand(emprestimoDto);

        return handler.Handle(command).Result;
    }
}
