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

        //se é uma data do futuro
        public static bool DataRegras(string data)
        {
            var dt = DateTime.Parse(data);

            return dt > DateTime.Now;
        }

        //se é uma data do futuro
        public static bool DataRegras(int mes, int ano)
        {            
            var dt = new DateTime(ano, mes, 1);

            return dt > DateTime.Now;
        }

        //se a data de nascimento é de um adulto
        public static bool DataNascimentoRegras(string data)
        {
            var dt = DateTime.Parse(data);
            
            return DateTime.Now.Subtract(dt).Days/365 >= 18;
        }

        public static bool IdadeRegras(string idade)
        {
            return int.Parse(idade) >= 18;
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
