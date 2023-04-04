using Aluguel.Models;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Validacao
{
    public static class ValidaRegras
    {
        //se for um CPF válido
        public static bool CPFRegras(string cpf)
        {
            int somaJ = Soma(cpf, 10);
            int somaK = Soma(cpf, 11);

            int restoJ = somaJ % 11;
            int restoK = somaK % 11;

            bool valorJ = Valor(cpf, restoJ, 9);
            bool valorK = Valor(cpf, restoK, 10);

            return valorJ && valorK;
        }

        public static bool  PassaporteRegras(Passaporte passaporte)
        {
            if()
            return true;
        }

        private static bool Valor(string cpf, int restoJ, int i)
        {
            bool valor = true;

            if (restoJ == 0 || restoJ == 1)
                valor = (int)Char.GetNumericValue(cpf[i]) == 0;

            else if (restoJ >= 2 && restoJ <= 10)
                valor = (int)Char.GetNumericValue(cpf[i]) == (11 - restoJ);

            return valor;
        }

        private static int Soma(string cpf, int i)
        {
            int somaJ = 0;

            foreach (char s in cpf.Substring(0, i - 1))
            {
                somaJ += (int)char.GetNumericValue(s) * i;
                i--;
            }

            return somaJ;
        }
    }
}
