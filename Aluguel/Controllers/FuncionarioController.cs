using Aluguel.Data;
using Aluguel.Data.Dtos;
using Aluguel.Models;
using Aluguel.Validator;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

            //if (!validator.Matricula(idFuncionario))
            //    return UnprocessableEntity();

            var funcionarioDto = mapper.Map<ReadFuncionarioDto>(funcionario);

            return Ok(funcionarioDto);
        }

        [HttpPost]
        public IActionResult AdicionaFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {
            //if (!validator.IsValid(funcionarioDto))
            //    return UnprocessableEntity();

            var funcionario = mapper.Map<Funcionario>(funcionarioDto);

            contexto.Funcionarios.Add(funcionario);
            contexto.SaveChanges();

            return Ok(funcionario);
        }

        [HttpPut("{idFuncionario}")]
        public IActionResult AtualizaFuncionario(int idFuncionario, [FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            var funcionario = contexto
                .Funcionarios
                .FirstOrDefault(funcionario => funcionario.Matricula == idFuncionario);

            if (funcionario == null)
                return NotFound();

            //if (!validator.IsValid(funcionarioDto))
            //    return UnprocessableEntity();

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
