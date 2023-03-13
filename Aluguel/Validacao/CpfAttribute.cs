using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Aluguel.Validacao
{
    public class CpfAttribute : ValidationAttribute
    {
        private bool ValidaCpf(string cpf)
        {
            Regex rx = new Regex(@"(^\d{11}$)");
            if(!rx.Match(cpf).Success) {
                Console.WriteLine("Erro: Formato de CPF inválido!");
                return false;
            }

            string sequenciaUm = cpf.Substring(0,9);
            string verificadores = cpf.Substring(9, 2);

            int somaParcialVerificadorUm = 0;
            int counter = 0;

            //https://stackoverflow.com/questions/239103/convert-char-to-int-in-c-sharp
            //Tabela ascii ao ataque
            for(int i = 10; i > 1; i--) {
                somaParcialVerificadorUm += (sequenciaUm[counter] - '0') * i;
                counter++;
            }


            int digitoJCalculado = somaParcialVerificadorUm % 11 < 2 ? 0 : 11 - (somaParcialVerificadorUm % 11);

            if(digitoJCalculado != (verificadores[0] - '0')) {
                Console.WriteLine("Erro: CPF inválido");
                return false;
            }

            int somaParcialVerificadorDois = 0;
            counter = 0;
            string sequenciaDois = sequenciaUm + digitoJCalculado.ToString();
            for(int i = 11; i > 1; i--) {
                somaParcialVerificadorDois += (sequenciaDois[counter] - '0') * i;
                counter++;
            }

            int digitoKCalculado = somaParcialVerificadorDois % 11 < 2 ? 0 : 11 - (somaParcialVerificadorDois % 11);

            if(digitoKCalculado != (verificadores[1] - '0')) {
                Console.WriteLine("Erro: CPF inválido");
                return false;
            }

            return true;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string && ValidaCpf(value as string)) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Cpf Invalido");
        }
    }
}
