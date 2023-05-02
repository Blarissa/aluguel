using System.ComponentModel.DataAnnotations;
using Aluguel.Data.Dtos.Passaporte;
using Aluguel.Models;

namespace Aluguel.Data.Dtos.Ciclista
{
    public class ReadCiclistaDto
    {
        public Guid Id { get; set; }

        [EnumDataType(typeof(EStatusCiclista))]
        public string Status { get; set; }
        public string Nome { get; set; }       
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public CreatePassaporteDto? Passaporte { get; set; }

        [EnumDataType(typeof(ENacionalidade))]
        public string Nacionalidade { get; set; }
        public string Email { get; set; }
        public Uri UrlFotoDocumento { get; set; }

        public override string ToString()
        {            
            string documento;

            if (Nacionalidade.Equals("BRASILEIRO"))
                documento = $"CPF: {Cpf}\n";            
            else
                documento = $"Passaporte\n" +
                            $"Numero: {Passaporte.Numero}\n" +
                            $"Data de validade: {Passaporte.DataValidade}\n" +
                            $"Pais\n" +
                            $"Código: {Passaporte.Pais}\n" ;                            

            return $"Nome: {Nome}\n" +
                   $"Data de nascimento: {DataNascimento}\n" +
                   $"Email: {Email} \n" +
                   $"Nacionalidade: {Nacionalidade} \n" +
                   $"Documento\n" +
                   $"{documento}";
        }
    }
}
