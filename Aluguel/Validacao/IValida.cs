using Aluguel.Models;

namespace Aluguel.Validacao
{
    public interface IValida
    {
        bool CPF(string cpf);
        bool Data(string data);
        bool DataHora(string dataHora);
        bool Email(string email);
        bool Funcao(string funcao);
        bool Idade(string idade);
        bool Nacionalidade(string nacionalidade);
        bool Matricula(int matricula);
        bool Id(Guid id);
        bool Nome(string nome);        
        bool Passaporte(Passaporte passaporte);
        bool Senha(string senha, string confirmaSenha);              
        bool UrlFotoDocumento(string foto);
    }
}