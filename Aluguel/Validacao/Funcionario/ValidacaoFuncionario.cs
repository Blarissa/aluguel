using Aluguel.Data;
using Aluguel.Data.Dao;
using Aluguel.Data.Dtos;
using Aluguel.Models;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Validacao;

public class ValidacaoFuncionario : IValidator
{
    public List<Erro> Erros { get; set; }
    int codigo = 1;
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
            Erros.Add(new Erro()
            {                  
                Codigo = codigo,
                Mensagem = "Nome deve ter no mínimo 3 caracteres"
            });

            codigo++;

            return false;
        }

        return true;
    }

    public bool Email(string valor)
    {
        if (!new EmailAddressAttribute().IsValid(valor))
        {
            Erros.Add(new Erro()
            {
                Codigo = codigo,
                Mensagem = "Email inválido"
            });
                
            codigo++;

            return false;
        }

        return true;
    }

    public bool Senha(string valor1, string valor2)
    {
        if (!valor1.Equals(valor2))
        {
            Erros.Add(new Erro() 
            { 
                Codigo = codigo, 
                Mensagem = "Senhas diferentes" 
            });

            codigo++;

            return false;
        }

        return true;
    }

    public bool Documento(string valor)
    {
        if (!ValidacaoCpf.IsValid(valor))
        {
            Erros.Add(new Erro() 
            { 
                Codigo = codigo, 
                Mensagem = "CPF deve conter 11 dígitos" 
            });

            codigo++;

            return false;
        }

        return true;
    }

    public bool Funcao(string valor)
    {
        if (!(valor.Equals("ADMINISTRATIVO") ||
               valor.Equals("REPARADOR")))
        {
            Erros.Add(new Erro() {
                Codigo = codigo,
                Mensagem = "Função deve ser REPARADOR ou ADMINISTRATIVO"
            });

            codigo++;

            return false;
        }

        return true;
    }

    public bool Matricula(int idFuncionario)
    {
        if (ValidacaoMatricula.Exists(funcionarioDao, idFuncionario))
        {
            Erros.Add(new Erro()
            {
                Codigo = codigo,
                Mensagem = "Matrícula existente"
            });

            codigo++;

            return false;
        }

        return true;
    }

    public bool Idade(int idade)
    {
        if (idade < 18)
        {
            Erros.Add(new Erro()
            {
                Codigo = codigo,
                Mensagem = "Idade deve ser maior que 18!"
            });
                            
            codigo++;

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
