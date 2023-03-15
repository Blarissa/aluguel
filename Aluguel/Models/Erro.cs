using Aluguel.Migrations;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Aluguel.Models
{
    public class Erro
    {
        public Erro(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        public string Codigo { get; set; }
        public string Mensagem { get; set; }     
        
    }    

    public class Erros
    {
        List<Erro> erros = new();

        public Erros()
        {
            erros = new List<Erro>()
            {
                //not found
                new Erro("000","Não encontrado!"),

                //NOME
                new Erro("001","Nome deve ter pelo menos 5 caracteres!"),
                //CPF
                new Erro("002", "CPF deve ter 11 dígitos!"),
                //DATA DE VALIDADE
                new Erro("003", "Data de validade expirada!"),
                //DATA
                new Erro("004", "Data inválida!"),
                //IDADE
                new Erro("005", "Idade deve ser pelo menos 18!"),
                //EMAIL
                new Erro("006", "Email dever ser no padrão user@example.com!"),
                //SENHA
                new Erro("007", "Senha de confirmação diferente!"),
                //PASSAPORTE
                new Erro("009", "Passaporte inválido!"),
                //PASSAPORTE
                new Erro("010", "CVV inválido!"),            
                //PASSAPORTE
                new Erro("011", "Pais deve ter somente 2 caracteres!"),
                //PASSAPORTE
                new Erro("012", "Status dever ser REPARADOR ou ADMINISTRATIVO!"),
                //PASSAPORTE
                new Erro("013", "Nacionalidade dever ser BRASILEIRO ou ESTRANGEIRO!"),
            };
        }        

        public Erro? GetErro(int codigo)
        {
            return erros.FirstOrDefault(e => e.Codigo.Equals(codigo.ToString()));
        }

        
    }
}
