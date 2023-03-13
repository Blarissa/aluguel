using Aluguel.Data.Dtos;
using Aluguel.Models;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Validacao;

public class ValidacaoFuncionario : IValidator
{
    public List<Erro> Erros { get; set; }
    int id = 1;

    public ValidacaoFuncionario()
    {
        Erros = new List<Erro>();
    }

    public bool Nome(string valor)
    {
        if (valor.Length < 3)
        {
            Erros.Add(new Erro(
                    id.ToString(),
                    "Nome deve ter no mínimo 3 caracteres"));

            id++;

            return false;
        }

        return true;
    }

    public bool Email(string valor)
    {
        if (!new EmailAddressAttribute().IsValid(valor))
        {
            Erros.Add(new Erro(
                id.ToString(),
                "Email inválido"));

            id++;

            return false;
        }

        return true;
    }

    public bool Senha(string valor1, string valor2)
    {
        if (!valor1.Equals(valor2))
        {
            Erros.Add(new Erro(
                id.ToString(),
                "Senhas diferentes"));

            id++;

            return false;
        }

        return true;
    }

    public bool Documento(string valor)
    {
        if (!ValidacaoCpf.IsValid(valor))
        {
            Erros.Add(new Erro(
                id.ToString(),
                "CPF deve conter 11 dígitos"));

            id++;

            return false;
        }

        return true;
    }

    public bool Funcao(string valor)
    {
        if (!(valor.Equals("ADMINISTRATIVO") ||
               valor.Equals("REPARADOR")))
        {
            Erros.Add(new Erro(
             id.ToString(),
             "Função deve ser REPARADOR ou ADMINISTRATIVO"));

            id++;

            return false;
        }

        return true;
    }

    public bool Matricula(int idFuncionario)
    {
        if (idFuncionario == null)
        {
            Erros.Add(new Erro(
                id.ToString(),
                "Matrícula inválida"));

            id++;

            return false;
        }

        return true;
    }

    public bool Idade(int idade)
    {
        if (idade < 18)
        {
            Erros.Add(new Erro(
                id.ToString(),
                "Idade deve ser maior que 18!"));

            id++;

            return false;
        }

        return true;
    }

    public bool IsValid(CreateFuncionarioDto dto)
    {
        if (Nome(dto.Nome) & Email(dto.Email) &
            Senha(dto.Senha, dto.ConfirmaSenha) &
            Funcao(dto.Funcao) & Documento(dto.Cpf) &
            Idade(dto.Idade) & Matricula(dto.Matricula))
            return true;

        return false;
    }

    public bool IsValid(UpdateFuncionarioDto dto)
    {
        if (Nome(dto.Nome) &
            Senha(dto.Senha, dto.ConfirmaSenha) &
            Funcao(dto.Funcao))
            return true;

        return false;
    }
}
