using Aluguel.Migrations;
using Aluguel.Models;

namespace Aluguel.Data.Dao;

public class FuncionarioDao : IDao<Funcionario>, IDaoComInt<Funcionario>
{
    private AluguelContexto contexto;

    public FuncionarioDao(AluguelContexto contexto)
    {
        this.contexto = contexto;
    }

    public void Adicionar(Funcionario t)
    {
        contexto.Funcionarios.Add(t);
        contexto.SaveChanges();
    }

    public void Deletar(Funcionario t)
    {
        contexto.Funcionarios.Remove(t);
        contexto.SaveChanges();
    }
    

    public Funcionario? RecuperarPorId(int id)
    {
        return contexto.Funcionarios
            .FirstOrDefault(f => f.Matricula == id);
    }

    public IList<Funcionario> RecuperarTodos()
    {
        return contexto.Funcionarios.ToList();
    }

    

}
