using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using Xunit.Abstractions;

namespace TesteAluguel
{
    public class AdicionarCiclistaTeste
    {
        private readonly WebApplicationFactory<Program> application;
        private readonly HttpClient client;

        private readonly ITestOutputHelper output;

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



