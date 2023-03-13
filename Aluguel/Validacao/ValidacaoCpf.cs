namespace Aluguel.Validacao
{
    public static class ValidacaoCpf
    {
        public static bool IsValid(string CPF)
        {
            //Avalia o CPF passado
            //se é nulo ou vazio
            //se a string recebida tem pelo menos um caracter diferente de um número
            //se todos os dígitos são iguais

            if (string.IsNullOrEmpty(CPF) ||
                CPF.Any(c => !char.IsNumber(c)) ||
                !CPF.Length.Equals(11) ||
                CPF.All(c => CPF[0].Equals(c)))
                return false;

            int i = 10;

            int somaJ = Soma(CPF, i);
            int restoJ = somaJ % 11;
            bool valorJ = Valor(CPF, restoJ, i);

            int j = 11;
            int somaK = Soma(CPF, j);
            int restoK = somaK % 11;
            bool valorK = Valor(CPF, restoK, j);

            return valorJ && valorK;
        }

        private static bool Valor(string CPF, int restoJ, int n)
        {
            bool valor = false;

            if (restoJ == 0 || restoJ == 1)
                valor = (int)char.GetNumericValue(CPF[n - 1]) == 0;

            else if (restoJ >= 2 && restoJ <= 10)
                valor = (int)char.GetNumericValue(CPF[n - 1]) == 11 - restoJ;

            return valor;
        }

        private static int Soma(string CPF, int n)
        {
            int soma = 0;
            foreach (char s in CPF.Substring(0, n - 1))
            {
                soma += (int)char.GetNumericValue(s) * n;
                n--;
            }

            return soma;
        }
    }
}
