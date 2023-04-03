using Aluguel.Models;

namespace Aluguel.Repositorios.Contracts; 

public interface IFuncionarioRepository 
{
    void Adicionar(Funcionario funcionario);    
    void Deletar(Funcionario funcionario);
    IList<Funcionario> RecuperarTodos();
    Funcionario RecuperarPorMatricula(int matricula);
}