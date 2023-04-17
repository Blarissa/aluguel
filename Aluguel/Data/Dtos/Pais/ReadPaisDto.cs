using Newtonsoft.Json;

namespace Aluguel.Data.Dtos.Pais
{
    public class ReadPaisDto
    {
        public string Codigo { get; set; }
        [JsonIgnore]
        public string Nome { get; set; }
    }
}
