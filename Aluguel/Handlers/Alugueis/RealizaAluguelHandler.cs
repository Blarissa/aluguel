using Aluguel.Commands;
using Aluguel.Commands.Alugueis;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Results;
using Aluguel.Data.Dtos;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Data.Dtos.Emprestimo;
using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios;
using Aluguel.Repositorios.Contracts;
using Aluguel.Servicos;
using Aluguel.Validacao;
using Aluguel.Validacao.Interfaces;
using AutoMapper;
using Newtonsoft.Json;
using System.Net;

namespace Aluguel.Handlers.Alugueis
{
    public class RealizaAluguelHandler 
    {
        private readonly IAluguelRepository _repository;
        private readonly ICiclistaRepository _repositoryCiclista;
        private readonly IMapper _mapper;
        private readonly IEquipamentoService _equipamento;
        private readonly IExternoService _externo;
        private readonly IValidaRegraDoBancoCiclista _validaCiclista;
        GenericCommandResult _commandResult;
        private readonly IPaisRepository _repositoryPais;
        private readonly IValidaRegraEquipamento _validaEquipamento;
        private readonly IValidaRegraExterno _validaExterno;

        public RealizaAluguelHandler(IAluguelRepository repository, 
            IMapper mapper, IEquipamentoService equipamento,
            IExternoService externo, ICiclistaRepository repositoryCiclista,
            IPaisRepository repositoryPais)
        { 
            _repository = repository;
            _repositoryCiclista = repositoryCiclista;
            _mapper = mapper;
            _equipamento = equipamento;
            _externo = externo;
            _commandResult = new GenericCommandResult();
            _repositoryPais = repositoryPais;
            _validaCiclista = new ValidaRegraDoBancoCiclista(_repositoryCiclista, _repositoryPais);
            _validaEquipamento = new ValidaRegraEquipamento(_equipamento);
            _validaExterno = new ValidaRegraExterno(_externo);
        }

        public async Task<GenericCommandResult> Handle(RealizarAluguelCommand command)
        {
            var idCiclista = command.emprestimoDto.Ciclista;
            var idTranca = command.emprestimoDto.TrancaInicio;

            // ciclista que vai ser alugar
            var ciclista = _mapper
                .Map<ReadCiclistaDto>(
                _repositoryCiclista
                .BuscarPorId(idCiclista));

            // tranca da bicicleta que vai ser alugada
            var tranca = RetornaTranca(idTranca, _equipamento).Result;

            // se o ciclista não existe
            if (!_validaCiclista.IdCiclista(idCiclista))
                return NaoEncontrado(command, "000");

            // se não existe tranca 
            if (!_validaEquipamento.ExisteTranca(idTranca).Result)            
                return NaoEncontrado(command, "002e");

            // se a tranca não responde
            if (!_validaEquipamento.TrancaResponde(idTranca).Result)            
                return Invalido(command, "006e");

            // se o status da tranca não é válido
            if (!_validaEquipamento.StatusTranca(idTranca).Result)
                return Invalido(command, "001e");

            // se não existe bicicleta na tranca
            if (!_validaEquipamento.ExisteBicicletaNaTranca(idCiclista).Result)
                return NaoEncontrado(command, "005e");

            // bicleta que vai ser alugada
            var bicicleta = RetornaBicicleta(idCiclista, _equipamento).Result;

            // se o status do ciclista não é valido
            if (!_validaCiclista.Status(idCiclista))
                return Invalido(command, "017a");                 

            // se o ciclista não pode alugar
            if (!_validaCiclista.PodeAlugar(idCiclista))
            {
                var emprestivoAtivo = _repositoryCiclista
                    .RetornaEmprestimoAtivo(idCiclista);
               
                var mensagemAluguelAtual = _mapper
                    .Map<ReadEmprestimoDto>(emprestivoAtivo);

                MandarEmail(idCiclista, 
                    mensagemAluguelAtual.ToString());

                return Invalido(command, "018a");
            }

            // se o status da bicicleta não for em reparo
            if (_validaEquipamento.BicicletaEmReparo(idTranca).Result)
                return Invalido(command, "004e");
            
            // se o status da bicicleta não for disponível
            if (!_validaEquipamento.BicicletaDisponivel(idTranca).Result)            
                return Invalido(command, "003e");
            
            // criando cobrança de R$ 10,00 pelas duas primeiras horas de uso
            var cobrancaDto = new CreateCobrancaDto(10, idCiclista);

            // enviando a cobrança para a Administradora CC
            var resposta = await _externo.EnviarCobranca(cobrancaDto);

            // se ocorrer erro no pagamento
            if (!_validaExterno.CobracaValida(resposta))            
                return Invalido(command, "001x");

            // cobranca realizada
            var cobranca = RetornaCobranca(resposta).Result;

            // cartao usado no pagamento
            var cartao = _repositoryCiclista
                .UltimoCartaoAdicionado(idCiclista);

            var dataHoraRetirada = DateTime.Now;                       

            // alterando status da bicicleta para EM_USO
            await _equipamento.AlterarStatusBicicleta(
                bicicleta.Id, 
                EStatusBicicleta.EM_USO);

            // solicitando abertura da tranca
            await _equipamento.DestrancarTranca(idTranca);
                
            // totem onde estava a bicicleta
            var totem = RetornaTotem(tranca.Localizacao, 
                _equipamento).Result;

            var mensagemAluguelRealizado = new ReadDadosRetiradaDto(
                bicicleta, tranca, totem, ciclista, 
                cobranca, dataHoraRetirada, null);
            
            // mandando email com dados de retirada
            MandarEmail(idCiclista, 
                mensagemAluguelRealizado.ToString());            

            // realizando aluguel
            _repository.RealizaAluguel(
                _mapper.Map<Emprestimo>(command));
            
            // dados de resposta 
            var retorno = new ReadEmprestimoDto(
                bicicleta.Id, dataHoraRetirada, null,
                idTranca, Guid.Empty, cobranca.Id,
                idCiclista);

            return new OkCommandResult(retorno);                  
        }

