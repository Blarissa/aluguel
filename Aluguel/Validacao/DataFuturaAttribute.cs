using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Aluguel.Validacao
{
    public class DataFuturaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is string) {

                string stringData = value as string ?? "";

                Regex dataRegex = new Regex(@"(\d){4}-(\d){2}-(\d){2}");
                if(!dataRegex.IsMatch(stringData)) return new ValidationResult("Formato inválido");

                string[] valoresCampos = stringData.Split('-');

                //converte para datetime os campos de ano, mes, dia
                DateTime validadeEmDate = new DateTime(
                int.Parse(valoresCampos[0]),
                int.Parse(valoresCampos[1]),
                int.Parse(valoresCampos[2])
                );

                //cartao vencido
                if(validadeEmDate.CompareTo(DateTime.Today) < 0) return new ValidationResult("Cartão Vencido");

                return ValidationResult.Success;

            }
            return new ValidationResult("Formato inválido");
        }

    }
}
