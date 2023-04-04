using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models;

namespace Aluguel.Validacao
{
    public interface IValida
    {
        bool CPF(string cpf);
        bool CartaoCredito(ReadCartaoDto cartao);
        bool DataNascimento(string data);
        bool DataHora(string dataHora);
        bool Email(string email);
        bool Funcao(string funcao);
        bool Idade(string idade);
        bool Nacionalidade(string nacionalidade);
        bool Matricula(string matricula);
        bool Id(string id);
        bool Nome(string nome);        
        bool Passaporte(PassaporteDto passaporte);
        bool Senha(string senha, string confirmaSenha);              
        bool UrlFotoDocumento(string foto);
    }
}