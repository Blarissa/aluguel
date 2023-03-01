using Aluguel.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AluguelConnection");

builder.Services.AddDbContext<AluguelContexto>(
    options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();