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

namespace TesteAluguel.ApiFakes.Equipamento
{
    internal class EquipamentoDoubleTrancaSemCadastroEBicicletaCadastradaEmUso: IEquipamentoService
    {
        public EquipamentoDoubleTrancaSemCadastroEBicicletaCadastradaEmUso()
        {
        }

        public Task<HttpResponseMessage> BuscarBicicletaPorId(Guid idBicicleta)
        {
            var body = new GetBicicletaPorIdDto(){
                Id = idBicicleta,
                Marca=  "Caloi",
                Modelo = "BMX",
                Ano= "2010",
                Numero = 10,
                Status = EStatusBicicleta.EM_USO
            };

            var retorno = new HttpResponseMessage();

            retorno.Content = new StringContent(JsonConvert.SerializeObject(body));
            retorno.StatusCode = System.Net.HttpStatusCode.OK;

            return Task.FromResult(retorno);
        }

        public Task<HttpResponseMessage> BuscarTrancaPorId(Guid idTranca)
        {
            var retorno = new HttpResponseMessage();
            retorno.StatusCode = System.Net.HttpStatusCode.NotFound;

            return Task.FromResult(retorno);
        }
    }
}
