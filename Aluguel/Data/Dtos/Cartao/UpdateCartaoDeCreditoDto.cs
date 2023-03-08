namespace Aluguel.Data.Dtos.Cartao
{
    public class UpdateCartaoDeCreditoDto
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Validade { get; set; }
        public int CodigoSeguranca { get; set; }
    }
}
