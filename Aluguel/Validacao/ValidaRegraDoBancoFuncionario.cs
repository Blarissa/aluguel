using Aluguel.Repositorios.Contracts;

namespace Aluguel.Validacao
{
    public class ValidaRegraDoBancoFuncionario : IValidaRegraBancoFuncionario
    {
        IFuncionarioRepository _funcionarioRepository;

        public ValidaRegraDoBancoFuncionario(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        //se existe algum funcionário com o cpf passado
        public bool CPFFuncionario(string cpf)
        {
            return _funcionarioRepository
                .RecuperarTodos()
                .Any(f => f.Cpf == cpf);
        }

        //se existe algum funcionário com a matricula passada
        public bool IdFuncionario(int matricula)
        {
            return _funcionarioRepository
                .RecuperarTodos()
                .Any(f => f.Matricula == matricula);
        }
    }
}
