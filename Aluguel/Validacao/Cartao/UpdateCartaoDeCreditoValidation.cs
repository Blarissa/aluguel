using System.Text.RegularExpressions;
using Aluguel.Data.Dtos.Cartao;

namespace Aluguel.Validacao.Cartao
{
    public class UpdateCartaoDeCreditoValidation
    {
        private bool ValidaNome(string nome)
        {
            Regex nomeRegex = new Regex(@"(^[A-z ]{3,}$)");
            if(!nomeRegex.IsMatch(nome)) return false;

            return true;
        }

        private bool ValidaNumero(string numero)
        {
            Regex numeroCartaoRegex = new Regex(@"(\d){16}");
            if(!numeroCartaoRegex.IsMatch(numero)) return false;

            return true;
        }

        private bool ValidaDataValidade(string stringData)
        {
            Regex dataRegex = new Regex(@"(\d){4}-(\d){2}-(\d){2}");
            if(!dataRegex.IsMatch(stringData)) return false;

            string[] valoresCampos = stringData.Split('-');

            //converte para datetime os campos de ano, mes, dia
            DateTime validadeEmDate = new DateTime(
                int.Parse(valoresCampos[0]),
                int.Parse(valoresCampos[1]),
                int.Parse(valoresCampos[2])
                );

            //cartao vencido
            if(validadeEmDate.CompareTo(DateTime.Today) < 0) return false;

            return true;
        }

        private bool ValidaCvv(int cvv) {
            if(cvv < 0 || cvv > 999) return false;

            return true;
        }


        public bool ValidaUpdateCartao(UpdateCartaoDeCreditoDto updateCartao)
        {
            bool isValid = true;

            isValid = isValid && ValidaNome(updateCartao.Nome);
            isValid = isValid && ValidaNumero(updateCartao.Numero);
            isValid = isValid && ValidaCvv(updateCartao.CodigoSeguranca);
            isValid = isValid && ValidaDataValidade(updateCartao.Validade);

            return isValid;
        }

    }
}
