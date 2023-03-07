using Aluguel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AluguelConnection");

builder.Services.AddDbContext<AluguelContexto>(
    options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(a =>
{
    a.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Microsserviço Aluguel",
            Version = "v1"
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();