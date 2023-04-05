using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models.Entidades;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace TesteAluguel
{
    public class AdicionarCiclistaTeste
    {
        private readonly WebApplicationFactory<Program> application;
        private readonly HttpClient client;

        private readonly ITestOutputHelper output;
        private readonly string BaseUri = "https://residencia-nebula.ed.dev.br/aluguel-grupo2";


        public AdicionarCiclistaTeste(ITestOutputHelper output)
        {
            // Arrange
            application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // Configure test services
                });

            client = application.CreateClient();

            this.output = output;
        }

        [Fact]
        public async Task AdicionarCiclistaBrasileiroCorreto()
        {
            
        }
    }
}



