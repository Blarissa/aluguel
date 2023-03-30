using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Aluguel.Models
{
    public class Pais
    {
        

        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }


    }   
}
