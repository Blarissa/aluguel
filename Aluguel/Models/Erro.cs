using Aluguel.Migrations;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Aluguel.Models
{
    public class Erro
    {
        public string Codigo { get; set; }
        public string Mensagem { get; set; }         
        
        public Erro(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
    }    
}
