namespace Aluguel.Data.Dtos.Servicos.Externo
{
    public class CreateValidaCartaoDto
    {
        public string NomeTitular { get; set; }
        public string Numero { get; set; }
        public string Validade { get; set; }
        public int Cvv { get; set; }
    }
}
