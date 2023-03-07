using Aluguel.Data;
using Aluguel.Data.Dtos;
using Aluguel.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aluguel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AluguelController : ControllerBase
    {
        private AluguelContexto contexto;
        private IMapper mapper;

        public AluguelController(AluguelContexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }
      
        [HttpPost]
        public IActionResult RealizaEmprestimo(Guid ciclistaId, Guid trancaId, 
            [FromBody] CreateEmprestimoDto emprestimoDto)
        {
            var aluguel = mapper.Map<Emprestimo>(emprestimoDto);

            contexto.Emprestimos.Add(aluguel);
            contexto.SaveChanges();

            return Ok(aluguel);
        }
    }
}
