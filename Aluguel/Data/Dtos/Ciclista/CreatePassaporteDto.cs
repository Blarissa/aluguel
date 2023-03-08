namespace Aluguel.Data.Dtos.Ciclista
{
    public class CreatePassaporteDto
    {
        public string Numero { get; set; }
        public DateTime DataValidade { get; set; }
        public PaisDto Pais { get; set; }
    }
}
