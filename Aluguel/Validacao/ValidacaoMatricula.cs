using Aluguel.Data;
using Aluguel.Data.Dao;

namespace Aluguel.Validacao
{
    public class ValidacaoMatricula 
    {                
        public static bool Exists(FuncionarioDao funcionarioDao, int matricula)
        {
            return funcionarioDao.RecuperaFuncionarioPorId(matricula) != null;
        }
    }
}
