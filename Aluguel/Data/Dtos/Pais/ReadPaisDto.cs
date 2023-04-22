using Newtonsoft.Json;

namespace Aluguel.Data.Dtos.Pais
{
    public class ReadPaisDto
    {
        public string Codigo { get; set; }
        public string Nome { get; }
        
        public ReadPaisDto(string codigo)
        {
            Codigo = codigo;
        }
    }
}
