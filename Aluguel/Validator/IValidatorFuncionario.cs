using Aluguel.Data.Dtos;

namespace Aluguel.Validator
{
    public interface IValidatorFuncionario
    {
        bool Funcao(int valor);
        bool IsValid(CreateFuncionarioDto dto);
        bool IsValid(UpdateFuncionarioDto dto);
        bool Matricula(int idFuncionario);
    }
}