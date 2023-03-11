using Aluguel.Data.Dtos;
using Aluguel.Models;

namespace Aluguel.Validator
{
    public interface IValidatorFuncionario
    {
        bool Funcao(EFuncao valor);
        bool IsValid(CreateFuncionarioDto dto);
        bool IsValid(UpdateFuncionarioDto dto);
        bool Matricula(int idFuncionario);
    }
}