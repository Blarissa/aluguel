namespace Aluguel.Validator
{
    public static class ValidacaoCpf
    {
        public static bool IsValid(string CPF)
        {
            if (string.IsNullOrEmpty(CPF) &&
                !CPF.Length.Equals(11) ||
                CPF.All(c => CPF[0].Equals(c)))
                return false;

            int i = 9;

            int somaJ = Soma(CPF, i);
            int restoJ = somaJ % 11;
            bool valorJ = Valor(CPF, restoJ, i);

            int j = 10;
            int somaK = Soma(CPF, j);
            int restoK = somaK % 11;            
            bool valorK = Valor(CPF, restoK, j);

            return valorJ && valorK;
        }

        private static bool Valor(string CPF, int restoJ, int n)
        {
            bool valor = false;

            if (restoJ == 0 || restoJ == 1)
                valor = (int)Char.GetNumericValue(CPF[n]) == 0;

            else if (restoJ >= 2 && restoJ <= 10)
                valor = (int)Char.GetNumericValue(CPF[n]) == (11 - restoJ);

            return valor;
        }

        private static int Soma(string CPF, int n)
        {
            int soma = 0;
            foreach (char s in CPF.Substring(0, n))
            {
                soma += (int)char.GetNumericValue(s) * n;
                n--;
            }

            return soma;
        }
    }
}
