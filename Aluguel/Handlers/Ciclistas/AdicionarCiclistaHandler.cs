using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Commands;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;
using AutoMapper;
using Aluguel.Models.Entidades;
using Aluguel.Commands.Results;
using Aluguel.Validacao;
using Aluguel.Servicos;
using Aluguel.Data.Dtos.Servicos.Externo;
using System.Net;

namespace Aluguel.Handlers.Ciclistas;

public class AdicionarCiclistaHandler : IHandler<AdicionarCiclistaCommand>
{
    private readonly ICiclistaRepository _repositoryCiclista;
    private readonly IPaisRepository _repositoryPais;
    private readonly IMapper _mapper;
    private readonly IValidaRegraDoBancoCiclista _valida;
    private readonly IExternoService _externo;

    public AdicionarCiclistaHandler(ICiclistaRepository repositoryCiclista, 
        IPaisRepository repositoryPais, IMapper mapper, IExternoService externo)
    {
        _repositoryCiclista = repositoryCiclista;
        _repositoryPais = repositoryPais;
        _mapper = mapper;
        _externo = externo;
        _valida = new ValidaRegraDoBancoCiclista(_repositoryCiclista, _repositoryPais);
    }

    public ICommandResult Handle(AdicionarCiclistaCommand command)
    {               
        //validação dos dados passados
        if (!command.Validar())
            return new UnprocessableEntityCommandResult(command.Erros);

        //se já existe o email
        if (_valida.EmailCiclista(command.Ciclista.Email))
        {
            command.AdicionarErro(new Erro("020a"));
            return new UnprocessableEntityCommandResult(command.Erros);
        }

        //validação do documento
        ValidaDocumento(command, _valida);

        var ciclista = _mapper.Map<Ciclista>(command.Ciclista);
        
        //validação do cartão
        var resultado = ValidaCartaoExterno(command).Result;

        //cartão reprovado ou dados inválidos
        if (resultado.StatusCode.Equals(HttpStatusCode.UnprocessableEntity))
        {
            command.AdicionarErro(new Erro("002x"));
            return new UnprocessableEntityCommandResult(command.Erros);
        }

        //cartão aprovado
        if (resultado.StatusCode.Equals(HttpStatusCode.OK))
        {
            var cartaoDeCredito = _mapper.Map<CartaoDeCredito>(command.MeioDePagamento);

            cartaoDeCredito.Ciclista = ciclista;
            
            //adicionando ciclista
            _repositoryCiclista.AdicionarCiclistaComCartao(ciclista, cartaoDeCredito);
            
            var resultadoEmail = MandarEmail(command).Result;

            //se o email foi enviado finaliza 
            if (resultadoEmail.StatusCode.Equals(HttpStatusCode.OK))
                return new CreatedCommandResult(command);            
        }        
        
        return new GenericCommandResult();        
    }

    private async Task<HttpResponseMessage> ValidaCartaoExterno(AdicionarCiclistaCommand command)
    {
        var mes = command.MeioDePagamento.MesValidade;
        var ano = command.MeioDePagamento.AnoValidade;

        var cartao = new CreateValidaCartaoDto()
        {
            NomeTitular = command.MeioDePagamento.Nome,
            Numero = command.MeioDePagamento.Numero,
            Cvv = command.MeioDePagamento.CodigoSeguranca,
            Validade = $"01/{mes}/{ano}"
        };

        return await _externo.ValidacaoCartao(cartao);        
    }

    private static void ValidaDocumento(AdicionarCiclistaCommand command, 
        IValidaRegraDoBancoCiclista valida)
    {
        //se o ciclista for brasileiro
        if (command.Ciclista.Nacionalidade.Equals("BRASILEIRO"))
        {
            //se já existe o cpf
            if (valida.CPFCiclista(command.Ciclista.Cpf))            
                command.AdicionarErro(new Erro("019a"));            
        }
        else
        {
            var codigo = command.Ciclista.Passaporte.Pais.Codigo;

            // o código do país é inválido
            if (!valida.Passaporte(codigo))
                command.AdicionarErro(new Erro("023a"));
        }
    }

    private async Task<HttpResponseMessage> MandarEmail(AdicionarCiclistaCommand command)
    {
        var email = command.Ciclista.Email;
        var mensagem = "Ciclista cadastrado, realize a confirmação de email!";

        // criando um email com os todos os dados do aluguel atual
        var conteudo = new CreateEnviarEmailDto(
            email,
            "Aluguel atual",
            mensagem);

        // realizando o envio do email
        return await _externo.EnviarEmail(conteudo);
    }
}