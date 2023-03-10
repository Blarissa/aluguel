using Aluguel.Data.Dtos;
using Aluguel.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Aluguel.Validator
{
    public class ValidacaoFuncionario : IValidator, IValidatorFuncionario
    {
        public bool Nome(string valor)
        {
            return valor.Length > 3;
        }

        public bool Email(string valor)
        {
            return new EmailAddressAttribute().IsValid(valor);
        }

        public bool Senha(string valor1, string valor2)
        {
            return valor1.Equals(valor2);
        }

        public bool Documento(string valor)
        {
            return ValidacaoCpf.IsValid(valor);
        }

        public bool Funcao(string valor)
        {
            return valor.Equals("ADMINISTRATIVO") || 
                   valor.Equals("REPARADOR");
        }

        public bool IsValid(CreateFuncionarioDto dto)
        {
            if (Nome(dto.Nome) || Email(dto.Email) ||
                Senha(dto.Senha, dto.ConfirmaSenha) ||
                Funcao(dto.Funcao) || Documento(dto.Cpf) ||
                Matricula(dto.Matricula))
                return false;

            return true;
        }

        public bool IsValid(UpdateFuncionarioDto dto)
        {
            if (Nome(dto.Nome) ||
                Senha(dto.Senha, dto.ConfirmaSenha) ||
                Funcao(dto.Funcao))
                return false;

            return true;
        }

        public bool Matricula(int idFuncionario)
        {
            return true;
        }
    }
}
