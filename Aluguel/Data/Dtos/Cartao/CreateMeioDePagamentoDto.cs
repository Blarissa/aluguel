using Aluguel.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Data.Dtos.Cartao
{
    public class CreateMeioDePagamentoDto
    {

        public string Nome { get; set; }


        public string Numero { get; set; }

        public int MesValidade { get; set; }


        public int AnoValidade { get; set; }


        public int CodigoSeguranca { get; set; }
    }
}