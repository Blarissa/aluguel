using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Passaporte;

namespace Aluguel.Validacao
{
    public interface IValida
    {
        bool CPF(string cpf);
        bool CartaoCredito(CreateMeioDePagamentoDto cartao);
        bool DataNascimento(string data);
        bool DataHora(string dataHora);
        bool Email(string email);
        bool Funcao(string funcao);
        bool Idade(string idade);
        bool Nacionalidade(string nacionalidade);
        bool Nome(string nome);        
        bool Passaporte(CreatePassaporteDto passaporte);
        bool Senha(string senha, string confirmaSenha);              
        bool UrlFotoDocumento(string foto);
    }
}