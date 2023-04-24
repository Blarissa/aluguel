using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Passaporte;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Aluguel.Validacao
{
    public static class ValidaFormato
    {
        //se números do cartão forem dígitos
        //se cvv for inteiro
        //se o nome tiver pelo menos 2 caracteres e no máximo 60
        public static bool CartaoFormato(CreateMeioDePagamentoDto cartao)
        {
            return NumeroCartaoFormato(cartao.Numero) &&                   
                   NomeFormato(cartao.Nome);
        }

        //se for nulo ou vazio
        //se algum for diferente de dígito
        //se o tamanho for diferente de 11
        //se todos os dígitos forem iguais
        public static bool CPFFormato(string cpf)
        {            
            return !string.IsNullOrEmpty(cpf) &&
                   cpf.All(c => char.IsDigit(c)) &&
                   cpf.Length.Equals(11) &&
                   cpf.Any(c => !cpf[0].Equals(c));
        }

        //se estiver no formato dd/MM/yyyy
        public static bool DataFormato(string data)
        {
            return DateTime.TryParseExact(
                data,
                "d",
                new CultureInfo("pt-BR"),
                DateTimeStyles.None,
                out DateTime dt);
        }

        //se estiver no formato dd/MM/yyyy HH:mm
        public static bool DataHoraFormato(string dataHora)
        {
            return DateTime.TryParseExact(
                dataHora,
                "g",
                new CultureInfo("pt-BR"),
                DateTimeStyles.None,
                out DateTime dtHr);
        }

        //se estiver no formato user@example.com
        public static bool EmailFormato(string email)
        {
            return MailAddress.TryCreate(email, out MailAddress mail);
        }

        //se extensão do arquivo é válida
        public static bool FotoFormato(string foto)
        {
            string[] extensoes = { ".png", ".jpg" , ".jpeg" };

            var ext = Path.GetExtension(foto).ToLowerInvariant();

            return !string.IsNullOrEmpty(ext) && extensoes.Contains(ext);
        }

        //se for um EFuncao
        public static bool FuncaoFormato(string funcao)
        {
            funcao = funcao.ToUpper();

            return funcao.Equals("REPADADOR") ||
                   funcao.Equals("ADMINISTRATIVO");
        }

        //se é formato guid 
        public static bool GuidFormato(string value)
        {
            return Guid.TryParse(value, out Guid g);
        }

        //se é formato int 
        public static bool IntFormato(string value)
        {
            return int.TryParse(value, out int m);
        }

        //se o nome tiver pelo menos 2 caracteres e no máximo 60
        public static bool NomeFormato(string nome)
        {
            return nome.Length >= 2 && 
                   nome.Length <= 60;
        }

        //se for um EFuncao
        public static bool NacionalideFormato(string nacionalidade)
        {
            nacionalidade = nacionalidade.ToUpper();

            return nacionalidade.Equals("BRASILEIRO") ||
                   nacionalidade.Equals("ESTRANGEIRO");
        }

        //se o número do passaporte é válido
        //se o código do pais tem 2 caracteres
        public static bool PassaporteFormato(CreatePassaporteDto passaporte)
        {            
            if(!NumeroPassaporte(passaporte.Numero) ||
                !PaisFormato(passaporte.Pais.Codigo))
                return false;

            return true;
        }        

        //se o código do pais tem 2 caracteres
        private static bool PaisFormato(string codigo)
        {
            codigo = codigo.ToLower();

            return codigo.Length == 2;
        }

        //se o número do passaporte é válido
        private static bool NumeroPassaporte(string numero)
        {
            Regex re = new Regex(@"^[A-PR-WYa-pr-wy][1-9]\d\s?\d{4}[1-9]$");

            if (re.IsMatch(numero))
                return true;

            return false;
        }
        
        private static bool NumeroCartaoFormato(string numeroCartao)
        {
            return numeroCartao.All(n => char.IsDigit(n));
        }
    }
}
