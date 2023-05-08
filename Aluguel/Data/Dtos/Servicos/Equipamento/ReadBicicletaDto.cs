using Aluguel.Models;

namespace Aluguel.Data.Dtos.Servicos.Equipamento
{
    public class ReadBicicletaDto
    {
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public int Numero { get; set; }
        public EStatusBicicleta Status { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"Marca: {Marca}\n" +
                   $"Modelo: {Modelo} \n" +
                   $"Ano: {Ano}\n" +
                   $"Numero: {Numero}\n";
        }
    }
}
