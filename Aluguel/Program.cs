using Aluguel.Data;
using Aluguel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("AluguelConnection");

        builder.Services.AddDbContext<AluguelContexto>(
            options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddHttpClient();

        builder.Services.AddControllers()
            .AddNewtonsoftJson()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var response = new
                    {
                        Erros = new List<Erro>()
                    };

                    foreach (var (key, value) in context.ModelState)
                        foreach (var item in value.Errors)
                            response.Erros.Add(new Erro(key, item.ErrorMessage));

                    return new UnprocessableEntityObjectResult(response);
                };
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
    }
}