using System.ComponentModel.DataAnnotations;

namespace Aluguel.Validator
{
    public class ValidacaoFuncionario: IValidator
    {
        public bool Nome(string valor)
        {
            return valor.Length > 3;
        }

        public bool Email(string valor)
        {
            return new EmailAddressAttribute().IsValid(valor);
        }

        public bool Senha(string valor1, string valor2)
        {
            return valor1.Equals(valor2);
        }

        public bool Documento(string valor)
        {
            return ValidacaoCpf.IsValid(valor);
        }

        public bool Idade(string valor)
        {
            return int.Parse(valor) >= 18;
        }
    }
}
