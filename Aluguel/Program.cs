using Aluguel.Commands.Contracts;
using Aluguel.Commands.Funcionarios;
using Aluguel.Data;
using Aluguel.Data.Dao;
using Aluguel.Handlers.Contracts;
using Aluguel.Handlers.Funcionarios;
using Aluguel.Models;
using Aluguel.Repositorios.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
    
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AluguelConnection");

builder.Services.AddDbContext<AluguelContexto>(
    options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

builder.Services.AddTransient<IFuncionarioRepository,FuncionarioRepository>();
builder.Services.AddTransient<AdicionaFuncionarioHandler>();
builder.Services.AddTransient<AlteraFuncionarioHandler>();
builder.Services.AddTransient<DeletaFuncionarioHandler>();
builder.Services.AddTransient<RecuperaFuncionarioPorMatriculaHandler>();
builder.Services.AddTransient<RecuperaTodosFuncionariosHandler>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient();

builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
            new UnprocessableEntityObjectResult(context.ModelState);                        
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(a =>
{
    a.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "Aluguel",
            Description = "Microsserviço Aluguel",
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });            

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    a.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Aluguel V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();    

public partial class Program { }