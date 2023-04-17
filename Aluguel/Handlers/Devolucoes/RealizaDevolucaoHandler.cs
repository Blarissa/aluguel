using Aluguel.Commands;
using Aluguel.Commands.Devolucoes;
using Aluguel.Commands.Results;
using Aluguel.Data.Dtos.Devolucao;
using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Data.Dtos.Servicos.Externo;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;
using Aluguel.Servicos;

using Newtonsoft.Json;
using System.Net;

namespace Aluguel.Handlers.Devolucoes
{
    public class RealizaDevolucaoHandler
    {
        private readonly IDevolucaoRepository store;
        private readonly IExternoService externoApi;
        private readonly IEquipamentoService equipamentoApi;
        public RealizaDevolucaoHandler(IDevolucaoRepository store, IExternoService externoApi, IEquipamentoService equipamentoApi)
        {
            this.store = store;
            this.externoApi = externoApi;
            this.equipamentoApi = equipamentoApi;
        }

        public async Task<GenericCommandResult> RealizarDevolucaoAsync(RealizaDevolucaoCommand command)
        {
            try {
                //chamado da tranca
                var retornoBicicleta = await equipamentoApi.BuscarBicicletaPorId(command.Dados.IdBicicleta);
                ReadBicicletaDto bicicletaEmprestada = JsonConvert.DeserializeObject<ReadBicicletaDto>(await retornoBicicleta.Content.ReadAsStringAsync()) ?? new ReadBicicletaDto();

                //chamado da tranca
                var retornoTranca= await equipamentoApi.BuscarTrancaPorId(command.Dados.IdTranca);
                ReadTrancaDto trancaUsada = JsonConvert.DeserializeObject<ReadTrancaDto>(await retornoTranca.Content.ReadAsStringAsync()) ?? new ReadTrancaDto();

                if(retornoBicicleta.StatusCode == System.Net.HttpStatusCode.NotFound || retornoTranca.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return new NotFoundCommandResult(command.Erros);

                //Verifica o status da bicicleta e tranca
                if(bicicletaEmprestada.Status != EStatusBicicleta.EM_USO || trancaUsada.Status != EStatusTranca.LIVRE) {
                    //return UnprocessableEntity(new Erro("422", "Erro: Dados conflituosos"));
                    return new UnprocessableEntityCommandResult(command.Erros);
                }


                Emprestimo emprestimoBicicleta = store.BuscarEmprestimoAberto(command.Dados.IdBicicleta, command.Dados.IdTranca);
                if(emprestimoBicicleta == null) {
                    //return NotFound(new Erro("404", "Erro: Sem emprestimo corrente"));
                    return new NotFoundCommandResult(command.Erros);
                }

                TimeSpan duracaoAlguel = DateTime.Now - emprestimoBicicleta.DataHora;

                double valorAdicional = 0;

                double ValorDevido = 0;

                if(duracaoAlguel.TotalHours > 2)
                    ValorDevido = Math.Ceiling((duracaoAlguel.TotalMinutes - 120) / 30) * valorAdicional;

                //montar pacote de retorno
                ResponsePostDevolucaoDto confirmacao = new() {
                    Bicicleta = command.Dados.IdBicicleta,
                    Ciclista = emprestimoBicicleta.CiclistaId,
                    Cobranca = Guid.Empty,
                    TrancaFim = command.Dados.IdTranca,
                    HoraInicio = emprestimoBicicleta.DataHora,
                    HoraFim = DateTime.Now,
                };

                if(ValorDevido <= 0)
                    return new OkCommandResult(confirmacao);

                //faz cobranca do valor 
                var retCobranca = await externoApi.EnviarCobranca(new CreateCobrancaDto(
                    ValorDevido, emprestimoBicicleta.CiclistaId));

                //Fluxo alternativo caso cobrança falhe
                if(retCobranca.StatusCode != System.Net.HttpStatusCode.OK) {
                    var retFilaCobranca = await externoApi.EnviarCobrancaParaFila(new CreateFilaCobrancaDto(
                        ValorDevido, emprestimoBicicleta.CiclistaId));

                    if (retFilaCobranca.StatusCode != System.Net.HttpStatusCode.OK)
                        return new UnprocessableEntityCommandResult(command.Erros);

                    ReadFilaCobrancaDto bodyRetFilaCobranca =  JsonConvert.DeserializeObject<ReadFilaCobrancaDto>(await retCobranca.Content.ReadAsStringAsync());

                    confirmacao.Cobranca = bodyRetFilaCobranca.Id;
                    confirmacao.HoraFim = bodyRetFilaCobranca.HoraFinalizacao;
                    return new OkCommandResult(confirmacao);
                }

                ReadCobrancaDto bodyRetCobranca =  JsonConvert.DeserializeObject<ReadCobrancaDto>(await retCobranca.Content.ReadAsStringAsync());
                confirmacao.Cobranca = bodyRetCobranca.Id;
                confirmacao.HoraFim = bodyRetCobranca.HoraFinalizacao;
                return new OkCommandResult(confirmacao);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return new GenericCommandResult(ex.Message);
            }
        }
    }
}
