﻿using Aluguel.Data.Dtos.Servicos.Externo;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Mock.Equipamento
{
    [Route("mock/[controller]")]
    [ApiController]
    public class FilaCobrancaController : ControllerBase
    {
        [HttpPost]
        public IActionResult MockFilaCobranca([FromBody] PostFilaCobrancaDto dados)
        {
            var retorno = new ResponsePostFilaCobrancaDto() {
                Id = Guid.NewGuid(),
                Status = "Concluido",
                HoraSolicitacao = new DateTime(2023, 03, 12, 21, 00, 00),
                HoraFinalizacao = new DateTime(2023, 03, 12, 22, 00, 00),
                Valor = 100,
                Ciclista = Guid.Parse("123e4567-e89b-12d3-a456-426614174000"),
            };

            return Ok(retorno);
        }
    }
}
