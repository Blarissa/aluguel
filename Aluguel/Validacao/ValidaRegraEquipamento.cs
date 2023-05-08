using Aluguel.Commands;
using Aluguel.Commands.Alugueis;
using Aluguel.Commands.Contracts;
using Aluguel.Commands.Results;
using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using Aluguel.Servicos;
using Aluguel.Validacao.Interfaces;
using Newtonsoft.Json;

namespace Aluguel.Validacao
{
    public class ValidaRegraEquipamento : IValidaRegraEquipamento
    {
        IEquipamentoService equipamentoService;

        public ValidaRegraEquipamento(IEquipamentoService equipamentoService)
        {
            this.equipamentoService = equipamentoService;
        }

        public async Task<bool> StatusTranca(Guid idTranca)
        {
            // GET /tranca/{idTranca}
            var resposta = await BuscaPorIdResponse(idTranca);

            // converte json em objeto(GetTrancaPorIdDto)
            var tranca = await TrancaDto(resposta);

            // verifica se status está ocupada
            return tranca.Status
                   .Equals(EStatusTranca.OCUPADA);
        }

        public async Task<bool> ExisteTranca(Guid idTranca)
        {
            // GET /tranca/{idTranca}
            var resposta = await BuscaPorIdResponse(idTranca);

            // verifica se status code
            return !resposta.StatusCode
                   .Equals(StatusCodes.Status404NotFound);
        }

        public async Task<bool> TrancaResponde(Guid idTranca)
        {
            // GET /tranca/{idTranca}
            var resposta = await BuscaPorIdResponse(idTranca);

            return resposta.IsSuccessStatusCode;
        }

        public async Task<bool> BicicletaDisponivel(Guid idTranca)
        {
            // GET /tranca/{idTranca}/bicicleta
            var resposta = await BuscaBicicletaPorTrancaResponse(idTranca);

            // converte json em objeto(GetBicicletaPorIdDto)
            var bicicleta = await BicicletaDto(resposta);

            // verifica se status está ocupada
            return bicicleta.Status
                   .Equals(EStatusBicicleta.DISPONIVEL);
        }

        public async Task<bool> BicicletaEmReparo(Guid idTranca)
        {
            // GET /tranca/{idTranca}/bicicleta
            var resposta = await BuscaBicicletaPorTrancaResponse(idTranca);

            // converte json em objeto(GetBicicletaPorIdDto)
            var bicicleta = await BicicletaDto(resposta);

            // verifica se status está ocupada
            return bicicleta.Status
                   .Equals(EStatusBicicleta.DISPONIVEL);
        }

        public async Task<bool> ExisteBicicletaNaTranca(Guid idTranca)
        {
            // GET /tranca/{idTranca}
            var resposta = await BuscaPorIdResponse(idTranca);

            // converte json em objeto(GetTrancaPorIdDto)
            var tranca = await TrancaDto(resposta);

            // verifica se existe bicicleta na tranca
            return !tranca.Bicicleta.Equals(null);
        }

        private async Task<HttpResponseMessage> BuscaPorIdResponse(
            Guid idTranca)
        {
            return await equipamentoService
                   .BuscarTrancaPorId(idTranca);
        }

        private static async Task<ReadTrancaDto?> TrancaDto(
            HttpResponseMessage resposta)
        {
            return JsonConvert.DeserializeObject<ReadTrancaDto>(
                   await resposta.Content.ReadAsStringAsync());
        }

        private async Task<HttpResponseMessage> BuscaBicicletaPorTrancaResponse(
            Guid idTranca)
        {
            return await equipamentoService
                   .BuscarBicicletaPorTranca(idTranca);
        }

        private static async Task<ReadBicicletaDto?> BicicletaDto(
            HttpResponseMessage resposta)
        {
            return JsonConvert.DeserializeObject<ReadBicicletaDto>(
                   await resposta.Content.ReadAsStringAsync());
        }
    }
}
