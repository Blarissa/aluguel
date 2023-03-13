namespace Aluguel.Data.Dtos.Devolucao
{
    public class ResponsePostDevolucaoDto
    {
        public Guid Bicicleta { get; set; }
        public DateTime HoraInicio { get; set; }
        public Guid TrancaFim { get; set; }
        public DateTime HoraFim { get; set; }
        public Guid Cobranca { get; set; }
        public Guid Ciclista { get; set; }
    }
}