        private static NotFoundCommandResult NaoEncontrado(
            RealizarAluguelCommand command, string codigoErro)
        {
            command.AdicionarErro(new Erro(codigoErro));

            return new NotFoundCommandResult(command.Erros);
        }

        private static UnprocessableEntityCommandResult Invalido(
            RealizarAluguelCommand command, string codigoErro)
        {
            command.AdicionarErro(new Erro(codigoErro));

            return new UnprocessableEntityCommandResult(command.Erros);
        }
        
        private void MandarEmail(Guid idCiclista, string mensagem)
        {
            var email = _repositoryCiclista.BuscarPorId(idCiclista).Email;
            
            // criando um email com os todos os dados do aluguel atual
            var conteudo = new CreateEnviarEmailDto(
                email,
                "Aluguel atual",
                mensagem);

            // realizando o envio do email
            _externo.EnviarEmail(conteudo);
        }

        private static async Task<ReadCobrancaDto?> RetornaCobranca(
            HttpResponseMessage resultado)
        {
            return JsonConvert
                .DeserializeObject<ReadCobrancaDto>(await
                resultado.Content.ReadAsStringAsync());
        }

        private static async Task<ReadTrancaDto?> RetornaTranca(
            Guid idTranca, IEquipamentoService equipamento)
        {
            var result = equipamento.BuscarTrancaPorId(idTranca).Result;

            return JsonConvert
                .DeserializeObject<ReadTrancaDto>(await
                result.Content.ReadAsStringAsync());
        }

        private static async Task<ReadTotemDto?> RetornaTotem(
            string localizacao, IEquipamentoService equipamento)
        {
            var result = equipamento.BuscarTotens().Result;

            var totens = JsonConvert
                .DeserializeObject<IList<ReadTotemDto>>(await
                result.Content.ReadAsStringAsync());
            
            return totens.FirstOrDefault(t => t.Localizacao.Equals(localizacao));
        }

        private static async Task<ReadBicicletaDto?> RetornaBicicleta(
            Guid idCiclista, IEquipamentoService equipamento)
        {            
            var result = equipamento
                .BuscarBicicletaPorTranca(idCiclista)
                .Result;
          
            return JsonConvert
                .DeserializeObject<ReadBicicletaDto>(await
                result.Content.ReadAsStringAsync());
        }
    }
}
