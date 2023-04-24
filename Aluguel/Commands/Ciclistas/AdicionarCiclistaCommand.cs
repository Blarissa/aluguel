using Aluguel.Commands.Contracts;
using Aluguel.Data.Dtos.Cartao;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models.Entidades;
using Aluguel.Validacao;

namespace Aluguel.Commands.Ciclistas;

public class AdicionarCiclistaCommand : BaseValidacao, ICommand
{
    public CreateCiclistaDto Ciclista { get; set; }
    public CreateMeioDePagamentoDto MeioDePagamento { get; set; }
    IValida validacao;

    public AdicionarCiclistaCommand() { }

    public AdicionarCiclistaCommand(CreateCiclistaDto ciclista, 
        CreateMeioDePagamentoDto meioDePagamento)
    {
        Ciclista = ciclista;
        MeioDePagamento = meioDePagamento;
        validacao = new Valida();
    }


    public bool Validar()
    {
        //se o email for inválido
        if (!validacao.Email(Ciclista.Email))
        {
            AdicionarErro(new Erro("006a"));
            return false;
        }

        //se a nacionalidade for inválida
        if (!validacao.Nacionalidade(Ciclista.Nacionalidade))
            AdicionarErro(new Erro("013a"));

        //se o nome for inválido
        if (!validacao.Nome(Ciclista.Nome))
            AdicionarErro(new Erro("001a"));

        //se a senha for inválida
        if (!validacao.Senha(Ciclista.Senha,
            Ciclista.ConfirmaSenha))
            AdicionarErro(new Erro("007a"));

        //se a data de nascimento for inválida
        if (!validacao.DataNascimento(Ciclista.DataNascimento.ToString()))
            AdicionarErro(new Erro("005a"));
        
        //se o ciclista for brasileiro
        else if (Ciclista.Nacionalidade.Equals("BRASILEIRO"))
        {
            //se o cpf não for válido
            if (!validacao.CPF(Ciclista.Cpf))
                AdicionarErro(new Erro("002a"));
            
            //se tiver dados no passaporte retorna erro e false 
            if(Ciclista.Passaporte != null)
            {
                AdicionarErro(new Erro("021a"));
                return false;
            }
        }
        //se  o ciclista for estrangeiro
        else
        {
            //se o passaporte não for válido
            if (!validacao.Passaporte(Ciclista.Passaporte))
                AdicionarErro(new Erro("008a"));

            //se tiver dados no cpf retorna erro e false 
            if (Ciclista.Cpf != null)
            {
                AdicionarErro(new Erro("022a"));
                return false;
            }
        }

        //se a foto for inválida
        if (!validacao.UrlFotoDocumento(Ciclista.UrlFotoDocumento.ToString()))
            AdicionarErro(new Erro("009a"));

        //se o cartão for inválido
        if (!validacao.CartaoCredito(MeioDePagamento))
            AdicionarErro(new Erro("004a"));

        return Valida;
    }
}