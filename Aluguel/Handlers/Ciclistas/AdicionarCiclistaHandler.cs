using Aluguel.Commands.Ciclistas;
using Aluguel.Commands.Contracts;
using Aluguel.Handlers.Contracts;
using Aluguel.Repositorios.Contracts;
using AutoMapper;
using Aluguel.Models.Entidades;
using Aluguel.Commands.Results;
using Aluguel.Validacao;
using Aluguel.Servicos;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Models;
using Aluguel.Data.Dtos.Ciclista;

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

        Console.WriteLine(command.ciclistaDto.Ciclista);

        //validação dos dados passados
        if (!command.Validar())
            return new UnprocessableEntityCommandResult(command.Erros);

        //se já existe o email
        if (_valida.EmailCiclista(command.ciclistaDto.Ciclista.Email))
        {
            command.AdicionarErro(new Erro("020a"));
            return new UnprocessableEntityCommandResult(command.Erros);
        }

        //validação do documento
        ValidaDocumento(command, _valida, _repositoryPais);

        //validação do cartão
        //var resultado = ValidaCartaoExterno(command).Result;

        //validação do cartão precisa da API externo
        //var resultado = ValidaCartaoExterno(command).Result;

        ////cartão reprovado ou dados inválidos
        //if (resultado.StatusCode.Equals(HttpStatusCode.UnprocessableEntity))
        //{
        //    command.AdicionarErro(new Erro("002x"));
        //    return new UnprocessableEntityCommandResult(command.Erros);
        //}

        //cartão aprovado
        //if (resultado.StatusCode.Equals(HttpStatusCode.OK))                

        var ciclista = _mapper.Map<CreateCiclistaDto, Ciclista>(command.ciclistaDto.Ciclista);
        var cartaoDeCredito = _mapper.Map<CartaoDeCredito>(command.ciclistaDto.MeioDePagamento);

        cartaoDeCredito.Ciclista = ciclista;
            
        //adicionando ciclista
        _repositoryCiclista.AdicionarCiclistaComCartao(ciclista, cartaoDeCredito);

        //enviando email para o ciclista precisa da API externo
        //var resultadoEmail = MandarEmail(command).Result;

        //se o email foi enviado finaliza 
        //if (resultadoEmail.StatusCode.Equals(HttpStatusCode.OK))
        return new CreatedCommandResult(command.ciclistaDto);                    
    }

    private static void ValidaDocumento(AdicionarCiclistaCommand command, 
        IValidaRegraDoBancoCiclista valida, IPaisRepository paisRepository)
    {
        //se o ciclista for brasileiro
        if (command.ciclistaDto.Ciclista.Nacionalidade.Equals(ENacionalidade.BRASILEIRO))
        {
            //se já existe o cpf
            if (valida.CPFCiclista(command.ciclistaDto.Ciclista.Cpf))            
                command.AdicionarErro(new Erro("019a"));            
        }
        else
        {
            var numero = command.ciclistaDto.Ciclista.Passaporte.Numero;
            var codigo = command.ciclistaDto.Ciclista.Passaporte.Pais;

            //passaporte inválido
            if (valida.Passaporte(numero))
                command.AdicionarErro(new Erro("023a"));

            //pais inválido
            else if (!valida.Pais(codigo))
                command.AdicionarErro(new Erro("010a"));
            //adicionando id do pais no passaporte
            else
                command.ciclistaDto.Ciclista.Passaporte.PaisId = paisRepository
                .RecuperarPorCodigo(command.ciclistaDto.Ciclista.Passaporte.Pais.ToLower())
                .Id;
        }
    }

    private async Task<HttpResponseMessage> ValidaCartaoExterno(AdicionarCiclistaCommand command)
    {
        var mes = command.ciclistaDto.MeioDePagamento.MesValidade;
        var ano = command.ciclistaDto.MeioDePagamento.AnoValidade;

        var cartao = new CreateValidaCartaoDto()
        {
            NomeTitular = command.ciclistaDto.MeioDePagamento.Nome,
            Numero = command.ciclistaDto.MeioDePagamento.Numero,
            Cvv = command.ciclistaDto.MeioDePagamento.CodigoSeguranca,
            Validade = $"01/{mes}/{ano}"
        };

        return await _externo.ValidacaoCartao(cartao);        
    }

    private async Task<HttpResponseMessage> MandarEmail(AdicionarCiclistaCommand command)
    {
        var email = command.ciclistaDto.Ciclista.Email;
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