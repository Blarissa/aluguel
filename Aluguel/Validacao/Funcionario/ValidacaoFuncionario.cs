using Aluguel.Data;
using Aluguel.Data.Dao;
using Aluguel.Data.Dtos;
using Aluguel.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Aluguel.Validacao;

public class ValidacaoFuncionario : IValidator
{
    public List<Erro> Erros { get; set; }
    private FuncionarioDao funcionarioDao;

    public ValidacaoFuncionario(FuncionarioDao funcionarioDao)
    {
        this.funcionarioDao = funcionarioDao;
        Erros = new List<Erro>();
    }

    public bool Nome(string valor)
    {
        if (valor.Length < 3)
        {
            Erros.Add(new Erros().GetErro("001"));

            return false;
        }

        return true;
    }

    public bool Email(string valor)
    {
        if (!new EmailAddressAttribute().IsValid(valor))
        {
            Erros.Add(new Erros().GetErro("006"));

            return false;
        }

        return true;
    }

    public bool Senha(string valor1, string valor2)
    {
        if (!valor1.Equals(valor2) ||
            string.IsNullOrEmpty(valor1) ||
            string.IsNullOrEmpty(valor2))
        {
            Erros.Add(new Erros().GetErro("007"));

            return false;
        }

        return true;
    }

    public bool Documento(string valor)
    {
        if (!ValidacaoCpf.IsValid(valor))
        {
            Erros.Add(new Erros().GetErro("002"));

            return false;
        }

        return true;
    }

    public bool Funcao(string valor)
    {
        if (!(valor.Equals("ADMINISTRATIVO") &&
               valor.Equals("REPARADOR")) || 
               string.IsNullOrEmpty(valor))
        {
            Erros.Add(new Erros().GetErro("012"));

            return false;
        }

        return true;
    }

    public bool Matricula(int idFuncionario)
    {
        if (funcionarioDao.RecuperaFuncionarioPorId(idFuncionario) != null)
        {
            Erros.Add(new Erros().GetErro("014"));

            return false;
        }

        return true;
    }

    public bool Idade(int idade)
    {
        if (idade < 18)
        {
            Erros.Add(new Erros().GetErro("005"));

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
            Funcao(dto.Funcao) &
            Senha(dto.Senha, dto.ConfirmaSenha))
            return true;

        return false;
    }
}
