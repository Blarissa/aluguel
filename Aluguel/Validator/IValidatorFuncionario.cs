using Aluguel.Data.Dtos;
using Aluguel.Models;

namespace Aluguel.Validator
{
    public interface IValidatorFuncionario
    {
        bool Funcao(string valor);
        bool IsValid(CreateFuncionarioDto dto);
        bool IsValid(UpdateFuncionarioDto dto);
        bool Matricula(int idFuncionario);
    }
}