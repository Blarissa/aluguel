namespace Aluguel.Data.Dtos.Cartao
{
    public class ReadCartaoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string MesValidade { get; set; }
        public string AnoValidade { get; set; }
        public int CodigoSeguranca { get; set; }

    }
}
