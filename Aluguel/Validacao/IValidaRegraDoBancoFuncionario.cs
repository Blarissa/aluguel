namespace Aluguel.Validacao
{
    public interface IValidaRegraBancoFuncionario
    {
        bool CPFFuncionario(string cpf);
        bool IdFuncionario (int matricula);
    }
}
