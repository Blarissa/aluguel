namespace Aluguel.Data.Dtos.Cartao
{
    public class ReadCartaoDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string MesValidade { get; set; }
        public string AnoValidade { get; set; }        
        public string CodigoSeguranca { get; set; }
    }
}
