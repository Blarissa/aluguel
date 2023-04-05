﻿using Aluguel.Commands.Ciclistas;
using Aluguel.Data;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Handlers.Ciclistas;
using Aluguel.Models.Entidades;
using Aluguel.Repositorios.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Controllers
{
    [ApiController]
    [Produces("application/json")] 
    [Consumes("application/json")] 
    [Route("[controller]")]
    [Tags("Aluguel")]
    public class CiclistaController : ControllerBase
    {
        private readonly ICiclistaRepository repository;
        private AluguelContexto contexto;
        private IMapper mapper;

        public CiclistaController(ICiclistaRepository repository, AluguelContexto contexto, IMapper mapper)
        {
            this.repository = repository;
            this.contexto = contexto;
            this.mapper = mapper;
        }

        /// <summary>
        /// Cadastrar um ciclista
        /// </summary>
        /// <response code="201">Ciclista cadastrado</response>
        /// <response code="422">Dados inválidos</response>

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CiclistaDto))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public IActionResult AdicionarCiclista(
            [FromBody]AdicionarCiclistaCommand command,
            [FromServices]AdicionarCiclistaHandler handler)
        {
            return Ok(handler.Handle(command));
        }

        /// <summary>
        /// Recupera dados de um ciclista
        /// </summary>
        /// <response code="200">Retorna ciclista solicitado</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="422">Dados inválidos</response>

        [HttpGet("{idCiclista}")]
        [ProducesResponseType(200, Type = typeof(CiclistaDto))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public IActionResult RecuperaCiclistaPorId(Guid idCiclista)
        {
            return Ok(repository.BuscarPorId(idCiclista));
        }

        /// <summary>
        /// Alterar dados de um ciclista
        /// </summary>
        /// <response code="200">Dados atualizados</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="422">Dados inválidos</response>

        [HttpPut("{idCiclista}")]
        [ProducesResponseType(200, Type = typeof(CiclistaDto))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public IActionResult AtualizarCiclista(
            [FromBody]AtualizarCiclistaCommand command,
            [FromServices]AtualizarCiclistaHandler handler)
        {
            return Ok(handler.Handle(command));
        }

        /// <summary>
        /// Ativar cadastro do ciclista
        /// </summary>
        /// <response code="200">Ciclista ativado</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="422">Dados inválidos</response>

        [HttpPost("{idCiclista}/ativar")]
        [ProducesResponseType(200, Type = typeof(CiclistaDto))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]        
        public IActionResult AtivarCiclista(
            [FromBody]AtivarCiclistaCommand command,
            [FromServices]AtivarCiclistaHandler handler)
        {
            // falta parâmetro x-id-requisicao especificado no swagger
            return Ok(handler.Handle(command));
        }

        /// <summary>
        /// Verifica se o ciclista pode alugar uma bicicleta, já que só pode alugar uma por vez.
        /// </summary>
        /// <response code="200">true se puder alugar e false caso contrário</response>
        /// <response code="404">Não encontrado</response>

        [HttpGet("{idCiclista}/permiteAluguel")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult PodeAlugarBicleta(
            [FromBody]PodeFazerEmprestimoCommand command,
            [FromServices]PodeFazerEmprestimoHandler handler)
        {
            return Ok(handler.Handle(command));
        }

        /// <summary>        
        /// Obtém bicicleta alugada por um ciclista (ou vazio caso contrário).
        /// </summary>
        /// <response code = "200">Retorna bicicleta caso o ciclista tenha alugado ou vazio caso contrário.</response>
        /// <response code ="404">Ciclista não encontrado</response>        

        [HttpGet("{idCiclista}/bicicletaAlugada")]
        [ProducesResponseType(200, Type = typeof(Bicicleta))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult BuscaBicicletaAlugada(
            [FromBody]BuscarBicicletaAlugadaCommand command,
            [FromServices]BuscarBicicletaAlugadaHandler handler)
        {
            return Ok(handler.Handle(command));
        }

        /// <summary>        
        /// Verifica se o e-mail já foi utilizado por algum ciclista.
        /// </summary>
        /// <response code = "200">True caso exista o email e false caso contrario</response>
        /// <response code ="400">Email não enviado como parâmetro</response>
        /// <response code = "422">Dados inválidos</response>

        [HttpGet("existeEmail/{email}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400, Type = typeof(Erro))]
        [ProducesResponseType(422, Type = typeof(List<Erro>))]
        public IActionResult ExisteEmail(
            [FromBody]VerificarSeEmailExisteCommand command,
            [FromServices]VerificarSeEmailExisteHandler handler)
        {
            return Ok(handler.Handle(command));
        }
    }
}