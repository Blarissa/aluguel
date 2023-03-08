using Aluguel.Data;
using Aluguel.Data.Dtos;
using Aluguel.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aluguel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private AluguelContexto contexto;
        private IMapper mapper;

        public FuncionarioController(AluguelContexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadFuncionarioDto> RecuperaFuncionarios()
        {            
            return mapper.Map<List<ReadFuncionarioDto>>(contexto.Funcionarios.ToList());
        }
        
        [HttpGet("{idFuncionario}")]
        public IActionResult RecuperaFuncionarioPorId(int idFuncionario)
        {
            var funcionario = contexto
                .Funcionarios
                .FirstOrDefault(f => f.Matricula == idFuncionario);

            if (funcionario == null)
                return NotFound();

            var funcionarioDto = mapper.Map<ReadFuncionarioDto>(funcionario);

            return Ok(funcionarioDto);
        }
        
        [HttpPost]        
        public IActionResult AdicionaFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {            
            var funcionario = mapper.Map<Funcionario>(funcionarioDto);

            contexto.Funcionarios.Add(funcionario);          
            contexto.SaveChanges();

            return Ok(funcionarioDto);
        }
        
        [HttpPut("{idFuncionario}")]
        public IActionResult AtualizaFuncionario(int idFuncionario, [FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            var funcionario = contexto
                .Funcionarios
                .FirstOrDefault(funcionario => funcionario.Matricula == idFuncionario);

            if (funcionario == null)
                return NotFound();

            mapper.Map(funcionarioDto, funcionario);
            contexto.SaveChanges();

            return NoContent();
        }
        
        [HttpDelete("{idFuncionario}")]
        public IActionResult DeletaFuncionario(int idFuncionario)
        {
            var funcionario = contexto
                .Funcionarios
                .FirstOrDefault(funcionario => funcionario.Matricula == idFuncionario);

            if (funcionario == null) 
                return NotFound();

            contexto.Funcionarios.Remove(funcionario);
            contexto.SaveChanges();

            return NoContent();
        }
    }
}
