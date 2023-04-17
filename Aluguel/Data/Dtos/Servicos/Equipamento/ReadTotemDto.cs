namespace Aluguel.Data.Dtos.Servicos.Equipamento
{
    public class ReadTotemDto
    {
        public Guid Id { get; set; }
        public string Localizacao { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"Localização: {Localizacao}\n";
        }
    }
}
