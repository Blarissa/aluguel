using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using Aluguel.Validacao;

namespace Aluguel.Commands.Ciclistas;

public class AdicionarCiclistaCommand : BaseValidacao, ICommand
{
    public AdicionarCiclistaDto ciclistaDto { get; set; }
    IValida validacao;

    public AdicionarCiclistaCommand(AdicionarCiclistaDto ciclistaDto)
    {
        this.ciclistaDto = ciclistaDto;
        validacao = new Valida();
    }

    public bool Validar()
    {
        //se o email for inválido
        if (!validacao.Email(ciclistaDto.Ciclista.Email))
        {
            AdicionarErro(new Erro("006a"));
            return false;
        }

        //se a nacionalidade for inválida
        if (!validacao.Nacionalidade(ciclistaDto.Ciclista.Nacionalidade.ToString()))
            AdicionarErro(new Erro("013a"));

        //se o ciclista for brasileiro
        else if (ciclistaDto.Ciclista.Nacionalidade.Equals(ENacionalidade.BRASILEIRO))
        {
            //se o cpf não for válido
            if (!validacao.CPF(ciclistaDto.Ciclista.Cpf))
                AdicionarErro(new Erro("002a"));
            
            //se tiver dados no passaporte retorna erro e false 
            if(ciclistaDto.Ciclista.Passaporte != null)
            {
                AdicionarErro(new Erro("021a"));
                return false;
            }
        }
        //se  o ciclista for estrangeiro
        else
        {
            //se o passaporte não for válido
            if (!validacao.Passaporte(ciclistaDto.Ciclista.Passaporte))
                AdicionarErro(new Erro("008a"));

            //se tiver dados no cpf retorna erro e false 
            if (ciclistaDto.Ciclista.Cpf != null)
            {
                AdicionarErro(new Erro("022a"));
                return false;
            }
        }

        //se o nome for inválido
        if (!validacao.Nome(ciclistaDto.Ciclista.Nome))
            AdicionarErro(new Erro("001a"));

        //se a senha for inválida
        if (!validacao.Senha(ciclistaDto.Ciclista.Senha,
            ciclistaDto.Ciclista.ConfirmaSenha))
            AdicionarErro(new Erro("007a"));

        //se a data de nascimento for inválida
        if (!validacao.DataNascimento(ciclistaDto.Ciclista.DataNascimento.ToShortDateString()))
            AdicionarErro(new Erro("005a"));
        
        //se a foto for inválida
        if (!validacao.UrlFotoDocumento(ciclistaDto.Ciclista.UrlFotoDocumento.ToString()))
            AdicionarErro(new Erro("009a"));

        //se o cartão for inválido
        if (!validacao.CartaoCredito(ciclistaDto.MeioDePagamento))
            AdicionarErro(new Erro("004a"));

        return Valida;
    }
}