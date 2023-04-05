using Aluguel.Models;
using Aluguel.Validacao;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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
