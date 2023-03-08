namespace Aluguel.Models
{
    public class Funcionario
    {      
        public int Matricula { get; set; }
        public string Nome {get; set; }
        public string Email { get; set; }      
        public string Senha { get; set; }       
        public string Cpf { get; set; }
        public int Idade { get ; set; }
        public int Funcao { get; set; }

        public override string ToString()
        {
            return $"Matrícula: {Matricula}\n" +
                   $"Nome: {Nome}\n" +
                   $"Email: {Email}\n" +
                   $"Senha: {Senha}\n" +
                   $"CPF: {Cpf}\n" +
                   $"Idade: {Idade}\n" +
                   $"Funcao: {Funcao}\n";
        }
    }
}
