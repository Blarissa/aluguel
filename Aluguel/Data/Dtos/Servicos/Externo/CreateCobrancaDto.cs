namespace Aluguel.Data.Dtos.Servicos.Externo
{
    public class CreateCobrancaDto
    {
        public double Valor { get; set; }
        public Guid Ciclista { get; set; }              
        
        public CreateCobrancaDto(double valor, Guid ciclista)
        {
            Valor = valor;
            Ciclista = ciclista;
        }
    }
}
