using Aluguel.Models;
using Aluguel.Repositorios.Contracts;

namespace Aluguel.Data.Dao;

public class FuncionarioRepository : IFuncionarioRepository
{
    private AluguelContexto contexto;

    public FuncionarioRepository(AluguelContexto contexto)
    {
        this.contexto = contexto;
    }

    public void Adicionar(Funcionario funcionario)
    {
        contexto.Funcionarios.Add(funcionario);
        contexto.SaveChanges();
    }    

    public void Deletar(Funcionario funcionario)
    {
        contexto.Funcionarios.Remove(funcionario);
        contexto.SaveChanges();
    }
    
    public Funcionario? RecuperarPorMatricula(int matricula)
    {
        return contexto.Funcionarios
            .FirstOrDefault(f => f.Matricula == matricula);
    }

    public IList<Funcionario> RecuperarTodos()
    {
        return contexto.Funcionarios.ToList();
    }   
}
