using Aluguel.Data;
using Aluguel.Data.Dao;
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
        private FuncionarioDao funcionarioDao;
        private IMapper mapper;
        private IValidatorFuncionario validator;

        public FuncionarioController(AluguelContexto contexto, IMapper mapper)
        {
            this.contexto = contexto;
            funcionarioDao = new FuncionarioDao(contexto);
            this.mapper = mapper;    
            validator = new ValidacaoFuncionario();
        }

        [HttpGet]
        public IActionResult RecuperaFuncionarios()
        {
            var funcionarios = mapper.Map<List<ReadFuncionarioDto>>
                (funcionarioDao.RecuperaTodosFuncionarios());

            return Ok(funcionarios);
        }

        [HttpGet("{idFuncionario}")]
        public IActionResult RecuperaFuncionarioPorId(int idFuncionario)
        {
            if (!validator.Matricula(idFuncionario))
                return UnprocessableEntity();

            var funcionario = funcionarioDao.RecuperaFuncionarioPorId(idFuncionario);

            if (funcionario == null)
                return NotFound();            

            var funcionarioDto = mapper.Map<ReadFuncionarioDto>(funcionario);

            return Ok(funcionarioDto);
        }

        [HttpPost]
        public IActionResult AdicionaFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {
            if (!validator.IsValid(funcionarioDto))
                return UnprocessableEntity();

            var funcionario = mapper.Map<Funcionario>(funcionarioDto);

            funcionarioDao.AdicionaFuncionario(funcionario);
           
            return Ok(funcionario);
        }

        [HttpPut("{idFuncionario}")]
        public IActionResult AtualizaFuncionario(int idFuncionario, [FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            if (!validator.Matricula(idFuncionario))
                return UnprocessableEntity();

            var funcionario = funcionarioDao.RecuperaFuncionarioPorId(idFuncionario);

            if (funcionario == null)
                return NotFound();

            if (!validator.IsValid(funcionarioDto))
                return UnprocessableEntity();

            mapper.Map(funcionarioDto, funcionario);
            contexto.SaveChanges();

            return Ok(funcionario);
        }

        [HttpDelete("{idFuncionario}")]        
        public IActionResult DeletaFuncionario(int idFuncionario)
        {
            if (!validator.Matricula(idFuncionario))
                return UnprocessableEntity();
            
            var funcionario = funcionarioDao.RecuperaFuncionarioPorId(idFuncionario);
            
            if (funcionario == null)
                return NotFound();            

            funcionarioDao.DeletaFuncionario(funcionario);
                
            return Ok(funcionario);            
        }
    }
}
