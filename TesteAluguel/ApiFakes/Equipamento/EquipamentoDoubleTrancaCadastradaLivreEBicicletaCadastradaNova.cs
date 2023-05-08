using Aluguel.Data.Dtos.Servicos.Equipamento;
using Aluguel.Models;
using Aluguel.Models.Entidades;
using Aluguel.Servicos;
using Aluguel.Servicos.Bicicleta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TesteAluguel.ApiFake
{
    internal class EquipamentoDoubleTrancaCadastradaLivreEBicicletaCadastradaNova : IEquipamentoService
    {
        public EquipamentoDoubleTrancaCadastradaLivreEBicicletaCadastradaNova()
        {
        }

        public Task<HttpResponseMessage> AlterarStatusBicicleta(Guid idBicicleta, EStatusBicicleta acao)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> BuscarBicicletaPorId(Guid idBicicleta)
        {
                var body = new ReadBicicletaDto(){
                    Id = idBicicleta,
                    Marca=  "Caloi",
                    Modelo = "BMX",
                    Ano= "2010",
                    Numero = 10,
                    Status = EStatusBicicleta.NOVA
                };

                var retorno = new HttpResponseMessage();

                retorno.Content = new StringContent(JsonConvert.SerializeObject(body));
                retorno.StatusCode = System.Net.HttpStatusCode.OK;

                return Task.FromResult(retorno);
        }

        public Task<HttpResponseMessage> BuscarBicicletaPorTranca(Guid idTranca)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> BuscarTotens()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> BuscarTrancaPorId(Guid idTranca)
        {
            var body = new ReadTrancaDto(){
                Id = idTranca,
                Numero = 10,
                Localizacao = "Endereco da tranca",
                AnoDeFabricacao = "2010",
                Modelo = "Chaveboa",
                Status = EStatusTranca.LIVRE,
            };

            var retorno = new HttpResponseMessage();
            retorno.Content = new StringContent(JsonConvert.SerializeObject(body));
            retorno.StatusCode = System.Net.HttpStatusCode.OK;

            return Task.FromResult(retorno);
        }

        public Task<HttpResponseMessage> DestrancarTranca(Guid idTranca)
        {
            throw new NotImplementedException();
        }
    }
}
