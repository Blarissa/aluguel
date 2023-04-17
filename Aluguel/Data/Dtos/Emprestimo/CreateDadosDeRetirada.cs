namespace Aluguel.Data.Dtos.Emprestimo
{
    public class CreateDadosDeRetirada
    {
        public DateTime DataHoraRetirada { get; set; }
        public Guid IdTranca { get; set; }
        public Guid IdBicicleta { get; set; }
        public Guid IdCartao { get; set; }
        public Guid IdCiclista { get; set; }
        
        public CreateDadosDeRetirada(DateTime dataHoraRetirada, 
            Guid idTranca, Guid idBicicleta, Guid idCartao, 
            Guid idCiclista)
        {
            DataHoraRetirada = dataHoraRetirada;
            IdTranca = idTranca;
            IdBicicleta = idBicicleta;
            IdCartao = idCartao;
            IdCiclista = idCiclista;
        }

    }
}
