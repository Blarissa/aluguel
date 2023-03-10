using Aluguel.Migrations;
using Aluguel.Models;

namespace Aluguel.Data.Dao;

public class FuncionarioDao
{
    private AluguelContexto contexto;

    public FuncionarioDao(AluguelContexto contexto)
    {
        this.contexto = contexto;
    }

    public void AdicionaFuncionario(Funcionario funcionario)
    {
        contexto.Funcionarios.Add(funcionario);
        contexto.SaveChanges();
    }

    public void DeletaFuncionario(Funcionario funcionario)
    {
        contexto.Funcionarios.Remove(funcionario);
        contexto.SaveChanges();
    }

    public Funcionario? RecuperaFuncionarioPorId(int idFuncionario)
    {
        return contexto.Funcionarios
            .FirstOrDefault(f => f.Matricula == idFuncionario);
    }

    public IList<Funcionario> RecuperaTodosFuncionarios()
    {
        return contexto.Funcionarios.ToList();
    }

}
