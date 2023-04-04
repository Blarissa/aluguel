using Aluguel.Migrations;
using Aluguel.Models;

namespace Aluguel.Validacao
{
    public class Valida : IValida
    {
        public bool CPF(string cpf)
        {
            return ValidaFormato.CPFFormato(cpf) && 
                   ValidaRegras.CPFRegras(cpf);
        }

        public bool Data(string data)
        {
            return ValidaFormato.DataFormato(data);
        }

        public bool DataHora(string dataHora)
        {
            return ValidaFormato.DataHoraFormato(dataHora);
        }

        public bool Email(string email)
        {
            return ValidaFormato.EmailFormato(email);
        }

        public bool Funcao(string funcao)
        {
            return ValidaFormato.FuncaoFormato(funcao);
        }

        public bool Idade(string idade)
        {
            throw new NotImplementedException();
        }

        public bool Nacionalidade(string nacionalidade)
        {
            return ValidaFormato.NacionalideFormato(nacionalidade);
        }
        
        public bool Nome(string nome)
        {
            return ValidaFormato.NomeFormato(nome);
        }
        
        public bool Passaporte(Passaporte passaporte)
        {
            return Pais(passaporte.Pais);
        }

        
        public bool Senha(string senha, string confirmaSenha)
        {
            return senha.Equals(confirmaSenha);
        }                

        //falta fazer
        public bool UrlFotoDocumento(string foto)
        {
            return ValidaFormato.FotoFormato(foto);
        }
        
        private bool Pais(Pais pais)
        {
            return ValidaFormato.PaisFormato(pais.Codigo);
        }
    }
}
