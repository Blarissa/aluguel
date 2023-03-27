using Aluguel.Data;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Aluguel.Controllers
{
    [ApiController]
    [Produces("application/json")] 
    [Consumes("application/json")] 
    [Route("[controller]")]
    [Tags("Aluguel")]
    public class CiclistaController : ControllerBase
    {
        private AluguelContexto contexto;
        private IMapper mapper;

        public CiclistaController(AluguelContexto contexto, IMapper mapper)
        {
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
        public IActionResult AdicionarCiclista([FromBody,Required] AdicionarCiclistaDto adicionarCiclistaDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(new Erro("422", "Dados Invalidos"));
            }

            var ciclista = mapper.Map<Ciclista>(adicionarCiclistaDto.Ciclista);

            var meioDePagamento = mapper.Map<CartaoDeCredito>(adicionarCiclistaDto.MeioDePagamento);

            contexto.Ciclistas.Add(ciclista);

            meioDePagamento.CiclistaId = ciclista.Id;

            contexto.CartoesDeCredito.Add(meioDePagamento);
            contexto.SaveChanges();

            return Ok(ciclista);
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
            var ciclista = contexto
                .Ciclistas
                .Include(x => x.Passaporte)
                .ThenInclude(x => x.Pais)
                .FirstOrDefault(c => c.Id == idCiclista);

            if (ciclista == null) 
                return NotFound();

            var ciclistaDto = mapper.Map<CiclistaDto>(ciclista);

            return Ok(ciclistaDto);
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
        public IActionResult AtualizarCiclista(Guid idCiclista, [FromBody, Required] CiclistaDto ciclistaDto)
        {
            var ciclista = contexto
                .Ciclistas
                .Include(x => x.Passaporte)
                .ThenInclude(x => x.Pais)
                .FirstOrDefault(c => c.Id == idCiclista);

            if (ciclista == null)
                return NotFound();

            mapper.Map<CiclistaDto, Ciclista>(ciclistaDto, ciclista);
            contexto.SaveChanges();

            return Ok(ciclista);
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
        public IActionResult AtivarCiclista(Guid idCiclista)
        {
            // falta parâmetro x-id-requisicao especificado no swagger
            var ciclista = contexto
                .Ciclistas
                .FirstOrDefault(c => c.Id == idCiclista);

            if (ciclista == null)
                return NotFound();

            ciclista.Ativar();
            contexto.SaveChanges();

            return Ok(ciclista);
        }

        /// <summary>
        /// Verifica se o ciclista pode alugar uma bicicleta, já que só pode alugar uma por vez.
        /// </summary>
        /// <response code="200">true se puder alugar e false caso contrário</response>
        /// <response code="404">Não encontrado</response>

        [HttpGet("{idCiclista}/permiteAluguel")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult PermiteAluguel(Guid idCiclista)
        {

            var ciclista = contexto
                .Ciclistas
                .Include(c => c.Emprestimos)
                .ThenInclude(c => c.Devolucao)
                .FirstOrDefault(c => c.Id == idCiclista);

            if (ciclista == null)
                return NotFound();

            var emprestimo = ciclista.Emprestimos.LastOrDefault();

            if (emprestimo?.Devolucao != null)
                return Ok(false);

            return Ok(true);
        }

        /// <summary>        
        /// Obtém bicicleta alugada por um ciclista (ou vazio caso contrário).
        /// </summary>
        /// <response code = "200">Retorna bicicleta caso o ciclista tenha alugado ou vazio caso contrário.</response>
        /// <response code ="404">Ciclista não encontrado</response>        

        [HttpGet("{idCiclista}/bicicletaAlugada")]
        [ProducesResponseType(200, Type = typeof(Bicicleta))]
        [ProducesResponseType(404, Type = typeof(Erro))]
        public IActionResult BuscaBicicletaAlugada(Guid idCiclista)
        {
            var ciclista = contexto
                .Ciclistas
                .Include(c => c.Emprestimos)
                .ThenInclude(c => c.Bicicleta)
                .FirstOrDefault(c => c.Id == idCiclista);

            if (ciclista == null)
                return NotFound();

            var emprestimo = ciclista.Emprestimos.LastOrDefault();

            return Ok(emprestimo?.Bicicleta);
        }

        [HttpPost("{idCiclista}/notificaAluguelEmCurso")]
        public IActionResult NotificaAluguelEmCurso(Guid idCiclista)
        {
            var ciclista = contexto
                .Ciclistas
                .Include(c => c.Emprestimos)
                .Include(c => c.Passaporte)
                .FirstOrDefault(c => c.Id == idCiclista);

            if (ciclista == null)
                return NotFound();

            var emprestimo = ciclista.Emprestimos.LastOrDefault();

            if (emprestimo?.Devolucao != null)
                return NotFound(404);

            var ciclistaDto = mapper.Map<CiclistaDto>(ciclista);

            return Ok(ciclistaDto);
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
        public IActionResult ExisteEmail(string email)
        {
            var ciclista = contexto
                .Ciclistas
                .FirstOrDefault(c => c.Email == email);

            if (ciclista == null)
                return NotFound();

            return Ok(ciclista != null);
        }
    }
}