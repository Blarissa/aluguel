using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Passaporte;

namespace Aluguel.Validacao
{
    public class Valida : IValida
    {
        public bool CartaoCredito(ReadCartaoDto cartao)
        {
            return ValidaFormato.CartaoFormato(cartao) &&
                   ValidaRegras.DataRegras(cartao.MesValidade, cartao.AnoValidade);                   
        }

        public bool CPF(string cpf)
        {
            return ValidaFormato.CPFFormato(cpf) &&
                   ValidaRegras.CPFRegras(cpf);
        }

        public bool DataNascimento(string data)
        {
            return ValidaFormato.DataFormato(data) &&
                   ValidaRegras.DataNascimentoRegras(data);
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

        public bool Id(string id)
        {
            return ValidaFormato.GuidFormato(id);
        }

        public bool Idade(string idade)
        {
            return ValidaFormato.IntFormato(idade) &&
                   ValidaRegras.IdadeRegras(idade);
        }

        public bool Matricula(string matricula)
        {
            return ValidaFormato.IntFormato(matricula);
        }

        public bool Nacionalidade(string nacionalidade)
        {
            return ValidaFormato.NacionalideFormato(nacionalidade);
        }
        
        public bool Nome(string nome)
        {
            return ValidaFormato.NomeFormato(nome);
        }
        
        public bool Passaporte(CreatePassaporteDto passaporte)
        {
            return ValidaFormato.PassaporteFormato(passaporte);
        }
        
        public bool Senha(string senha, string confirmaSenha)
        {
            return senha.Equals(confirmaSenha);
        }                
        
        public bool UrlFotoDocumento(string foto)
        {
            return ValidaFormato.FotoFormato(foto);
        }               
    }
}
