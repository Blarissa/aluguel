namespace Aluguel.Models
{
    public class Passaporte
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataValidade { get; set; }
        public int PaisId { get; set; }
    }
}
