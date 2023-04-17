using Aluguel.Models;

namespace Aluguel.Data.Dtos.Servicos.Equipamento
{
    public class ReadTrancaDto
    {
        public Guid Id { get; set; }
        public Guid Bicicleta { get; set; }
        public int Numero { get; set; }
        public string Localizacao { get; set; }
        public string AnoDeFabricacao { get; set; }
        public string Modelo { get; set; }
        public EStatusTranca Status { get; set; }

        public override string ToString()
        {
            return $"Número: {Numero}\n" +
                   $"Localização: {Localizacao} \n" +
                   $"Ano de fabricação: {AnoDeFabricacao}\n" +
                   $"Modelo: {Modelo}\n";
        }
    }
}
