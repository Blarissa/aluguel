using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Models.Entidades;

namespace Aluguel.Data.Dtos.Emprestimo
{
    public class ReadDadosRetiradaDto
    {
        public ReadBicicletaDto Bicicleta { get; set; }
        public ReadTrancaDto Tranca { get; set; }
        public ReadTotemDto Totem { get; set; }
        public ReadCiclistaDto Ciclista { get; set; }
        public ReadCobrancaDto Cobranca { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime? HoraFim { get; set; }                
               
        public ReadDadosRetiradaDto(ReadBicicletaDto bicicleta, 
            ReadTrancaDto tranca, ReadTotemDto totem, 
            ReadCiclistaDto ciclista, ReadCobrancaDto cobranca, 
            DateTime horaInicio, DateTime? horaFim)
        {
            Bicicleta = bicicleta;
            Tranca = tranca;
            Totem = totem;
            Ciclista = ciclista;
            Cobranca = cobranca;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
        }

        public override string ToString()
        {            
            return $"Dados de Retirada da bicicleta\n" +
                   $"Horário de retirada: {HoraInicio: t}\n" +
                   $"Horário previsto de devolução: {HoraFim: t}\n" +
                   $"Dados da cobrança realizada\n" +
                   $"{Cobranca}" +
                   $"Dados do Ciclista que realizou a retirada\n " +
                   $"{Ciclista}" +
                   $"Dados da bicicleta retirada\n " +
                   $"{Bicicleta}\n" +
                   $"Tranca da Bicicleta\n" +
                   $"{Tranca}" +                   
                   $"Totem de bicicletas\n" +
                   $"{Totem}\n" ;
        }
    }
}
