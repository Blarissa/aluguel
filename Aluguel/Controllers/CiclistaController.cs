using Aluguel.Data;
using Aluguel.Data.Dtos.Ciclista;
using Aluguel.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aluguel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiclistaController : ControllerBase
    {
        private AluguelContexto contexto;
        private IMapper mapper;

        public CiclistaController(AluguelContexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCiclista([FromBody] AdicionarCiclistaDto adicionarCiclistaDto)
        {
            var ciclista = mapper.Map<Ciclista>(adicionarCiclistaDto);

            contexto.Ciclistas.Add(ciclista);

            Console.WriteLine(ciclista);

            return Ok(ciclista);
        }

        [HttpGet("{idCiclista}")]
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

        [HttpPut("{idCiclista}")]
        public IActionResult AtualizarCiclista(Guid idCiclista, [FromBody] CiclistaDto ciclistaDto)
        {
            var ciclista = contexto
                .Ciclistas
                .Include(x => x.Passaporte)
                .ThenInclude(x => x.Pais)
                .FirstOrDefault(c => c.Id == idCiclista);

            if (ciclista == null)
                return NotFound();

            mapper.Map(ciclistaDto, ciclista);
            contexto.SaveChanges();

            return Ok(ciclista);
        }

        [HttpPost("{idCiclista}/ativar")]
        public IActionResult AtivarCiclista(Guid idCiclista)
        {
            var ciclista = contexto
                .Ciclistas
                .FirstOrDefault(c => c.Id == idCiclista);

            if (ciclista == null)
                return NotFound();

            ciclista.Ativar();
            contexto.SaveChanges();

            return Ok(ciclista);
        }

        [HttpGet("{idCiclista}/permiteAluguel")]
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

        [HttpGet("{idCiclista}/bicicletaAlugada")]
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

        [HttpGet("existeEmail/{email}")]
        public IActionResult BuscaBicicletaAlugada(string email)
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