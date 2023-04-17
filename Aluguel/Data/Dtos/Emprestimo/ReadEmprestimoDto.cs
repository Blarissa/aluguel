namespace Aluguel.Data.Dtos.Emprestimo
{
    public class ReadEmprestimoDto
    {
        public Guid Bicicleta { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime? HoraFim { get; set; }
        public Guid TrancaInicio { get; set; }
        public Guid? TrancaFim { get; set; }
        public Guid Cobranca { get; set; }
        public Guid Ciclista { get; set; }

        public ReadEmprestimoDto(Guid bicicleta, DateTime horaInicio, 
            DateTime? horaFim, Guid trancaInicio, Guid trancaFim, 
            Guid cobranca, Guid ciclista)
        {
            Bicicleta = bicicleta;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            TrancaInicio = trancaInicio;
            TrancaFim = trancaFim;
            Cobranca = cobranca;
            Ciclista = ciclista;
        }

        public override string ToString()
        {
            return $"N° da tranca de início: {TrancaInicio}\n" +
                   $"N° da bicicleta: {Bicicleta}\n" +
                   $"N° da ciclista: {Ciclista}" +
                   $"Hora de início: {HoraInicio:t}\n" +
                   $"Hora de fim prevísta: {HoraFim:t}\n";
        }
    }
}
